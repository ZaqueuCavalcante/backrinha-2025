using System.Net;

namespace Syki.Tests.Integration;

public partial class IntegrationTests : IntegrationTestBase
{
    [Test]
    public async Task Should_post_payment()
    {
        // Arrange
        var client = _backend.GetClient();

        // Act
        var response = await client.PostPayment(Guid.CreateVersion7(), 1.50M);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}
