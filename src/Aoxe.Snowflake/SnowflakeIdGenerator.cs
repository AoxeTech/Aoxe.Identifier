namespace Aoxe.Snowflake;

public class SnowflakeIdGenerator
{
    private const long Twepoch = 1288834974657L;

    private const int WorkerIdBits = 5;
    private const int DatacenterIdBits = 5;
    private const int SequenceBits = 12;

    private const long MaxWorkerId = (1L << WorkerIdBits) - 1;
    private const long MaxDatacenterId = (1L << DatacenterIdBits) - 1;

    private const int WorkerIdShift = SequenceBits;
    private const int DatacenterIdShift = SequenceBits + WorkerIdBits;
    private const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;

    private const long SequenceMask = (1L << SequenceBits) - 1;

    private long _lastTimestamp = -1L;
    private long _sequence;

    public long WorkerId { get; }
    public long DatacenterId { get; }

    public SnowflakeIdGenerator(long workerId, long datacenterId)
    {
        if (workerId is < 0 or > MaxWorkerId)
            throw new ArgumentOutOfRangeException(
                nameof(workerId),
                $"WorkerId must be between 0 and {MaxWorkerId}"
            );

        if (datacenterId is < 0 or > MaxDatacenterId)
            throw new ArgumentOutOfRangeException(
                nameof(datacenterId),
                $"DatacenterId must be between 0 and {MaxDatacenterId}"
            );

        WorkerId = workerId;
        DatacenterId = datacenterId;
    }

    public long NextId()
    {
        var timestamp = GetCurrentTimestamp();

        if (timestamp < _lastTimestamp)
        {
            // Wait until the clock moves forward
            timestamp = WaitUntilNextMillis(_lastTimestamp);
        }

        if (_lastTimestamp == timestamp)
        {
            // Increment sequence within the same millisecond
            _sequence = (_sequence + 1) & SequenceMask;
            if (_sequence == 0)
            {
                // Sequence overflow, wait until next millisecond
                timestamp = WaitUntilNextMillis(_lastTimestamp);
            }
        }
        else
        {
            // Reset sequence for a new millisecond
            _sequence = 0;
        }

        _lastTimestamp = timestamp;

        return ((timestamp - Twepoch) << TimestampLeftShift)
            | (DatacenterId << DatacenterIdShift)
            | (WorkerId << WorkerIdShift)
            | _sequence;
    }

    private long WaitUntilNextMillis(long lastTimestamp)
    {
        var timestamp = GetCurrentTimestamp();
        while (timestamp <= lastTimestamp)
        {
            timestamp = GetCurrentTimestamp();
        }
        return timestamp;
    }

    private static long GetCurrentTimestamp()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }
}
