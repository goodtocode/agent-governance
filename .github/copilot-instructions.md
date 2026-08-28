# Copilot Instructions for Goodtocode.Agent.Governance

## Project Overview
Goodtocode.Agent.Governance is a .NET governance library for AI inference workflows. It provides deterministic governance enforcement across observability, repeatability, auditability, and defensibility.

## Repository Shape
- Solution: Goodtocode.Agent.Governance.slnx
- Library: src/Goodtocode.Agent.Governance
- Tests: src/Goodtocode.Agent.Governance.Tests
- Product docs: docs/product/**
- Governance docs: docs/governance/**
- Automation: .github/workflows/** and .github/scripts/**

## Coding Expectations
- Follow existing patterns in the touched folder before introducing new patterns.
- Keep public contracts stable unless requested.
- Prefer deterministic behavior and explicit validation.
- Use Microsoft/.NET built-in capabilities unless a new dependency is necessary.
- Keep XML docs and markdown docs aligned with behavior changes.

## Testing Expectations
- Build the solution after code changes.
- Run relevant tests in Goodtocode.Agent.Governance.Tests.
- For workflow/script updates, validate referenced paths and commands against this repo layout.

## Documentation Expectations
When modifying docs, keep terms aligned with Sprint 0 artifacts:
- docs/product/sprint-0/agent-governance-sprint-0-ontology.md
- docs/product/sprint-0/agent-governance-sprint-0-context-diagram.md

## CI/CD Expectations
- Ensure workflow commands match installed SDK and command semantics.
- Keep package CI focused on restore/build/test/pack for this solution and project names.
- Avoid environment assumptions that do not exist in this repository.
