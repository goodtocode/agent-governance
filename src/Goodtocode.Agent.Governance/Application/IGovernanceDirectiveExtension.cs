namespace Goodtocode.Agent.Governance.Application;

/// <summary>
/// Adds optional governance directives while preserving mandatory core governance behavior.
/// </summary>
public interface IGovernanceDirectiveExtension
{
    /// <summary>
    /// Gets unique extension identifier.
    /// </summary>
    string ExtensionId { get; }

    /// <summary>
    /// Gets extension version for audit metadata.
    /// </summary>
    string ExtensionVersion { get; }

    /// <summary>
    /// Gets extension ordering. Lower values are applied first.
    /// </summary>
    int Order { get; }

    /// <summary>
    /// Builds extension directives and metadata for a governance prompt request.
    /// </summary>
    /// <param name="request">Governance prompt request.</param>
    /// <returns>Directive contribution.</returns>
    GovernanceDirectiveContribution Build(EvaluationGovernancePromptRequest request);
}

/// <summary>
/// Extension output for governance prompt composition.
/// </summary>
public sealed class GovernanceDirectiveContribution
{
    /// <summary>
    /// Gets or sets additional directives to append to the system instruction.
    /// </summary>
    public IReadOnlyCollection<string> Directives { get; init; } = [];

    /// <summary>
    /// Gets or sets additional metadata to persist with governance context.
    /// </summary>
    public IReadOnlyDictionary<string, string> Metadata { get; init; } =
        new Dictionary<string, string>(StringComparer.Ordinal);
}
