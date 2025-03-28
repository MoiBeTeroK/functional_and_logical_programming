open Quadratic
open System

[<EntryPoint>]
let main argv =
    let res : SolveResult = solve 0.0 2.0 -3.0 // 1 корень
    match res with 
    | None -> Console.WriteLine("Нет решений") 
    | Linear x -> Console.WriteLine("Один корень: {0}", x)
    | Quadratic (x1, x2) -> Console.WriteLine("Два корня: {0} и {1}", x1, x2)
    0