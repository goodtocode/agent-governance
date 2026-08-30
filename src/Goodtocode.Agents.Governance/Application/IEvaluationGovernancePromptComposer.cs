namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Builds runtime prompt context from a governance record.
/// </summary>
public interface IEvaluationGovernancePromptComposer
{
    /// <summary>
    /// Composes deterministic governance instructions and metadata.
    /// </summary>
    /// <param name="request">Prompt composition request.</param>
    /// <returns>Prompt context for governed inference.</returns>
    EvaluationGovernancePromptContext Compose(EvaluationGovernancePromptRequest request);
}
