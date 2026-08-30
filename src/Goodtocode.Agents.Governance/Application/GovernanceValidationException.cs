namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Exception raised when a governance record fails validation.
/// </summary>
public sealed class GovernanceValidationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GovernanceValidationException"/> class.
    /// </summary>
    /// <param name="issues">Validation issues.</param>
    public GovernanceValidationException(IReadOnlyCollection<GovernanceValidationIssue> issues)
        : base(BuildMessage(issues))
    {
        Issues = issues;
    }

    /// <summary>
    /// Gets validation issues.
    /// </summary>
    public IReadOnlyCollection<GovernanceValidationIssue> Issues { get; }

    private static string BuildMessage(IReadOnlyCollection<GovernanceValidationIssue> issues)
    {
        if (issues.Count == 0)
        {
            return "Governance validation failed.";
        }

        return $"Governance validation failed: {string.Join("; ", issues.Select(x => $"{x.Field}: {x.Message}"))}";
    }
}
