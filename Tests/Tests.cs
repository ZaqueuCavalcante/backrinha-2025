namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test()
    {
        var result = 1 + 1;
        result.ShouldBe(2);
    }
}
