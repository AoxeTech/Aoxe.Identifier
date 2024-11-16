namespace Aoxe.UUIDv7;

public static class Uuid7Extension
{
    public static string ToId25(this Guid uuid)
    {
        var bytes = uuid.ToByteArray();
        return bytes.ToBase32Encode();
    }

    public static string ToId22(this Guid uuid)
    {
        var bytes = uuid.ToByteArray();
        return Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
    }

    public static string ToBase32Encode(this byte[] data)
    {
        const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        var outputLength = (int)Math.Ceiling(data.Length * 8 / 5.0);
        var result = new char[outputLength];
        int buffer = data[0];
        var next = 1;
        var bitsLeft = 8;
        var index = 0;

        while (index < outputLength)
        {
            if (bitsLeft < 5)
            {
                if (next < data.Length)
                {
                    buffer = (buffer << 8) | data[next++];
                    bitsLeft += 8;
                }
                else
                {
                    buffer <<= (5 - bitsLeft);
                    bitsLeft = 5;
                }
            }

            var digit = (buffer >> (bitsLeft - 5)) & 0x1F;
            bitsLeft -= 5;
            result[index++] = base32Chars[digit];
        }

        return new string(result);
    }
}
