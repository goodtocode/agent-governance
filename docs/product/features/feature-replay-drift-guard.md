# Feature: Replay Drift Guard

## Summary
`GovernanceReplayGuard` prevents replay drift by enforcing exact matches between baseline and current repeatability snapshots.

## Key Types
- `GovernanceReplaySnapshot`
- `GovernanceReplayGuard`

## Behavior
- Compares policy profile version, model reference, model version, prompt hash, and input hash.
- Throws `InvalidOperationException` when any value differs.

## Value
Protects deterministic replay guarantees for governed executions.