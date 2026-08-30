namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Validates governance records and composes governance prompt context.
/// </summary>
public interface IGovernanceEnforcer
{
    /// <summary>
    /// Validates and enforces governance constraints.
    /// </summary>
    /// <param name="request">Raw governance request.</param>
    /// <returns>Validated governance output with prompt context.</returns>
    GovernedEvaluationResult Enforce(GovernanceEvaluationRequest request);
}
