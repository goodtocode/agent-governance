# Feature: Repeatability Hash Service

## Summary
`RepeatabilityHashService` creates deterministic SHA-256 hashes for prompt content and structured input values.

## Key Types
- `RepeatabilityHashService`

## Behavior
- Computes prompt hash from UTF-8 prompt content.
- Normalizes input dictionary ordering by key.
- Canonicalizes JSON object property order before hashing.
- Produces uppercase hexadecimal hash output.

## Value
Provides stable repeatability fingerprints across executions.