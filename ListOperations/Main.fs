open System
open NumberTasks

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
    let primeFactorsResult = primeFactors 12
    printfn "Простые делители числа (возможности класса List): %A" primeFactorsResult

    let primeFactorsChurchResult = primeFactorsChurch 12
    printfn "Простые делители числа (списки Черча): %A" primeFactorsChurchResult

    0