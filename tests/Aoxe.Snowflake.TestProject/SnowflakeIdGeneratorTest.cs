namespace Aoxe.Snowflake.TestProject;

public class SnowflakeIdGeneratorTest
{
    [Fact]
    public void Constructor_ValidWorkerIdAndDatacenterId_ShouldNotThrow()
    {
        var generator = new SnowflakeIdGenerator(1, 1);
        Assert.NotNull(generator);
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(32, 1)]
    [InlineData(1, -1)]
    [InlineData(1, 32)]
    public void Constructor_InvalidWorkerIdOrDatacenterId_ShouldThrowArgumentOutOfRangeException(
        long workerId,
        long datacenterId
    )
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new SnowflakeIdGenerator(workerId, datacenterId)
        );
    }

    [Fact]
    public void NextId_ShouldGenerateUniqueIds()
    {
        var generator = new SnowflakeIdGenerator(1, 1);
        var id1 = generator.NextId();
        var id2 = generator.NextId();

        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void NextId_ShouldGenerateIdsInIncreasingOrder()
    {
        var generator = new SnowflakeIdGenerator(1, 1);
        var id1 = generator.NextId();
        var id2 = generator.NextId();

        Assert.True(id2 > id1);
    }

    [Fact]
    public void WaitUntilNextMillis_ShouldWaitForNextMillisecond()
    {
        var generator = new SnowflakeIdGenerator(1, 1);

        // Simulate the sequence overflow
        generator
            .GetType()
            .GetField(
                "_sequence",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            )!
            .SetValue(generator, (1L << 12) - 1);

        var lastTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var nextTimestamp = generator
            .GetType()
            .GetMethod(
                "WaitUntilNextMillis",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
            )!
            .Invoke(generator, [lastTimestamp]);

        Assert.True((long)nextTimestamp! > lastTimestamp);
    }
}
