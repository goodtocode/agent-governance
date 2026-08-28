# Feature: Governance Directive Extensions

## Summary
The extension feature allows controlled, ordered additions to governance directives and metadata during prompt composition.

## Key Types
- `IGovernanceDirectiveExtension`
- `GovernanceDirectiveContribution`
- `EvaluationGovernancePromptComposer` extension pipeline

## Behavior
- Extensions are ordered by `Order`, then `ExtensionId`.
- Duplicate extension IDs are rejected.
- Empty directives/metadata keys are rejected.
- Prohibited directive fragments (for governance bypass) are blocked.
- Extension metadata keys are normalized and namespaced.

## Value
Supports customization without allowing unsafe governance overrides.