module CpsDemoTest

open FsUnit.Xunit
open CpsDemo

open System.Diagnostics
open Xunit
open Xunit.Abstractions

type Listener(output: ITestOutputHelper) =
    inherit TraceListener()
    override __.Write(message: string) =
        output.WriteLine(message)
    override __.WriteLine(message: string) =
        output.WriteLine(message)

type Tests(helper: ITestOutputHelper) =
    do
        Trace.Listeners.Add(new Listener(helper)) |> ignore

    let getAllTheWords file = 
        let lst = mgetAllTheWordsAsList file
        let traceMsg = sprintf "Number of words read from %s: %i" file (List.length lst)
        Trace.WriteLine traceMsg
        lst

    let allTheWords = getAllTheWords @"\Les Misérables.txt"
    let allTheWordsEarly = getAllTheWords @"\Les Misérables Early.txt"
    let allTheWordsLate = getAllTheWords @"\Les Misérables Late.txt"

    [<Fact>]
    let ``replaceFirstItem "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItem "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemCPS "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemCPS "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm1 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm1 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm2 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm2 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm3 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm3 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm4 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm4 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm5 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm5 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItemAvm6 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
        allTheWords |> replaceFirstItemAvm6 "MISÉRABLES" "PERSONNES-CONTENUES" |> should equal allTheWordsEarly

    [<Fact>]
    let ``replaceFirstItem "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItem "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemCPS "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemCPS "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm1 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm1 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm2 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm2 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm3 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm3 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm4 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm4 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm5 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm5 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItemAvm6 "lichens" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm6 "lichens" "BANANAS" |> should equal allTheWordsLate

    [<Fact>]
    let ``replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm1 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm1 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm2 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm2 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm3 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm3 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm4 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm4 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm5 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm5 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords

    [<Fact>]
    let ``replaceFirstItemAvm6 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
        allTheWords |> replaceFirstItemAvm6 "aWordThatNeverOccursInLesMisérables" "BANANAS" |> should equal allTheWords
