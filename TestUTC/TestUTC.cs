using TimeFunctions;

namespace TestUTC;

public class ConvertToUtcTests
{
    [Test]
    [TestCase(2025, 3, 14, 20, 45, 0, DateTimeKind.Local)]
    [TestCase(2025, 4, 23, 21, 32, 43, DateTimeKind.Unspecified)]
    [TestCase(2025, 4, 23, 21, 32, 43, DateTimeKind.Utc)]
    public void OnlyDtParamTest(int year, int month, int day, int hour, int minut, int second, DateTimeKind kind)
    {
        DateTime dateTime = new(year, month, day, hour, minut, second, kind);
        hour = kind != DateTimeKind.Utc ? hour - 3 : hour;
        DateTime expected = new(year, month, day, hour, minut, second);

        DateTime result = TimeUTC.ConvertToUtc(dateTime);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(DateTimeKind.Local)]
    [TestCase(DateTimeKind.Unspecified)]
    [TestCase(DateTimeKind.Utc)]
    public void WithoutDtParamWithDefaultTest(DateTimeKind kind)
    {
        DateTime defaultTime = new(1, 1, 1, 1, 1, 1, kind);

        DateTime result = TimeUTC.ConvertToUtc(null, defaultTime);

        Assert.That(result, Is.EqualTo(defaultTime));
    }

    [Test]
    [TestCase(2025, 3, 14, 20, 45, 0, DateTimeKind.Local)]
    [TestCase(2025, 4, 23, 21, 32, 43, DateTimeKind.Unspecified)]
    [TestCase(2025, 4, 23, 21, 32, 43, DateTimeKind.Utc)]
    public void WithDtParamWithDefaultTest(int year, int month, int day, int hour, int minut, int second, DateTimeKind kind)
    {
        DateTime defaultTime = new(1, 1, 1, 1, 1, 1, kind);
        DateTime dateTime = new(year, month, day, hour, minut, second, kind);
        hour = kind != DateTimeKind.Utc ? hour - 3 : hour;
        DateTime expected = new(year, month, day, hour, minut, second);

        DateTime result = TimeUTC.ConvertToUtc(dateTime, defaultTime);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void NullableDateTimeTest()
    {
        DateTime dateTime = new();
        DateTime expected = new();

        DateTime result = TimeUTC.ConvertToUtc(dateTime);

        Assert.That(result, Is.EqualTo(expected));
    }
}