# Feature: Governance Prompt Composition

## Summary
`EvaluationGovernancePromptComposer` builds deterministic system instructions and normalized metadata from governance records.

## Key Types
- `IEvaluationGovernancePromptComposer`
- `EvaluationGovernancePromptComposer`
- `EvaluationGovernancePromptRequest`
- `EvaluationGovernancePromptContext`

## Behavior
- Validates governance input before composing output.
- Appends mandatory core governance directives.
- Optionally prepends an existing system instruction.
- Writes normalized metadata for policy, observability, repeatability, auditability, and defensibility.

## Value
Ensures model prompts include consistent governance guardrails and audit metadata.