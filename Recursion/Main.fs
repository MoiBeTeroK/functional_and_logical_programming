open System
open Language
open CoprimeOperations
open CountDivNotDivByThree
open FindMinOddDigit
open SumOfSpecialDivisors

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
    // let num = 15
    // let testResult = coprimeWithCondition num (fun x -> x % 2 > 0)
    // Console.WriteLine("Взаимно простые числа с {0}, которые нечетные: {1}", num, String.Join(", ", testResult))

    // 16.1 задание
    // Console.WriteLine(countDivNotDivByThree 15)

    // 16.2 задание
    // Console.WriteLine(findMinOddDigit 2935)

    // 16.3 задание
    let result = sumOfSpecialDivisors 30
    Console.WriteLine(result)
    0