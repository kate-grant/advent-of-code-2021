namespace Day1
module Part2 =

    open System
    open System.IO

    type public changeAcc = {mutable indexCount: int; mutable increaseCount: int; arr: array<int>}

    let dataReader (filePath : string) =
        new StreamReader(Path.Join(__SOURCE_DIRECTORY__, filePath)) |> Array.unfold (fun strmrd -> 
        match strmrd.ReadLine() with
        | null -> strmrd.Dispose(); None 
        | str -> Some(str |> int, strmrd);)

    let yIsGreater (x : changeAcc) (y : int) : changeAcc =
        if x.indexCount < (Array.length x.arr) - 3
        then
            let mutable i = x.indexCount;
            let mutable ic = x.increaseCount;
            let groupA = (y + x.arr.[x.indexCount + 1] + x.arr.[x.indexCount + 2]);
            let groupB = (x.arr.[x.indexCount + 1] + x.arr.[x.indexCount + 2] + x.arr.[x.indexCount + 3]);
            let difference = groupA - groupB in
            match difference with
            | _ when difference < 0 -> {indexCount = i + 1; increaseCount = ic + 1; arr = x.arr};
            | _ when difference >= 0 -> {indexCount = i + 1; increaseCount = ic + 0; arr = x.arr};
            |_ -> failwith "match error";
            else x
 
    let increaseTotaller (dataArr : array<int>) f =
        let mutable acc = {indexCount = 0; increaseCount = 0; arr = dataArr};
        Array.fold (fun x y -> f x y) acc dataArr;

       
