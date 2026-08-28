namespace Goodtocode.Agent.Governance.Application;

/// <summary>
/// Raw governance input for enforcement.
/// </summary>
public sealed class GovernanceEvaluationRequest
{
    /// <summary>
    /// Gets or sets governance record.
    /// </summary>
    public EvaluationGovernanceRecord Governance { get; init; } = new();

    /// <summary>
    /// Gets or sets optional existing system instruction.
    /// </summary>
    public string? ExistingSystemInstruction { get; init; }

    /// <summary>
    /// Gets or sets optional raw prompt content used to deterministically compute
    /// <see cref="RepeatabilityRecord.PromptHash"/> during enforcement.
    /// </summary>
    public string? RepeatabilityPromptContent { get; init; }

    /// <summary>
    /// Gets or sets optional raw input values used to deterministically compute
    /// <see cref="RepeatabilityRecord.InputHash"/> during enforcement.
    /// </summary>
    public IReadOnlyDictionary<string, object?> RepeatabilityInputs { get; init; } =
        new Dictionary<string, object?>(StringComparer.Ordinal);
}

/// <summary>
/// Governance enforcement result.
/// </summary>
public sealed class GovernedEvaluationResult
{
    /// <summary>
    /// Gets or sets validated governance record.
    /// </summary>
    public EvaluationGovernanceRecord Governance { get; init; } = new();

    /// <summary>
    /// Gets or sets governance prompt context.
    /// </summary>
    public EvaluationGovernancePromptContext PromptContext { get; init; } = new();

    /// <summary>
    /// Gets the computed repeatability prompt hash.
    /// </summary>
    public string PromptHash => Governance.Repeatability.PromptHash;

    /// <summary>
    /// Gets the computed repeatability input hash.
    /// </summary>
    public string InputHash => Governance.Repeatability.InputHash;
}
