open System
open NumberTasks

[<EntryPoint>]
let main argv =
    // 11 задание
    let lst = [5; 3; 8; 1; 4]
    let minIndexList = indexOfMinList lst
    Console.WriteLine("Индекс минимального элемента (возможности класса List): {0}", minIndexList)

    let minIndexChurch = indexOfMinTailRec lst
    Console.WriteLine("Индекс минимального элемента (списки Черча): {0}", minIndexChurch)

    // 12 задания

    // 13 задания

    // 14 задание

    // 15 задание

    // 16 задание

    0