#I __SOURCE_DIRECTORY__ // Add the script file location to the include file path.

open System.IO
open System.Text.RegularExpressions

let replaceFirstItem itm replacement list =
   let rec replace isFound acc lst =
       match lst with
       | [] -> acc |> List.rev
       | h :: t  when h = itm ->
           if isFound then
               replace true (h :: acc) t
           else
               replace true (replacement :: acc) t
       | h :: t -> replace isFound (h :: acc) t
   
   replace false [] list

// let testList = [ 1; 4; 6; 4; 7 ]
// let test = testList |> replaceFirstItem 4 42

let replaceFirstItemCPS itm replacement list =
    let rec replace cont lst =
        match lst with
        | [] -> list
        | h :: t when h = itm -> replacement :: t |> cont
        | h :: t -> replace (fun t' -> h :: t' |> cont) t

    replace id list

let load filePath =
    filePath
    |> File.ReadAllLines

let words line= Regex.Matches(line, "\w+(-\w+)?") |> Seq.cast |> Seq.map (fun (x:Match) -> x.Value)

let getAllWordsSeq lines =
    seq { for line in lines do
            yield! words line
    }

let getAllTheWordsAsList () =
    // https://www.gutenberg.org/files/135/135-0.txt (Les Mis�rables by Victor Hugo)
    let lines = load (__SOURCE_DIRECTORY__ + @"\Les Misérables.txt")
    let allWords = getAllWordsSeq lines
    printfn "Number of lines read from file: %i" lines.Length
    printfn "Number of words read from file: %i" (Seq.length allWords)
    // allWords |> Seq.take 1000 |> Seq.iter (fun w -> printfn "%s" w)
    allWords
    |> List.ofSeq

let allTheWords = getAllTheWordsAsList ()

let repeat f item replacement list =
    [1..20] |> List.iter (fun _ -> f item replacement list |> ignore)

let needle = "MISÉRABLES" // occurs near the beginning of the file
printfn "1. replaceFirstItem with needle = '%s'" needle
#time
allTheWords |> repeat replaceFirstItem needle "PERSONNES-CONTENUES"
#time

printfn "1.CPS. replaceFirstItemCPS with needle = '%s'" needle
#time
allTheWords |> repeat replaceFirstItemCPS needle "PERSONNES-CONTENUES"
#time

let needle2 = "lichens" // occurs in the last chapter of the book/file
printfn "2. replaceFirstItem with needle = '%s'" needle2
#time
allTheWords |> repeat replaceFirstItem needle2 "BANANAS"
#time

printfn "2.CPS. replaceFirstItemCPS with needle = '%s'" needle2
#time
allTheWords |> repeat replaceFirstItemCPS needle2 "BANANAS"
#time

let needle3 = "aWordThatNeverOccursInLesMisérables"
printfn "3. replaceFirstItem with needle = '%s'" needle3
#time
allTheWords |> repeat replaceFirstItem needle3 "BANANAS"
#time

printfn "3.CPS. replaceFirstItemCPS with needle = '%s'" needle3
#time
allTheWords |> repeat replaceFirstItemCPS needle3 "BANANAS"
#time

printfn "Done."

let memoize f =
    fun x ->
        let f_x = f x
        f_x


type Constraint<'a> =
    | NotNull
    | Unique
    | PrimaryKey
    | Check of ('a -> bool)
    