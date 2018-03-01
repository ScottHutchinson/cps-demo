Example in F#: with corrected code formatting

A config example in F#:

```fs
module MyBenchmark

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Exporters
open BenchmarkDotNet.Exporters.Csv
open MyProjectUnderTest

type MyConfig() as this =
    inherit ManualConfig()
    do
        this.Add(CsvMeasurementsExporter.Default)
        this.Add(RPlotExporter.Default)

[<
  MemoryDiagnoser; 
  Config(typeof<MyConfig>);
  RPlotExporter
>]
type MyPerformanceTests() =

    let someTestData = getTestDataAsList ()

    [<Benchmark>]
    member __.SomeTestCase() = 
        someTestData |> myFunctionUnderTest
```
