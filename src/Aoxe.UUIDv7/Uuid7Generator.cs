namespace Aoxe.UUIDv7;

public static class Uuid7Generator
{
    public static Guid GenerateUuid7()
    {
        var guidBytes = new byte[16];

        // Get current Unix time in milliseconds
        var unixTimeMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // First 6 bytes are the timestamp
        guidBytes[0] = (byte)(unixTimeMs >> 40);
        guidBytes[1] = (byte)(unixTimeMs >> 32);
        guidBytes[2] = (byte)(unixTimeMs >> 24);
        guidBytes[3] = (byte)(unixTimeMs >> 16);
        guidBytes[4] = (byte)(unixTimeMs >> 8);
        guidBytes[5] = (byte)(unixTimeMs);

        // Generate random bytes for bytes 6-15
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(guidBytes, 6, 10);
        }

        // Set the UUID version to 7 (upper 4 bits of byte 6)
        guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | 0x70);

        // Set the UUID variant to RFC 4122 (upper 2 bits of byte 8)
        guidBytes[8] = (byte)((guidBytes[8] & 0x3F) | 0x80);

        return new Guid(guidBytes);
    }
}
