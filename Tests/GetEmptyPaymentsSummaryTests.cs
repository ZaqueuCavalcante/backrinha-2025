namespace Syki.Tests.Integration;

public class GetEmptyPaymentsSummaryTests : IntegrationTestBase
{
    [Test]
    public async Task Should_get_empty_payments_summary()
    {
        // Arrange
        var client = _backend.GetClient();
        var now = DateTime.UtcNow;

        // Act
        var response = await client.GetPaymentsSummary(now.AddMinutes(-1), now.AddMinutes(1));

        // Assert
        response.Default.TotalRequests.ShouldBe(0);
        response.Default.TotalAmount.ShouldBe(0);
        response.Default.TotalRequests.ShouldBe(0);
        response.Default.TotalAmount.ShouldBe(0);
    }
}
