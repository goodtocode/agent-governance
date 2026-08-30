namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Validation issue for governance enforcement.
/// </summary>
/// <param name="Field">Invalid field name.</param>
/// <param name="Message">Issue description.</param>
public sealed record GovernanceValidationIssue(string Field, string Message);

/// <summary>
/// Validation result for a governance record.
/// </summary>
public sealed class EvaluationGovernanceValidationResult
{
    private readonly List<GovernanceValidationIssue> _issues = [];

    /// <summary>
    /// Gets a value indicating whether the record is valid.
    /// </summary>
    public bool IsValid => _issues.Count == 0;

    /// <summary>
    /// Gets validation issues.
    /// </summary>
    public IReadOnlyCollection<GovernanceValidationIssue> Issues => _issues.AsReadOnly();

    /// <summary>
    /// Adds a validation issue.
    /// </summary>
    /// <param name="field">Field name.</param>
    /// <param name="message">Issue message.</param>
    public void Add(string field, string message)
    {
        _issues.Add(new GovernanceValidationIssue(field, message));
    }
}
