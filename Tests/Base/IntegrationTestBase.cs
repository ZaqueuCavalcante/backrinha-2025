namespace Tests.Base;

public class IntegrationTestBase
{
    protected BackendFactory _backend = null!;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Env.SetAsTesting();

        _backend = new BackendFactory();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _backend.DisposeAsync();
    }
}
