namespace Aoxe.UUIDv7.TestProject;

public class UnitTest1
{
    [Fact]
    public void GenerateUuid7_ShouldHaveVersion7()
    {
        var uuid = Uuid7Generator.GenerateUuid7();
        var version = (uuid.ToByteArray()[6] >> 4) & 0x0F;
        Assert.Equal(7, version);
    }

    [Fact]
    public void GenerateUuid7_ShouldHaveRFC4122Variant()
    {
        var uuid = Uuid7Generator.GenerateUuid7();
        var variant = (uuid.ToByteArray()[8] >> 6) & 0x03;
        Assert.Equal(2, variant);
    }

    [Fact]
    public void GenerateUuid7_ShouldGenerateUniqueGuids()
    {
        var uuids = Enumerable.Range(0, 1000).Select(_ => Uuid7Generator.GenerateUuid7()).ToList();
        var distinctCount = uuids.Distinct().Count();
        Assert.Equal(1000, distinctCount);
    }
}
