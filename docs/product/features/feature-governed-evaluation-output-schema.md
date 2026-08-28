# Feature: Governed Evaluation Output Schema

## Summary
`GovernedEvaluationOutputSchema` defines the expected governed AI evaluation output contract, including criterion-level scoring and audit trace metadata.

## Key Types
- `GovernedEvaluationOutputSchema`
- `GovernedEvaluationCriterionSchema`
- `GovernedEvaluationAuditTraceSchema`

## Behavior
- Models overall score, level, confidence, and defensibility summary.
- Models per-criterion score, evidence, justification, confidence, and defensibility.
- Models audit trace (model version, rubric version, timestamp, evaluation ID).
- Provides `Validate()` methods that return complete issue lists.

## Value
Standardizes output shape for auditability and downstream validation.