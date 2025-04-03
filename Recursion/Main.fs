open System
open Language

[<EntryPoint>]
let main argv =
    let userInput = Console.ReadLine()
    Console.WriteLine(question userInput)
    0