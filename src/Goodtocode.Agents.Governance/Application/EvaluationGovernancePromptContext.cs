namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Prompt context generated from governance records.
/// </summary>
public sealed class EvaluationGovernancePromptContext
{
    /// <summary>
    /// Gets or sets the system instruction with governance guardrails.
    /// </summary>
    public string SystemInstruction { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets normalized governance metadata.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
}

/// <summary>
/// Prompt composition input payload.
/// </summary>
public sealed class EvaluationGovernancePromptRequest
{
    /// <summary>
    /// Gets or sets governance record.
    /// </summary>
    public EvaluationGovernanceRecord Governance { get; init; } = new();

    /// <summary>
    /// Gets or sets optional existing system instruction.
    /// </summary>
    public string? ExistingSystemInstruction { get; init; }
}
