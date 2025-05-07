![coverage](coverage.svg)


```
BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5737/22H2/2022Update)
Intel Core i7-7700K CPU 4.20GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
```
| Method           | Mean         | Error      | StdDev     | Median       | Gen0   | Allocated |
|----------------- |-------------:|-----------:|-----------:|-------------:|-------:|----------:|
| ToSteamId64      |     1.856 ns |  0.0620 ns |  0.0637 ns |     1.828 ns |      - |         - |
| ToSteamId3       |    34.587 ns |  0.6855 ns |  0.6077 ns |    34.398 ns | 0.0134 |      56 B |
| ToSteamId        |    38.042 ns |  0.2285 ns |  0.1908 ns |    38.019 ns | 0.0153 |      64 B |
| SteamId_Parse    | 1,364.861 ns | 14.1719 ns | 11.0645 ns | 1,362.425 ns | 0.0534 |     224 B |
| SteamId3_Parse   |   588.827 ns | 11.5892 ns | 24.1909 ns |   578.322 ns | 0.0534 |     224 B |
| SteamId64_Parses |   521.191 ns |  4.6759 ns |  4.1451 ns |   521.116 ns | 0.0095 |      40 B |