using Goodtocode.Agents.Governance.Domain;

namespace Goodtocode.Agents.Governance.Tests.Domain;

[TestClass]
public sealed class GovernedEvaluationOutputSchemaTests
{
    [TestMethod]
    public void ValidateWithValidSchemaReturnsNoIssues()
    {
        // Arrange
        var schema = TestDataFactory.CreateValidOutputSchema();

        // Act
        var issues = schema.Validate();

        // Assert
        Assert.IsEmpty(issues);
    }

    [TestMethod]
    public void ValidateWithMissingRequiredFieldsReturnsIssues()
    {
        // Arrange
        var schema = new GovernedEvaluationOutputSchema();

        // Act
        var issues = schema.Validate();

        // Assert
        Assert.IsNotEmpty(issues);
        Assert.IsTrue(issues.Any(x => x.Contains("overall_level", StringComparison.Ordinal)));
        Assert.IsTrue(issues.Any(x => x.Contains("defensibility_summary", StringComparison.Ordinal)));
    }
}
