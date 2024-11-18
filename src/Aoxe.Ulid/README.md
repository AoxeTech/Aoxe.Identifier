# Aoxe.Ulid

A .NET implementation of the ULID (Universally Unique Lexicographically Sortable Identifier) generator.

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Aoxe.Ulid
```

Or via the Package Manager Console:

```powershell
Install-Package Aoxe.Ulid
```

## Usage

```csharp
using Aoxe.Ulid;

class Program
{
    static void Main()
    {
        // Generate a new ULID
        string ulid = UlidGenerator.NewUlid();

        Console.WriteLine($"Generated ULID: {ulid}");
    }
}
```

## API Reference

```csharp
UlidGenerator.NewUlid()
```

Generates a new ULID as a 26-character Crockford's Base32 encoded string.

## Contributing

Contributions are welcome. Please submit issues and pull requests for any improvements.

## License

This project is licensed under the MIT License.
