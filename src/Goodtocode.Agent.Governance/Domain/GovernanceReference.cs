namespace Goodtocode.Agent.Governance.Domain;

/// <summary>
/// Strict, non-empty reference identifier used for evidence, policy, and justification links.
/// </summary>
/// <param name="Value">Canonical reference value.</param>
public readonly record struct GovernanceReference(string Value)
{
    /// <summary>
    /// Creates a strict governance reference from input value.
    /// </summary>
    /// <param name="value">Reference value.</param>
    /// <returns>A strict governance reference.</returns>
    public static GovernanceReference Parse(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Reference value is required.", nameof(value));
        }

        return new GovernanceReference(value.Trim());
    }

    /// <summary>
    /// Returns the canonical string value.
    /// </summary>
    /// <returns>Reference value.</returns>
    public override string ToString()
    {
        return Value;
    }
}
