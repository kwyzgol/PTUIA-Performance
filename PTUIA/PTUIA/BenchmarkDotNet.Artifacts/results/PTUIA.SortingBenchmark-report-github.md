``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=3.1.302
  [Host]     : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT
  DefaultJob : .NET Core 3.1.6 (CoreCLR 4.700.20.26901, CoreFX 4.700.20.31603), X64 RyuJIT


```
|              Method |    Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated | Allocated native memory | Native memory leak |
|-------------------- |--------:|---------:|---------:|------:|------:|------:|----------:|------------------------:|-------------------:|
|  QuickSortBenchmark | 2.090 s | 0.0134 s | 0.0125 s |     - |     - |     - |     117 B |                  4391 B |             4136 B |
| BubbleSortBenchmark | 3.159 s | 0.0115 s | 0.0090 s |     - |     - |     - |         - |                  2568 B |              652 B |
