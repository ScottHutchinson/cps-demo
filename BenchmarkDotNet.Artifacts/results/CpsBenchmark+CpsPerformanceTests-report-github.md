``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core m3-7Y30 CPU 1.00GHz, 1 CPU, 4 logical cores and 2 physical cores
Frequency=1570314 Hz, Resolution=636.8153 ns, Timer=TSC
.NET Core SDK=2.1.4
  [Host]     : .NET Core 2.0.5 (Framework 4.6.26020.03), 64bit RyuJIT DEBUG
  DefaultJob : .NET Core 2.0.5 (Framework 4.6.26020.03), 64bit RyuJIT


```
|      Method |           Mean |         Error |        StdDev |     Gen 0 |     Gen 1 |    Gen 2 |   Allocated |
|------------ |---------------:|--------------:|--------------:|----------:|----------:|---------:|------------:|
|       Early | 172,125.805 us | 3,468.7303 us | 8,891.6818 us | 6312.5000 | 3312.5000 | 437.5000 | 35865.19 KB |
|    EarlyCPS |       3.860 us |     0.0766 us |     0.0883 us |    2.9221 |         - |        - |     5.99 KB |
|        Late | 173,990.992 us | 3,454.6796 us | 9,040.2945 us | 6437.5000 | 3437.5000 | 562.5000 | 35865.67 KB |
|     LateCPS | 170,834.972 us | 3,406.7016 us | 7,619.5763 us | 6437.5000 | 3312.5000 | 625.0000 | 35459.65 KB |
|    NotFound | 169,934.681 us | 3,389.4392 us | 9,559.9733 us | 6625.0000 | 3625.0000 | 750.0000 | 35865.19 KB |
| NotFoundCPS |  60,539.012 us |   657.6858 us |   615.1997 us | 3187.5000 | 1312.5000 | 250.0000 | 17932.62 KB |
