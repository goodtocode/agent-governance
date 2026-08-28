using Goodtocode.Agent.Governance.Application;

namespace Goodtocode.Agent.Governance.Tests.Application;

[TestClass]
public sealed class GovernanceReplayGuardTests
{
    [TestMethod]
    public void EnsureExactReplayWithMatchingSnapshotsDoesNotThrow()
    {
        // Arrange
        var baseline = new GovernanceReplaySnapshot(
            PolicyProfileVersion: "ai-assurance.v1",
            ModelRef: "model://gpt/governed",
            ModelVersion: "1.0.0",
            PromptHash: "PROMPT-HASH-001",
            InputHash: "INPUT-HASH-001");

        var current = baseline with { };

        // Act
        Action action = () => GovernanceReplayGuard.EnsureExactReplay(baseline, current);

        // Assert
        action();
    }

    [TestMethod]
    public void EnsureExactReplayWithPromptHashMismatchThrowsInvalidOperationException()
    {
        // Arrange
        var baseline = new GovernanceReplaySnapshot(
            PolicyProfileVersion: "ai-assurance.v1",
            ModelRef: "model://gpt/governed",
            ModelVersion: "1.0.0",
            PromptHash: "PROMPT-HASH-001",
            InputHash: "INPUT-HASH-001");

        var current = baseline with { PromptHash = "PROMPT-HASH-999" };

        // Act
        Action action = () => GovernanceReplayGuard.EnsureExactReplay(baseline, current);

        // Assert
        InvalidOperationException? exception = null;
        try
        {
            action();
        }
        catch (InvalidOperationException ex)
        {
            exception = ex;
        }

        Assert.IsNotNull(exception);
    }
}
