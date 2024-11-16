namespace Aoxe.UUIDv7.TestProject;

public class Uuid7GeneratorTests
{
    [Fact]
    public void GenerateUuid7_ShouldReturnValidUuid7()
    {
        var uuid = Uuid7Generator.GenerateUuid7();
        var bytes = uuid.ToByteArray();

        // Verify UUID version is 7 (upper 4 bits of byte 6)
        var version = (bytes[6] >> 4) & 0x0F;
        Assert.Equal(7, version);

        // Verify UUID variant is RFC 4122 (upper 2 bits of byte 8)
        var variant = (bytes[8] >> 6) & 0x03;
        Assert.Equal(2, variant);

        // Verify timestamp is within reasonable range
        var timestamp =
            ((long)bytes[0] << 40)
            | ((long)bytes[1] << 32)
            | ((long)bytes[2] << 24)
            | ((long)bytes[3] << 16)
            | ((long)bytes[4] << 8)
            | bytes[5];

        var currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        Assert.InRange(timestamp, currentTimestamp - 1000, currentTimestamp + 1000);
    }

    [Fact]
    public void GenerateUuid7_ShouldGenerateUniqueUuids()
    {
        Guid uuid1 = Uuid7Generator.GenerateUuid7();
        Guid uuid2 = Uuid7Generator.GenerateUuid7();

        Assert.NotEqual(uuid1, uuid2);
    }

    [Fact]
    public void ToId25_ShouldReturn26Characters()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        string id25 = uuid.ToId25();

        Assert.NotNull(id25);
        Assert.Equal(26, id25.Length);
    }

    [Fact]
    public void ToId25_ShouldContainValidBase32Characters()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        string id25 = uuid.ToId25();

        Assert.Matches("^[A-Z2-7]+$", id25);
    }

    [Fact]
    public void ToId22_ShouldReturn22Characters()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        string id22 = uuid.ToId22();

        Assert.NotNull(id22);
        Assert.Equal(22, id22.Length);
    }

    [Fact]
    public void ToId22_ShouldContainValidBase64UrlCharacters()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        string id22 = uuid.ToId22();

        Assert.Matches("^[A-Za-z0-9_-]+$", id22);
    }

    [Fact]
    public void Base32Encode_ShouldEncodeDataCorrectly()
    {
        byte[] data = { 0xDE, 0xAD, 0xBE, 0xEF };
        string encoded = data.ToBase32Encode();

        Assert.Equal("32W353Y", encoded);
    }
}
