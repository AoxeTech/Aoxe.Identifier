# Aoxe.Identifier# Aoxe.Identifier

A collection of .NET implementations for generating unique identifiers.

## Overview

This solution contains implementations for various unique identifier algorithms:

- **Aoxe.SequentialGuid**: Generates sequential GUIDs suitable for database indexing.
- **Aoxe.Snowflake**: Implementation of the Snowflake algorithm for generating unique 64-bit integers.
- **Aoxe.Ulid**: Generates ULIDs (Universally Unique Lexicographically Sortable Identifiers).
- **Aoxe.UUIDv7**: Implementation of UUID version 7.

## Project Structure

- **Aoxe.Identifier.sln**: The main solution file.
- **src**: Contains the source code for each identifier implementation.
  - **Aoxe.SequentialGuid/**: Sequential GUID implementation.
  - **Aoxe.Snowflake/**: Snowflake algorithm implementation.
  - **Aoxe.Ulid/**: ULID implementation.
  - **Aoxe.UUIDv7/**: UUIDv7 implementation.
- **tests**: Contains test projects for each implementation.
  - **Aoxe.SequentialGuid.TestProject/**: Tests for Sequential GUID.
  - **Aoxe.Snowflake.TestProject/**: Tests for Snowflake.
  - **Aoxe.UUIDv7.TestProject/**: Tests for UUIDv7.
  - **Aoxe.Ulid.TestProject/**: Test project for ULID implementation.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed.

### Building the Solution

To build the solution, run:

```bash
dotnet build Aoxe.Identifier.sln
```

### Running Tests

To run all unit tests, execute:

```bash
dotnet test Aoxe.Identifier.sln
```

## Usage

### ULID Generation

Use the `UlidGenerator` class in Aoxe.Ulid:

```csharp
var ulid = UlidGenerator.NewUlid();
Console.WriteLine(ulid);
```

### Snowflake ID Generation

Use the `SnowflakeGenerator` class in Aoxe.Snowflake:

```csharp
var generator = new SnowflakeIdGenerator(1, 1);
var snowflakeId = generator.NextId();
Console.WriteLine(snowflakeId);
```

### Sequential GUID Generation

Use the `SequentialGuidGenerator` class in Aoxe.SequentialGuid:

```csharp
var sequentialGuid = SequentialGuidGenerator.NewGuid();
Console.WriteLine(sequentialGuid);
```

### UUIDv7 Generation

Use the `Uuid7Generator` class in Aoxe.UUIDv7:

```csharp
var uuid7 = Uuid7Generator.NewUuid7();
Console.WriteLine(uuid7);
```

## License

This project is licensed under the MIT License.
