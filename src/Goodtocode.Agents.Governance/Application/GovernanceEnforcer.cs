namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Default governance enforcer implementation.
/// </summary>
/// <remarks>
/// Repeatability hashes are never accepted as caller-supplied values. The enforcer always
/// derives <see cref="RepeatabilityRecord.PromptHash"/> and <see cref="RepeatabilityRecord.InputHash"/>
/// from the raw <see cref="GovernanceEvaluationRequest.RepeatabilityPromptContent"/> and
/// <see cref="GovernanceEvaluationRequest.RepeatabilityInputs"/> values, unconditionally, on every call
/// (including when those raw values are empty). This keeps hashing closed for modification while the
/// hashing algorithm itself remains open for extension via <see cref="IRepeatabilityHashStrategy"/>.
/// </remarks>
public sealed class GovernanceEnforcer(
    IEvaluationGovernancePromptComposer promptComposer,
    IRepeatabilityHashStrategy? hashStrategy = null) : IGovernanceEnforcer
{
    private readonly IEvaluationGovernancePromptComposer _promptComposer = promptComposer;
    private readonly IRepeatabilityHashStrategy _hashStrategy = hashStrategy ?? new DefaultRepeatabilityHashStrategy();

    /// <inheritdoc />
    public GovernedEvaluationResult Enforce(GovernanceEvaluationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var governance = ApplyRepeatabilityHashes(request);

        var validation = EvaluationGovernanceValidator.Validate(governance);
        if (!validation.IsValid)
        {
            throw new GovernanceValidationException(validation.Issues);
        }

        var promptContext = _promptComposer.Compose(new EvaluationGovernancePromptRequest
        {
            Governance = governance,
            ExistingSystemInstruction = request.ExistingSystemInstruction
        });

        return new GovernedEvaluationResult
        {
            Governance = governance,
            PromptContext = promptContext
        };
    }

    private EvaluationGovernanceRecord ApplyRepeatabilityHashes(GovernanceEvaluationRequest request)
    {
        var repeatability = request.Governance.Repeatability;
        var computedPromptHash = _hashStrategy.ComputePromptHash(request.RepeatabilityPromptContent ?? string.Empty);
        var computedInputHash = _hashStrategy.ComputeInputHash(request.RepeatabilityInputs);

        return request.Governance with
        {
            Repeatability = repeatability with
            {
                PromptHash = computedPromptHash,
                InputHash = computedInputHash
            }
        };
    }
}
