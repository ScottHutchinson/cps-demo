module CpsDemo

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

let replaceFirstItemAvm1 itm rep lst =
    let rec iter acc lst =
        match lst with
        | [] -> List.rev acc
        | h :: t ->
            if h = itm then
                (List.rev acc) @ [rep] @ t
            else
                iter (h :: acc) t

    iter [] lst

let replaceFirstItemAvm2 itm rep lst =
    let rec iter acc lst =
        match lst with
        | [] -> List.rev acc
        | h :: t ->
            if h = itm then
                ((rep :: acc) |> List.rev) @ t
            else
                iter (h :: acc) t

    iter [] lst

let load filePath =
    filePath
    |> File.ReadAllLines

let words line= Regex.Matches(line, "\w+(-\w+)?") |> Seq.cast |> Seq.map (fun (x:Match) -> x.Value)

let getAllWordsSeq lines =
    seq { for line in lines do
            yield! words line
    }

let getAllTheWordsAsList fileName =
    // https://www.gutenberg.org/files/135/135-0.txt (Les Mis�rables by Victor Hugo)
    let lines = load (__SOURCE_DIRECTORY__ + fileName)
    let allWords = getAllWordsSeq lines
    printfn "Number of lines read from file: %i" lines.Length
    printfn "Number of words read from file: %i" (Seq.length allWords)
    // allWords |> Seq.take 1000 |> Seq.iter (fun w -> printfn "%s" w)
    allWords
    |> List.ofSeq

let allTheWords = getAllTheWordsAsList @"\Les Misérables.txt"
