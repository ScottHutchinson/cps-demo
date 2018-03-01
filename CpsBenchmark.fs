module CpsBenchmark

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Exporters
open BenchmarkDotNet.Exporters.Csv
open CpsDemo

type CpsConfig() as this =
    inherit ManualConfig()
    do
        this.Add(CsvMeasurementsExporter.Default)
        this.Add(RPlotExporter.Default)

[<
  MemoryDiagnoser; 
  Config(typeof<CpsConfig>);
  RPlotExporter
>]
type CpsPerformanceTests() =

    let allTheWords = getAllTheWordsAsList @"\Les Misérables.txt"

    [<Benchmark>]
    member __.Early() = 
        allTheWords |> replaceFirstItem "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyCPS() = 
        allTheWords |> replaceFirstItemCPS "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.Late() = 
        allTheWords |> replaceFirstItem "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateCPS() = 
        allTheWords |> replaceFirstItemCPS "lichens" "BANANAS"

    [<Benchmark>]
    member __.NotFound() = 
        allTheWords |> replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundCPS() = 
        allTheWords |> replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS"