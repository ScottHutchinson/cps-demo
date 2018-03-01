module CpsDemoTest

open Xunit
open FsUnit.Xunit
open CpsDemo
open CpsBenchmark

let objUnderTest = CpsPerformanceTests()
let allTheWordsEarly = getAllTheWordsAsList @"\Les Misérables Early.txt"
let allTheWordsLate = getAllTheWordsAsList @"\Les Misérables Late.txt"

[<Fact>]
let ``replaceFirstItem "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
    objUnderTest.Early () |> should equal allTheWordsEarly

[<Fact>]
let ``replaceFirstItemCPS "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
    objUnderTest.EarlyCPS () |> should equal allTheWordsEarly

[<Fact>]
let ``replaceFirstItemAvm1 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
    objUnderTest.EarlyAvm1 () |> should equal allTheWordsEarly

[<Fact>]
let ``replaceFirstItemAvm2 "MISÉRABLES" "PERSONNES-CONTENUES"`` () =
    objUnderTest.EarlyAvm2 () |> should equal allTheWordsEarly

[<Fact>]
let ``replaceFirstItem "lichens" "BANANAS"`` () =
    objUnderTest.Late () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItemCPS "lichens" "BANANAS"`` () =
    objUnderTest.LateCPS () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItemAvm1 "lichens" "BANANAS"`` () =
    objUnderTest.LateAvm1 () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItemAvm2 "lichens" "BANANAS"`` () =
    objUnderTest.LateAvm2 () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFound () |> should equal allTheWords

[<Fact>]
let ``replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFoundCPS () |> should equal allTheWords

[<Fact>]
let ``replaceFirstItemAvm1 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFoundAvm1 () |> should equal allTheWords

[<Fact>]
let ``replaceFirstItemAvm2 "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFoundAvm2 () |> should equal allTheWords
