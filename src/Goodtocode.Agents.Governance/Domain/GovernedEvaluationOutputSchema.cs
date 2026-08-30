namespace Goodtocode.Agents.Governance.Domain;

/// <summary>
/// Governed evaluation output contract that requires auditable and defensible evaluation details.
/// </summary>
public sealed class GovernedEvaluationOutputSchema
{
    /// <summary>
    /// Gets or sets the overall score in range 0..100.
    /// </summary>
    public int OverallScore { get; set; }

    /// <summary>
    /// Gets or sets the overall score level.
    /// </summary>
    public string OverallLevel { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the overall confidence score in range 0..1.
    /// </summary>
    public double OverallConfidence { get; set; }

    /// <summary>
    /// Gets or sets the defensibility summary for the overall result.
    /// </summary>
    public string DefensibilitySummary { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets criterion-level outcomes.
    /// </summary>
    public ICollection<GovernedEvaluationCriterionSchema> Criteria { get; set; } = [];

    /// <summary>
    /// Gets or sets strengths.
    /// </summary>
    public ICollection<string> Strengths { get; set; } = [];

    /// <summary>
    /// Gets or sets weaknesses.
    /// </summary>
    public ICollection<string> Weaknesses { get; set; } = [];

    /// <summary>
    /// Gets or sets recommendations.
    /// </summary>
    public ICollection<string> Recommendations { get; set; } = [];

    /// <summary>
    /// Gets or sets audit trace metadata.
    /// </summary>
    public GovernedEvaluationAuditTraceSchema AuditTrace { get; set; } = new();

    /// <summary>
    /// Validates the output schema and returns all discovered issues.
    /// </summary>
    /// <returns>Validation issues. Empty collection means valid.</returns>
    public IReadOnlyCollection<string> Validate()
    {
        var issues = new List<string>();

        if (OverallScore is < 0 or > 100)
        {
            issues.Add("overall_score must be between 0 and 100.");
        }

        if (string.IsNullOrWhiteSpace(OverallLevel))
        {
            issues.Add("overall_level is required.");
        }

        if (OverallConfidence is < 0 or > 1)
        {
            issues.Add("overall_confidence must be between 0 and 1.");
        }

        if (string.IsNullOrWhiteSpace(DefensibilitySummary))
        {
            issues.Add("defensibility_summary is required.");
        }

        if (Criteria.Count == 0)
        {
            issues.Add("criteria must include at least one criterion entry.");
        }
        else
        {
            var index = 0;
            foreach (var criterion in Criteria)
            {
                var prefix = $"criteria[{index}]";
                if (string.IsNullOrWhiteSpace(criterion.Name))
                {
                    issues.Add($"{prefix}.name is required.");
                }

                if (criterion.Score is < 0 or > 100)
                {
                    issues.Add($"{prefix}.score must be between 0 and 100.");
                }

                if (string.IsNullOrWhiteSpace(criterion.Level))
                {
                    issues.Add($"{prefix}.level is required.");
                }

                if (string.IsNullOrWhiteSpace(criterion.Justification))
                {
                    issues.Add($"{prefix}.justification is required.");
                }

                if (string.IsNullOrWhiteSpace(criterion.Evidence))
                {
                    issues.Add($"{prefix}.evidence is required.");
                }

                if (string.IsNullOrWhiteSpace(criterion.RubricReference))
                {
                    issues.Add($"{prefix}.rubric_reference is required.");
                }

                if (criterion.Confidence is < 0 or > 1)
                {
                    issues.Add($"{prefix}.confidence must be between 0 and 1.");
                }

                if (string.IsNullOrWhiteSpace(criterion.Defensibility))
                {
                    issues.Add($"{prefix}.defensibility is required.");
                }

                index++;
            }
        }

        issues.AddRange(AuditTrace.Validate());
        return issues;
    }
}

/// <summary>
/// Criterion-level governed evaluation entry.
/// </summary>
public sealed class GovernedEvaluationCriterionSchema
{
    /// <summary>
    /// Gets or sets criterion name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets score in range 0..100.
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Gets or sets level.
    /// </summary>
    public string Level { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets justification text.
    /// </summary>
    public string Justification { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets evidence text or reference snippet.
    /// </summary>
    public string Evidence { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets rubric reference used for scoring.
    /// </summary>
    public string RubricReference { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets confidence score in range 0..1.
    /// </summary>
    public double Confidence { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether uncertainty was flagged.
    /// </summary>
    public bool UncertaintyFlag { get; set; }

    /// <summary>
    /// Gets or sets defensibility text explaining score appropriateness.
    /// </summary>
    public string Defensibility { get; set; } = string.Empty;
}

/// <summary>
/// Audit metadata for governed outputs.
/// </summary>
public sealed class GovernedEvaluationAuditTraceSchema
{
    /// <summary>
    /// Gets or sets model version.
    /// </summary>
    public string ModelVersion { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets rubric version.
    /// </summary>
    public string RubricVersion { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets evaluation timestamp in UTC.
    /// </summary>
    public DateTimeOffset TimestampUtc { get; set; }

    /// <summary>
    /// Gets or sets evaluation identifier.
    /// </summary>
    public Guid EvaluationId { get; set; }

    /// <summary>
    /// Validates audit metadata.
    /// </summary>
    /// <returns>Validation issues. Empty collection means valid.</returns>
    public IReadOnlyCollection<string> Validate()
    {
        var issues = new List<string>();

        if (string.IsNullOrWhiteSpace(ModelVersion))
        {
            issues.Add("audit_trace.model_version is required.");
        }

        if (string.IsNullOrWhiteSpace(RubricVersion))
        {
            issues.Add("audit_trace.rubric_version is required.");
        }

        if (TimestampUtc == DateTimeOffset.MinValue)
        {
            issues.Add("audit_trace.timestamp_utc is required.");
        }

        if (EvaluationId == Guid.Empty)
        {
            issues.Add("audit_trace.evaluation_id is required.");
        }

        return issues;
    }
}
