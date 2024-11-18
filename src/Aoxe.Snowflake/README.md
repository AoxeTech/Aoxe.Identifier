# Aoxe.Snowflake

A .NET implementation of the Snowflake ID generator.

- [1. Installation](#1-installation)
- [2. Usage](#2-usage)
- [3. API Reference](#3-api-reference)
- [4. Contributing](#4-contributing)
- [5. License](#5-license)

---

## 1. Installation

Install via NuGet Package Manager:

```bash
dotnet add package Aoxe.Snowflake
```

Or via the Package Manager Console:

```powershell
Install-Package Aoxe.Snowflake
```

## 2. Usage

```csharp
using Aoxe.Snowflake;

class Program
{
    static void Main()
    {
        // Initialize the generator with a worker ID and datacenter ID
        var generator = new SnowflakeIdGenerator(workerId: 1, datacenterId: 1);

        // Generate a unique ID
        long id = generator.NextId();

        Console.WriteLine($"Generated Snowflake ID: {id}");
    }
}
```

## 3. API Reference

```csharp
SnowflakeIdGenerator(long workerId, long datacenterId)
```

Creates a new instance of the 'SnowflakeIdGenerator' with the specified worker ID and datacenter ID.

- workerId: The worker ID (0 to 31)
- datacenterId: The datacenter ID (0 to 31)

```csharp
long NextId()
```

Generates the next unique Snowflake ID.

## 4. Contributing

Contributions are welcome. Please submit issues and pull requests for any improvements.

## 5. License

This project is licensed under the MIT License.
