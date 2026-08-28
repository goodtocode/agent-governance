# Feature: Governance Validation

## Summary
`EvaluationGovernanceValidator` performs strict validation of governance records and returns structured issues.

## Key Types
- `EvaluationGovernanceValidator`
- `EvaluationGovernanceValidationResult`
- `GovernanceValidationIssue`
- `GovernanceValidationException`

## Behavior
- Validates required fields across all four governance pillars.
- Validates list presence for evidence/policy/justification references.
- Validates defensibility confidence score range (0..1).
- Aggregates issues rather than failing on first issue.

## Value
Guarantees governance completeness before prompt construction or inference.