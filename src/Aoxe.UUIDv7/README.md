# Aoxe.UUIDv7

Aoxe.UUIDv7 is a C# library for generating UUID version 7 identifiers based on the proposed RFC. It provides time-ordered UUIDs with improved sorting and uniqueness features.

- [1. Features](#1-features)
- [2. Installation](#2-installation)
- [3. Usage](#3-usage)
- [4. API Reference](#4-api-reference)
  - [4.1. `Uuid7Generator.GenerateUuid7()`](#41-uuid7generatorgenerateuuid7)
  - [4.2. `Uuid7Generator.ToId25(this Guid uuid)`](#42-uuid7generatortoid25this-guid-uuid)
  - [4.3. `Uuid7Generator.ToId22(this Guid uuid)`](#43-uuid7generatortoid22this-guid-uuid)
- [5. Contributing](#5-contributing)
- [6. License](#6-license)

## 1. Features

- Generate version 7 UUIDs.
- Convert UUIDs to shorter string representations.
- Optimized Base32 encoding.
- Includes unit tests using xUnit.

## 2. Installation

Install via NuGet Package Manager:

```bash
dotnet add package Aoxe.UUIDv7
```

Or via the Package Manager Console:

```powershell
Install-Package Aoxe.UUIDv7
```

## 3. Usage

```csharp
using Aoxe.UUIDv7;

class Program
{
    static void Main()
    {
        // Generate a UUIDv7
        Guid uuid = Uuid7Generator.GenerateUuid7();

        // Convert to a 25-character Base32 string
        string id25 = uuid.ToId25();

        // Convert to a 22-character Base64URL string
        string id22 = uuid.ToId22();

        Console.WriteLine($"UUIDv7: {uuid}");
        Console.WriteLine($"ID25: {id25}");
        Console.WriteLine($"ID22: {id22}");
    }
}
```

## 4. API Reference

### 4.1. `Uuid7Generator.GenerateUuid7()`

Generates a new UUID version 7.

### 4.2. `Uuid7Generator.ToId25(this Guid uuid)`

Converts a UUID to a 25-character Base32 encoded string.

### 4.3. `Uuid7Generator.ToId22(this Guid uuid)`

Converts a UUID to a 22-character Base64URL encoded string.

## 5. Contributing

Contributions are welcome. Please submit issues and pull requests for any improvements.

## 6. License

This project is licensed under the MIT License.
