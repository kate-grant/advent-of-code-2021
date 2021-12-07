namespace Day2
module Part1 =

    open System
    open System.IO
    open System.Text.RegularExpressions

    type public changeAcc = {mutable depth: int; mutable hPosition: int; arr: array<int>}
    type public mvmt = {movement : string; distance : int}

    let dataReaderString (filePath : string) =
        new StreamReader(Path.Join(__SOURCE_DIRECTORY__, filePath)) |> Array.unfold (fun strmrd -> 
        match strmrd.ReadLine() with
        | null -> strmrd.Dispose(); None 
        | str -> Some(str, strmrd);)


    let (|RegexGroup|_|) (pattern : string) (input : string)  =
       let m = Regex.Match(input, pattern)
       if (m.Success) then Some(List.tail [ for g in m.Groups -> g.Value ]) else None


    let mvmtParser  (acc : Map<string, int>) (str : string) : Map<string, int> =
        printf "%s\n" str;
        let mvmtRec = (match str with
                        | RegexGroup @"forward\s(\d)" [d] -> printfn "%s" d; {movement = "horizontal"; distance = d |> int}
                        | RegexGroup @"up\s(\d)" [d] -> printfn "%s" d; {movement = "depth"; distance =(-(d |> int))};
                        | RegexGroup @"down\s(\d)" [d] -> printfn "%s" d; {movement = "depth"; distance = d |> int};
                        | _ -> {movement = "horizontal"; distance = 0});
                        
        if Map.containsKey mvmtRec.movement acc
        then
            let acc = acc |> Map.change mvmtRec.movement (fun k ->
                match k with
                | Some v -> Some (v + mvmtRec.distance);
                | None -> None);
            acc;
            else acc;
        
 
    let mvmtTotaller (dataArr : array<string>) f : int =
        let mutable dInt = 0;
        let mutable hInt = 0;
        let mutable acc = Map [("depth", dInt); ("horizontal", hInt)];
        let totalledMap = Array.fold (fun x y -> f x y) acc dataArr;
        totalledMap.["depth"] * totalledMap.["horizontal"];


