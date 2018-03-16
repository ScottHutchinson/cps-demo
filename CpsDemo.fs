module CpsDemo

open System.Collections.Generic
open System.IO
open System.Text.RegularExpressions

let replaceFirstItem itm replacement list =
    let rec replace isFound acc lst =
       match lst with
       | [] ->
           if isFound then
                acc |> List.rev
           else
                list
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

// The functions below (with an Avm# suffix) were developed by André van Meulebrouck <vanmeule@roadrunner.com>
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

let inline revCons x y = List.fold ( fun acc x -> x :: acc) y x

let replaceFirstItemAvm3 itm rep lst =
    let rec iter acc lst =
        match lst with
        | [] -> List.rev acc
        | h :: t ->
            if h = itm then
                revCons acc (rep :: t)
            else
                iter (h :: acc) t
    iter [] lst

let replaceFirstItemAvm4 itm rep lst =
    if List.contains itm lst then
        let rec iter acc lst =
            match lst with
            | [] -> List.rev acc
            | h :: t ->
                if h = itm then
                    revCons acc (rep :: t)
                else
                    iter (h :: acc) t
        iter [] lst
    else lst

let replaceFirstItemAvm5 itm rep lst =
    match lst |> List.tryFindIndex ((=) itm)  with
    | None -> lst
    | Some x ->
        let splt = lst |> List.splitAt x
        (fst splt) @ (rep :: (List.tail (snd splt)))

let replaceFirstItemAvm6 itm rep lst =
    match lst |> List.tryFindIndex ((=) itm) with
    | None -> lst
    | Some x ->
        (lst |> (List.take x)) @ (rep :: (lst |> (List.skip (x + 1))))

let replaceFirstItemAvm7 itm rep lst = //version 7
    let rec iter acc lst fnd =
        match lst with
        | [] -> List.rev acc
        | h :: t ->
            if not fnd && h = itm then
                iter (rep :: acc) t true
            else
                iter (h :: acc) t fnd
    iter [] lst false

let replaceFirstItemAvm8 itm rep lst = //version 8 (attempt optimal late case, see if List.fold isn't tail recursive)
    let rec iter acc lst =
        match lst with
            | [] -> List.rev acc
            | h :: t ->
                if h = itm then
                    let rec iter2 acc lst = //reverse cons to rest of list
                        match lst with
                            | [] -> acc
                            | h :: t -> iter2 (h :: acc) t

                    iter2 (rep :: t) acc
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

let memoize f =
    let dict = Dictionary<_, _>()
    fun x ->
        match dict.TryGetValue x with
            | true, value ->
                printfn "Words retrieved from cache: %s" x
                value
            | _           ->
                let f_x = f x
                dict.Add (x, f_x)
                f_x

let getAllTheWordsAsList fileName =
    // https://www.gutenberg.org/files/135/135-0.txt (Les Mis�rables by Victor Hugo)
    let lines = load (__SOURCE_DIRECTORY__ + fileName)
    let allWords = getAllWordsSeq lines
    // printfn "Number of lines read from file: %i" lines.Length
    printfn "Number of words read from file: %i" (Seq.length allWords)
    // allWords |> Seq.take 1000 |> Seq.iter (fun w -> printfn "%s" w)
    allWords
    |> List.ofSeq

let mgetAllTheWordsAsList = memoize getAllTheWordsAsList
let allTheWords = mgetAllTheWordsAsList @"\Les Misérables.txt"
