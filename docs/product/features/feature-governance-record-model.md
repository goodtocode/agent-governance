# Feature: Governance Record Model

## Summary
`EvaluationGovernanceRecord` models the four assurance pillars used across enforcement and prompt generation.

## Key Types
- `EvaluationGovernanceRecord`
- `ObservabilityRecord`
- `RepeatabilityRecord`
- `AuditabilityRecord`
- `DefensibilityRecord`

## Behavior
- Captures policy profile version.
- Stores trace/correlation/evidence for observability.
- Stores model and hash material for repeatability.
- Stores actor and tool references for auditability.
- Stores policy/justification/reasoning/confidence for defensibility.

## Value
Provides a single canonical governance payload for AI workflow controls.