using Goodtocode.Agent.Governance.Domain;

namespace Goodtocode.Agent.Governance.Tests.Domain;

[TestClass]
public sealed class GovernancePillarsProfileTests
{
    [TestMethod]
    public void CreateStrictWithValidVersionReturnsAllPillarsRequired()
    {
        // Arrange
        const string version = "ai-assurance.v1";

        // Act
        var profile = GovernancePillarsProfile.CreateStrict(version);

        // Assert
        Assert.AreEqual(version, profile.PolicyProfileVersion);
        Assert.IsTrue(profile.ObservabilityRequired);
        Assert.IsTrue(profile.AuditabilityRequired);
        Assert.IsTrue(profile.RepeatabilityRequired);
        Assert.IsTrue(profile.DefensibilityRequired);
        Assert.IsTrue(profile.IsFullyRequired());
    }

    [TestMethod]
    public void ComputeLockHashWithSameProfileIsDeterministic()
    {
        // Arrange
        var profile = GovernancePillarsProfile.CreateStrict("ai-assurance.v1");

        // Act
        var first = profile.ComputeLockHash();
        var second = profile.ComputeLockHash();

        // Assert
        Assert.AreEqual(first, second);
    }

    [TestMethod]
    public void ComputeLockHashWithDifferentProfilesProducesDifferentHashes()
    {
        // Arrange
        var strict = GovernancePillarsProfile.CreateStrict("ai-assurance.v1");
        var relaxed = new GovernancePillarsProfile("ai-assurance.v1", true, true, true, false);

        // Act
        var strictHash = strict.ComputeLockHash();
        var relaxedHash = relaxed.ComputeLockHash();

        // Assert
        Assert.AreNotEqual(strictHash, relaxedHash);
    }
}
