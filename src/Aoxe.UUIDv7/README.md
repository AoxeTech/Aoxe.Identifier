# Aoxe.UUIDv7

Aoxe.UUIDv7 is a .NET library for generating UUID version 7 (time-ordered) compliant GUIDs. It combines the current Unix timestamp in milliseconds with random components to ensure uniqueness and orderability.

## Features

- **UUID Version 7**: Generates time-ordered UUIDs as per the latest specifications.
- **RFC 4122 Variant**: Ensures the UUID conforms to the standard variant.
- **Uniqueness**: Guarantees the generation of unique GUIDs.
- ** Easy Integration**: Simple API for seamless integration into your projects.

## Installation

Install the package via NuGet:

```bash
dotnet add package Aoxe.UUIDv7
```

## Usage

```csharp
using Aoxe.UUIDv7;
using System;

class Program
{
    static void Main()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        Console.WriteLine(uuid);
    }
}
```

## Running Tests

The project includes unit tests using XUnit. To run the tests, execute the following command in the project directory:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.

# Aoxe.UUIDv7

Aoxe.UUIDv7 is a .NET library for generating UUID version 7 (time-ordered) compliant GUIDs. It combines the current Unix timestamp in milliseconds with random components to ensure uniqueness and orderability.

## Features

- **UUID Version 7**: Generates time-ordered UUIDs as per the latest specifications.
- **RFC 4122 Variant**: Ensures the UUID conforms to the standard variant.
- **Uniqueness**: Guarantees the generation of unique GUIDs.
- **Easy Integration**: Simple API for seamless integration into your projects.

## Installation

Install the package via NuGet:

```bash
dotnet add package Aoxe.UUIDv7
```

## Usage

```csharp
using Aoxe.UUIDv7;
using System;

class Program
{
    static void Main()
    {
        Guid uuid = Uuid7Generator.GenerateUuid7();
        Console.WriteLine(uuid);
    }
}
```

## Running Tests

The project includes unit tests using NUnit. To run the tests, execute the following command in the project directory:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.