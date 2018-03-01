open BenchmarkDotNet.Running
open CpsBenchmark

module Program = 

    let [<EntryPoint>] main _ = 
        BenchmarkRunner.Run<CpsPerformanceTests>() |> printfn "%A"
        System.Console.ReadKey() |> ignore
        0
