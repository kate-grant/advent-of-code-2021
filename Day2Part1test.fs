namespace Day2
module Part1 =

    open System
    open System.IO
    open System.Text.RegularExpressions

    type public changeAcc = {mutable depth: int; mutable hPosition: int; arr: array<int>}
    type public mvmt = {movement : string; distance : int}

    let dataReader (filePath : string) =
        new StreamReader(Path.Join(__SOURCE_DIRECTORY__, filePath)) |> Array.unfold (fun strmrd -> 
        match strmrd.ReadLine() with
        | null -> strmrd.Dispose(); None 
        | str -> Some(str, strmrd);)


    let (|Regex|_|) input pattern =
       let m = Regex.Match(input, pattern)
       if (m.Success) then Some(List.tail [ for g in m.Groups -> g.Value ]) else None


    let mvmtParser (str : string) (acc : Map<string, int>) : Map<string, int> =
        let mvmtRec = (match str with
        | Regex @"forward\s(\d+)" [d] -> {movement = "horizontal"; distance = d |> int}
        | Regex @"up\s(\d+)" [d] -> {movement = "depth"; distance =(-(d |> int))}
        | Regex @"down\s(\d+)" [d] -> {movement = "depth"; distance = d |> int}
        | _ -> failwith "no match");

        if Map.containsKey mvmtRec.movement acc
        then
            acc |> Map.change mvmtRec.movement (fun k ->
            match k with
            | Some v -> Some (v + mvmtRec.distance);
            | None -> None);
            
            else acc;
 
    let mvmtTotaller (dataArr : array<string>) f =
        let mutable acc = Map [("depth", 0); ("horizontal", 0)];
        let totalledMap = Array.fold (fun x y -> f x y) acc dataArr;
        totalledMap.["depth"] * totalledMap.["horizontal"];


