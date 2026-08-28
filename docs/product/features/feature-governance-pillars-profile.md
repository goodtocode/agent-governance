# Feature: Governance Pillars Profile

## Summary
`GovernancePillarsProfile` represents policy requirements for observability, repeatability, auditability, and defensibility.

## Key Types
- `GovernancePillarsProfile`

## Behavior
- Provides `CreateStrict()` helper for all-required governance mode.
- Exposes `IsFullyRequired()` convenience check.
- Computes deterministic lock hash from normalized profile payload.

## Value
Provides a compact policy profile object for governance requirement declaration and drift detection.