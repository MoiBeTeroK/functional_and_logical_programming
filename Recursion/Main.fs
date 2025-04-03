open System
open Language
open CoprimeOperations

[<EntryPoint>]
let main argv =
    // 11 задание
    // let userInput = Console.ReadLine()
    // Console.WriteLine(question userInput)

    // 12 задание
    // super()
    // curry()

    // 13 задание
    // let result = coprimeOperation 12 (+) 0
    // Console.WriteLine(result)

    // 14 задание
    // let euler = eulerPhi 10
    // Console.WriteLine(euler)

    // 15 задание
    let num = 15
    let testResult = coprimeWithCondition num (fun x -> x % 2 > 0)
    Console.WriteLine("Взаимно простые числа с {0}, которые нечетные: {1}", num, String.Join(", ", testResult))
    0