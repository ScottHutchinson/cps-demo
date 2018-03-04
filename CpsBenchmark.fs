module CpsBenchmark

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Configs
open BenchmarkDotNet.Exporters
open BenchmarkDotNet.Exporters.Csv
open CpsDemo
open BenchmarkDotNet.Attributes.Jobs

type CpsConfig() as this =
    inherit ManualConfig()
    do
        this.Add(CsvMeasurementsExporter.Default)
        this.Add(RPlotExporter.Default)

[<
  MemoryDiagnoser; 
  Config(typeof<CpsConfig>);
  RPlotExporter;
//   ShortRunJob
>]
type CpsPerformanceTests() =

    let mutable allTheWords = []

    [<GlobalSetup>]
    member __.Setup() =
        allTheWords <- mgetAllTheWordsAsList @"\Les Misérables.txt"
        
    [<Benchmark>]
    member __.Early() = 
        allTheWords |> replaceFirstItem "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyCPS() = 
        allTheWords |> replaceFirstItemCPS "MISÉRABLES" "PERSONNES-CONTENUES"

    // [<Benchmark>]
    member __.EarlyAvm1() = 
        allTheWords |> replaceFirstItemAvm1 "MISÉRABLES" "PERSONNES-CONTENUES"

    // [<Benchmark>]
    member __.EarlyAvm2() = 
        allTheWords |> replaceFirstItemAvm2 "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyAvm3() = 
        allTheWords |> replaceFirstItemAvm3 "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyAvm4() = 
        allTheWords |> replaceFirstItemAvm4 "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyAvm7() = 
        allTheWords |> replaceFirstItemAvm7 "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.EarlyAvm8() = 
        allTheWords |> replaceFirstItemAvm8 "MISÉRABLES" "PERSONNES-CONTENUES"

    [<Benchmark>]
    member __.Late() = 
        allTheWords |> replaceFirstItem "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateCPS() = 
        allTheWords |> replaceFirstItemCPS "lichens" "BANANAS"

    // [<Benchmark>]
    member __.LateAvm1() = 
        allTheWords |> replaceFirstItemAvm1 "lichens" "BANANAS"

    // [<Benchmark>]
    member __.LateAvm2() = 
        allTheWords |> replaceFirstItemAvm2 "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateAvm3() = 
        allTheWords |> replaceFirstItemAvm3 "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateAvm4() = 
        allTheWords |> replaceFirstItemAvm4 "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateAvm7() = 
        allTheWords |> replaceFirstItemAvm7 "lichens" "BANANAS"

    [<Benchmark>]
    member __.LateAvm8() = 
        allTheWords |> replaceFirstItemAvm8 "lichens" "BANANAS"

    [<Benchmark>]
    member __.NotFound() = 
        allTheWords |> replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundCPS() = 
        allTheWords |> replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS"

    // [<Benchmark>]
    member __.NotFoundAvm1() = 
        allTheWords |> replaceFirstItemAvm1 "aWordThatNeverOccursInLesMisérables" "BANANAS"

    // [<Benchmark>]
    member __.NotFoundAvm2() = 
        allTheWords |> replaceFirstItemAvm2 "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundAvm3() = 
        allTheWords |> replaceFirstItemAvm3 "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundAvm4() = 
        allTheWords |> replaceFirstItemAvm4 "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundAvm7() = 
        allTheWords |> replaceFirstItemAvm7 "aWordThatNeverOccursInLesMisérables" "BANANAS"

    [<Benchmark>]
    member __.NotFoundAvm8() = 
        allTheWords |> replaceFirstItemAvm8 "aWordThatNeverOccursInLesMisérables" "BANANAS"
