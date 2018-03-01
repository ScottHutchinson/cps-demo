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
let ``replaceFirstItem "lichens" "BANANAS"`` () =
    objUnderTest.Late () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItemCPS "lichens" "BANANAS"`` () =
    objUnderTest.LateCPS () |> should equal allTheWordsLate

[<Fact>]
let ``replaceFirstItem "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFound () |> should equal allTheWords

[<Fact>]
let ``replaceFirstItemCPS "aWordThatNeverOccursInLesMisérables" "BANANAS"`` () =
    objUnderTest.NotFoundCPS () |> should equal allTheWords