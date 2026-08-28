namespace Goodtocode.Agent.Governance.Application;

/// <summary>
/// Default governance enforcer implementation.
/// </summary>
public sealed class GovernanceEnforcer(
    IEvaluationGovernancePromptComposer promptComposer) : IGovernanceEnforcer
{
    private readonly IEvaluationGovernancePromptComposer _promptComposer = promptComposer;

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

    private static EvaluationGovernanceRecord ApplyRepeatabilityHashes(GovernanceEvaluationRequest request)
    {
        var repeatability = request.Governance.Repeatability;
        var computedPromptHash = string.IsNullOrWhiteSpace(request.RepeatabilityPromptContent)
            ? repeatability.PromptHash
            : RepeatabilityHashService.ComputePromptHash(request.RepeatabilityPromptContent);
        var computedInputHash = request.RepeatabilityInputs.Count == 0
            ? repeatability.InputHash
            : RepeatabilityHashService.ComputeInputHash(request.RepeatabilityInputs);

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
