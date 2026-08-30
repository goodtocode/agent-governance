namespace Goodtocode.Agents.Governance.Application;

/// <summary>
/// Snapshot used to compare repeatability constraints between executions.
/// </summary>
public sealed record GovernanceReplaySnapshot(
    string PolicyProfileVersion,
    string ModelRef,
    string ModelVersion,
    string PromptHash,
    string InputHash);

/// <summary>
/// Guards against replay drift by enforcing exact snapshot matches.
/// </summary>
public static class GovernanceReplayGuard
{
    /// <summary>
    /// Validates that the current snapshot matches the baseline snapshot exactly.
    /// </summary>
    /// <param name="baseline">Baseline snapshot from persisted execution.</param>
    /// <param name="current">Current snapshot from replay attempt.</param>
    public static void EnsureExactReplay(GovernanceReplaySnapshot baseline, GovernanceReplaySnapshot current)
    {
        ArgumentNullException.ThrowIfNull(baseline);
        ArgumentNullException.ThrowIfNull(current);

        if (!string.Equals(baseline.PolicyProfileVersion, current.PolicyProfileVersion, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Replay drift detected: policy profile version mismatch.");
        }

        if (!string.Equals(baseline.ModelRef, current.ModelRef, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Replay drift detected: model reference mismatch.");
        }

        if (!string.Equals(baseline.ModelVersion, current.ModelVersion, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Replay drift detected: model version mismatch.");
        }

        if (!string.Equals(baseline.PromptHash, current.PromptHash, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Replay drift detected: prompt hash mismatch.");
        }

        if (!string.Equals(baseline.InputHash, current.InputHash, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Replay drift detected: input hash mismatch.");
        }
    }
}
