namespace Aoxe.UUIDv7;

public static class Uuid7Generator
{
    /// <summary>
    /// Generates a UUID version 7 (time-ordered) UUID as per the latest proposals.
    /// Combines the current Unix timestamp in milliseconds with random components.
    /// </summary>
    /// <returns>A UUIDv7 as a Guid object.</returns>
    public static Guid GenerateUuid7()
    {
        var guidBytes = new byte[16];
        var unixTimeMillis = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        // Insert timestamp (48 bits) into the first 6 bytes (big-endian)
        guidBytes[0] = (byte)(unixTimeMillis >> 40);
        guidBytes[1] = (byte)(unixTimeMillis >> 32);
        guidBytes[2] = (byte)(unixTimeMillis >> 24);
        guidBytes[3] = (byte)(unixTimeMillis >> 16);
        guidBytes[4] = (byte)(unixTimeMillis >> 8);
        guidBytes[5] = (byte)unixTimeMillis;

        // Set the UUID version to 7 (4 bits)
        guidBytes[6] = (byte)((guidBytes[6] & 0x0F) | (7 << 4));

        // Generate random bytes for bytes7-15 in a single call
        using (var rng = RandomNumberGenerator.Create())
            rng.GetBytes(guidBytes, 7, 9);

        // Set the UUID variant to RFC 4122 (10xx)
        guidBytes[8] = (byte)((guidBytes[8] & 0x3F) | 0x80);

        return new Guid(guidBytes);
    }
}
