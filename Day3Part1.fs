namespace Day3
module Part1 =

    open System
    open System.IO

    type public countRec = {mutable b0 : int; mutable b1 : int}
    type public countRec2 = {mutable count : int; mutable list : List<int>; cMap : Map<int, countRec>}

    let dataReaderString (filePath : string) =
        new StreamReader(Path.Join(__SOURCE_DIRECTORY__, filePath)) |> Array.unfold (fun strmrd -> 
        match strmrd.ReadLine() with
        | null -> strmrd.Dispose(); None 
        | str -> Some(str, strmrd);)

    let charParser (c : char) (r : countRec) : countRec =
        match c with
        | '0' -> printfn "match0 %A" {b0 = r.b0 + 1; b1 = r.b1}; {b0 = r.b0 + 1; b1 = r.b1};
        | '1' -> printfn "match1 %A" {b0 = r.b0; b1 = r.b1 + 1}; {b0 = r.b0; b1 = r.b1 + 1};
        | _ -> printfn "r"; r;

    let btParser  (acc : Map<int, countRec>) (str : string) : Map<int, countRec> =
        printfn "%s\n" str;
        printfn "%A" acc;
        let acc = acc |> Map.change 0 (fun x ->
            match x with
            | Some v -> Some (charParser str.[0] v);
            | None -> None);

        let acc = acc |> Map.change 1 (fun x ->
            match x with
            | Some v -> Some (charParser str.[1] v);
            | None -> None);

        let acc = acc |> Map.change 2 (fun x ->
            match x with
            | Some v -> Some (charParser str.[2] v);
            | None -> None);

        let acc = acc |> Map.change 3 (fun k ->
            match k with
            | Some v -> Some (charParser str.[3] v);
            | None -> None);

        let acc = acc |> Map.change 4 (fun k ->
            match k with
            | Some v -> Some (charParser str.[4] v);
            | None -> None);

        let acc = acc |> Map.change 5 (fun k ->
            match k with
            | Some v -> Some (charParser str.[5] v);
            | None -> None);

        let acc = acc |> Map.change 6 (fun k ->
            match k with
            | Some v -> Some (charParser str.[6] v);
            | None -> None);

        let acc = acc |> Map.change 7 (fun k ->
            match k with
            | Some v -> Some (charParser str.[7] v);
            | None -> None);

        let acc = acc |> Map.change 8 (fun k ->
            match k with
            | Some v -> Some (charParser str.[8] v);
            | None -> None);

        let acc = acc |> Map.change 9 (fun k ->
            match k with
            | Some v -> Some (charParser str.[9] v);
            | None -> None);
        let acc = acc |> Map.change 10 (fun k ->
            match k with
            | Some v -> Some (charParser str.[10] v);
            | None -> None);

        let acc = acc |> Map.change 11 (fun k ->
            match k with
            | Some v -> Some (charParser str.[11] v);
            | None -> None);
        acc;

    let bitAssembler (accList : countRec2) (i : int) (c : countRec) : countRec2 =
        if (c.b0 > c.b1)
        then
            printfn "greater: %d b0 %d b1" c.b0 c.b1;
            {count = accList.count; list = List.append accList.list [0]; cMap = accList.cMap};
        elif (c.b0 < c.b1)
        then
            printfn "else: %d b0 %d b1" c.b0 c.b1;
            {count = accList.count; list = List.append accList.list [1]; cMap = accList.cMap};
        else
            accList;

    let bitTotaller (dataArr : array<string>) f : List<int> =
        let mutable rec0 = {b0 = 0; b1 = 0};
        let mutable rec1 = {b0 = 0; b1 = 0};
        let mutable rec2 = {b0 = 0; b1 = 0};
        let mutable rec3 = {b0 = 0; b1 = 0};
        let mutable rec4 = {b0 = 0; b1 = 0};
        let mutable rec5 = {b0 = 0; b1 = 0};
        let mutable rec6 = {b0 = 0; b1 = 0};
        let mutable rec7 = {b0 = 0; b1 = 0};
        let mutable rec8 = {b0 = 0; b1 = 0};
        let mutable rec9 = {b0 = 0; b1 = 0};
        let mutable rec10 = {b0 = 0; b1 = 0};
        let mutable rec11 = {b0 = 0; b1 = 0};
        let mutable acc = Map [(0, rec0); (1, rec1); (2, rec2); (3, rec3); (4, rec4); (5, rec5); (6, rec6); (7, rec7); (8, rec8); (9, rec9); (10, rec10); (11, rec11)];
        let countMap = Array.fold (fun x y -> f x y) acc dataArr;



        let mutable counter = 0;
        let mutable countList = [];
        let mutable accList = {count = counter; list = countList; cMap = countMap};
        let folded = (Map.fold (fun a b c -> bitAssembler a b c) accList countMap).list;
        
        folded;


    let inverseBinary (b : List<int>) : List<int> =
        List.fold (fun x y -> if y = 0 then List.append x [1]; else List.append x [0]) [] b;
        
    

    let listToBase10 (l : List<int>) : int =
        let mutable xiiBit = {b0 = 11; b1 = 0};
        let b10Folder (acc : countRec) (v : int) : countRec =
            let mutable exp = acc.b0 |> float;
            let mutable total = ((((2.0 ** exp |> int) * v) + acc.b1));
            printfn "total %d = 2exp%f x %d + %d" total exp v acc.b1;
            printfn "%f exp" exp;
            printfn "%d v" v;
            printfn "%A acc" acc;
            {b0 = acc.b0 - 1; b1 = total};

        (List.fold (fun x y -> b10Folder x y) xiiBit l).b1;
        

    let powerRate (dataArr: array<string>) : int =
        let l = bitTotaller dataArr btParser;
        printfn "%A l" l;
        let gamma = listToBase10 l;
        printfn "inverse b %A" (inverseBinary l);
        let epsilon = listToBase10 (inverseBinary l);
        printfn "%d %d" gamma epsilon;

        gamma * epsilon;
