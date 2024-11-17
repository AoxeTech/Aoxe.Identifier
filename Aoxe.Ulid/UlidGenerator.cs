namespace Aoxe.Ulid;

public static class UlidGenerator
{
    private const string EncodingChars = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
    private const int Length = 26;

    public static string NewUlid()
    {
        var bytes = new byte[16];

        // Get timestamp in milliseconds
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var timestampBytes = BitConverter.GetBytes(timestamp);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timestampBytes);
        }

        // Copy timestamp (first 6 bytes)
        Array.Copy(timestampBytes, timestampBytes.Length - 6, bytes, 0, 6);

        // Generate 10 random bytes
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(bytes, 6, 10);
        }

        // Encode to Crockford's Base32
        return Encode(bytes);
    }

    private static string Encode(byte[] data)
    {
        var sb = new StringBuilder(Length);
        var index = 0;
        var charCount = 0;

        while (charCount < Length)
        {
            switch (charCount % 8)
            {
                case 0:
                    sb.Append(EncodingChars[(data[index] >> 5) & 0x1F]);
                    sb.Append(EncodingChars[data[index] & 0x1F]);
                    index++;
                    break;
                case 2:
                    sb.Append(EncodingChars[(data[index] >> 3) & 0x1F]);
                    sb.Append(EncodingChars[((data[index] << 2) | (data[index + 1] >> 6)) & 0x1F]);
                    index++;
                    break;
                case 4:
                    sb.Append(EncodingChars[(data[index] >> 1) & 0x1F]);
                    sb.Append(EncodingChars[((data[index] << 4) | (data[index + 1] >> 4)) & 0x1F]);
                    index++;
                    break;
                case 6:
                    sb.Append(EncodingChars[((data[index] << 1) | (data[index + 1] >> 7)) & 0x1F]);
                    sb.Append(EncodingChars[(data[index + 1] >> 2) & 0x1F]);
                    index += 2;
                    break;
            }
            charCount += 2;
        }

        return sb.ToString();
    }
}
