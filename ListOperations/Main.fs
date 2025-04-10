open System
open NumberTasks
open PrimeDivisorsApp
open TasksWithArrays
open StringAnalysis

[<EntryPoint>]
let main argv =
    // 11 задание
    // let lst = [5; 3; 8; 1; 4]
    // let minIndexList = indexOfMinList lst
    // Console.WriteLine("Индекс минимального элемента (возможности класса List): {0}", minIndexList)

    // let minIndexChurch = indexOfMinTailRec lst
    // Console.WriteLine("Индекс минимального элемента (списки Черча): {0}", minIndexChurch)

    // 12 задания
    // let lst = [1; 3; 5; 7; 9]
    // let valuesReverseBetweenMinMax = reverseBetweenMinMax lst
    // let valuesReverseBetweenMinMaxChurch = reverseBetweenMinMaxChurch lst
    // printfn "Массив с элементами в обратном порядке между min и max (возможности класса List): %A" valuesReverseBetweenMinMax
    // printfn "Массив с элементами в обратном порядке между min и max (списки Черча): %A" valuesReverseBetweenMinMaxChurch

    // 13 задания
    // let lst = [1; 3; 5; 3; 9; 3; 4; 8; 6; 3; 7; 6]
    // let countValueMinInInterval = countMinInInterval lst 1 10
    // let countValuesMinInRangeChurch = countMinInRangeChurch lst 1 10
    // Console.WriteLine("Кол-во минимальных эл-ов на интревале (возможности класса List): {0}", countValueMinInInterval)
    // Console.WriteLine("Кол-во минимальных эл-ов на интревале (списки Черча): {0}", countValuesMinInRangeChurch)

    // 14 задание
    // let lst = [1; 3; 2; 4; 1; 5; 6; 4; 2]
    // let countLocalMax = countLocalMaxima lst
    // let countLocalMaxChurch = countLocalMaximaChurch lst
    // Console.WriteLine("Количество локальных максимумов (возможности класса List): {0}", countLocalMax)
    // Console.WriteLine("Количество локальных максимумов (списки Черча): {0}", countLocalMaxChurch)

    // 15 задание
    // let lst = [1; 2; 3; 4; 5]
    // let elemLessAverage  = findElementsLessThanAverage lst
    // let elemLessAverageChurch = findElementsLessThanAverageChurch lst
    // printfn "Элементы меньше среднего (возможности класса List): %A" elemLessAverage
    // printfn "Элементы меньше среднего (списки Черча): %A" elemLessAverageChurch

    // 16 задание
    // let primeFactorsResult = primeFactors 12
    // printfn "Простые делители числа (возможности класса List): %A" primeFactorsResult

    // let primeFactorsChurchResult = primeFactorsChurch 12
    // printfn "Простые делители числа (списки Черча): %A" primeFactorsChurchResult

    // 17 задание
    // appWithFunctions

    // 18.1 задание
    // Console.WriteLine(reverseString "Привет, мир!")
    
    // 18.2 задание
    // let a = [|1; 2; 3|]
    // let b = [|4; 5; 7|]
    // printfn "%A" (appendLastBToA a b)

    // 18.3 задание
    // let a = [|1; 2; 3|]
    // let b = [|4; 5; 6|]
    // printfn "%A" (combineArrays a b)

    // 18.4 задание
    // let a = [|1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12|]
    // printfn "%A" (filterDivisibleBy3 a)

    // 18.5 задание
    // Console.Write("Введите первое число (цифры через пробел): ")
    // let aInput = Console.ReadLine().Split() |> Array.map int

    // Console.Write("Введите второе число (цифры через пробел): ")
    // let bInput = Console.ReadLine().Split() |> Array.map int

    // let result = (digitsToNumber aInput) - (digitsToNumber bInput)
    // printfn "Разность: %d" result

    // 18.6 задание
    // Console.Write("Введите первый массив (цифры через пробел): ")
    // let aInput = Console.ReadLine().Split() |> Array.map int

    // Console.Write("Введите второй массив (цифры через пробел): ")
    // let bInput = Console.ReadLine().Split() |> Array.map int

    // let result = unionNonDecreasingArrays aInput bInput
    // printfn "Объединение: %A" result

    // 18.7 задание
    // Console.Write("Введите первый массив (цифры через пробел): ")
    // let aInput = Console.ReadLine().Split() |> Array.map int

    // Console.Write("Введите второй массив (цифры через пробел): ")
    // let bInput = Console.ReadLine().Split() |> Array.map int

    // let result = intersectionNonDecreasingArrays aInput bInput
    // printfn "Пересечение: %A" result

    // 18.8 задание
    // Console.Write("Введите первый массив (цифры через пробел): ")
    // let aInput = Console.ReadLine().Split() |> Array.map int

    // Console.Write("Введите второй массив (цифры через пробел): ")
    // let bInput = Console.ReadLine().Split() |> Array.map int

    // let result = symmetricDifference aInput bInput
    // printfn "Пересечение: %A" result

    // 18.9 задание
    // let result = getFirst100NumbersDivisibleBy13Or17()
    // printfn "Первые 100 чисел, делящихся на 13 или 17:\n %A" result

    // 18.10 задание
    // Console.Write("Введите коэффициенты многочлена (через пробел): ")
    // // let test = [|1; -6; 11; -6|]
    // let coeffs = Console.ReadLine().Split() |> Array.map int
    // let roots = findRationalRoots coeffs
    // if roots.Length > 0 then printfn "Рациональные корни: %A" roots
    // else printfn "Рациональных корней нет."

    // 19 задание
    let input = "aBcDe"
    let result = isOrdered input
    printfn "%b" result

    0