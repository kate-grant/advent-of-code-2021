open System
open System.IO
open Day1.Part1
open Day1.Part2
open Day2.Part1
open Day2.Part2
open Day3.Part1

[<EntryPoint>]
let main argv =
    printfn "Day 1";
    let sonarData = dataReader "Day1PuzzleInput.txt" in
    printfn "Day 1 Data: %A" sonarData;
    printfn "Part 1:"
    let D1P1Solution = Day1.Part1.increaseTotaller sonarData Day1.Part1.yIsGreater;
    printfn "%d is the solution" D1P1Solution.increaseCount
    printfn "Part 2:"
    let D1P2Solution = Day1.Part2.increaseTotaller sonarData Day1.Part2.yIsGreater;
    printfn "%d is the solution" D1P2Solution.increaseCount
    printfn "-------------------------------------------"

    printfn "Day2"
    let subMovementData = dataReaderString "Day2PuzzleInput.txt" in
    printfn "Day 2 Data: %A" subMovementData;
    printfn "Part 1:"
    let D2P1Solution = Day2.Part1.mvmtTotaller subMovementData Day2.Part1.mvmtParser;
    printfn "%d is the solution" D2P1Solution;
    printfn "Part 2:"
    let D2P2Solution = Day2.Part2.mvmtTotaller subMovementData Day2.Part2.mvmtParser;
    printfn "%d is the solution" D2P2Solution;
    printfn "-------------------------------------------"
    printfn "Day 3";
    let betterMovementData = dataReaderString "Day3PuzzleInput.txt" in
    printfn "Day 3 Data: %A" betterMovementData;
    printfn "Part 1:"
    let D3P1Solution = Day3.Part1.powerRate betterMovementData;
    printfn "%d is the solution" D3P1Solution;

        0 // return an integer exit code