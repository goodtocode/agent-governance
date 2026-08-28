using Goodtocode.Agent.Governance.Application;

namespace Goodtocode.Agent.Governance.Tests.Application;

[TestClass]
public sealed class EvaluationGovernanceValidatorTests
{
    [TestMethod]
    public void ValidateWithCompleteGovernanceRecordReturnsValidResult()
    {
        // Arrange
        var record = TestDataFactory.CreateValidGovernanceRecord();

        // Act
        var result = EvaluationGovernanceValidator.Validate(record);

        // Assert
        Assert.IsTrue(result.IsValid);
        Assert.IsEmpty(result.Issues);
    }

    [TestMethod]
    public void ValidateWithIncompleteGovernanceRecordReturnsIssues()
    {
        // Arrange
        var record = new EvaluationGovernanceRecord();

        // Act
        var result = EvaluationGovernanceValidator.Validate(record);

        // Assert
        Assert.IsFalse(result.IsValid);
        Assert.IsNotEmpty(result.Issues);
        Assert.IsTrue(result.Issues.Any(x => x.Field == nameof(EvaluationGovernanceRecord.PolicyProfileVersion)));
    }
}
