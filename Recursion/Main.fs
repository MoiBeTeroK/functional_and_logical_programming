open System
open Language
open CoprimeOperations
open CountDivNotDivByThree
open FindMinOddDigit
open SumOfSpecialDivisors
open ChooseFunction
open SumOrFactorial
open ProcessDigits

[<EntryPoint>]
let main argv =
    // 6 задание
    let sumFunction = SumOrFact true
    let factFunction = SumOrFact false

    let sumResult = sumFunction 123 
    let factResult = factFunction 5
    Console.WriteLine("Sum of digits: {0}", sumResult)
    Console.WriteLine("Factorial: {0}", factResult)

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
    // let result = sumOfSpecialDivisors 30
    // Console.WriteLine(result)

    // 20 задание
    // Console.WriteLine("Введите номер функции и аргумент через пробел:")
    // let input = Console.ReadLine().Split()
    // let functionNumber = int input.[0]
    // let argument = int input.[1] 

    // let numFunction = chooseFunction functionNumber
    // let result = numFunction argument
    // Console.WriteLine(result)

    // chooseFunction functionNumber argument |> Console.WriteLine
    0