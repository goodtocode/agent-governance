# Feature: Governance Enforcement

## Summary
`GovernanceEnforcer` is the primary orchestration feature. It validates governance payloads, computes deterministic repeatability hashes when raw inputs are provided, and produces governed prompt context for downstream AI inference.

## Key Types
- `IGovernanceEnforcer`
- `GovernanceEnforcer`
- `GovernanceEvaluationRequest`
- `GovernedEvaluationResult`

## Behavior
- Accepts a raw governance request.
- Computes `PromptHash` and `InputHash` when optional raw content/inputs are present.
- Runs full governance validation.
- Throws `GovernanceValidationException` on invalid data.
- Returns validated governance data and composed system instruction metadata.

## Value
Provides one deterministic enforcement entry point before model execution.