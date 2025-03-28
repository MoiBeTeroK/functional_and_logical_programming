open Quadratic
open CircleCylinder
open Recursion
open System

[<EntryPoint>]
let main argv =
    // Решение квадратного уравнения
    let res : SolveResult = solve 0.0 2.0 -3.0 // 1 корень
    match res with 
    | None -> Console.WriteLine("Нет решений") 
    | Linear x -> Console.WriteLine("Один корень: {0}", x)
    | Quadratic (x1, x2) -> Console.WriteLine("Два корня: {0} и {1}", x1, x2)

    // Площадь круга и объем цилиндра
    let radius = Console.ReadLine() |> float
    let height = Console.ReadLine() |> float
    let volumeCylinderCurry = cylinderVolume_curry radius height
    Console.WriteLine("Объем цилиндра с каррированием: {0}", volumeCylinderCurry)

    let volumeCylinderSuperpos = cylinderVolume_superpos radius height
    Console.WriteLine("Объем цилиндра с суперпозицией: {0}", volumeCylinderSuperpos)

    // Сумма цифр числа с рекурсией вверх и вниз
    let result1 = sumDigitsUp 12345
    Console.WriteLine("Сумма цифр с рекурсией вверх: {0}", result1)
    let result2 = sumDigitsDown 123
    Console.WriteLine("Сумма цифр с рекурсией вниз: {0}", result2)
    0