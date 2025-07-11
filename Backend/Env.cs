namespace Backend;

public static class Env
{
    private static string Testing = nameof(Testing);
    private static string Development = nameof(Development);

    public static void SetAsTesting()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", Testing);
    }
}
