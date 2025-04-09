module NumberTasks
// Вариант 2, задания 2, 12, 22, 32, 42, 52

// 1.2.1 Дан целочисленный массив. Необходимо найти индекс минимального элемента.
let indexOfMinList lst = lst |> List.mapi (fun i x -> (i, x)) |> List.minBy snd |> fst

// 1.2.2
let indexOfMinTailRec lst =
    let rec loop tailItems currentIndex minValue minIndex =
        match tailItems with
        | [] -> minIndex
        | x :: rest ->
            if x < minValue then
                loop rest (currentIndex + 1) x currentIndex
            else
                loop rest (currentIndex + 1) minValue minIndex
    match lst with
    | [] -> failwith "Пустой список"
    | x :: tail -> loop tail 1 x 0

// 1.12.1 Дан целочисленный массив. Необходимо переставить в обратном порядке элементы массива, расположенные между его минимальным и максимальным элементами.
let reverseBetweenMinMax (lst: int list) : int list =
    if List.length lst <= 3 then lst
    else
        let minElem = List.min lst
        let maxElem = List.max lst

        let minIndex = List.findIndex (fun x -> x = minElem) lst
        let maxIndex = List.findIndex (fun x -> x = maxElem) lst

        let start, finish = 
            if minIndex < maxIndex then minIndex, maxIndex
            else maxIndex, minIndex

        let before = List.take (start + 1) lst
        let toReverse = lst |> List.skip (start + 1) |> List.take (finish - start - 1) |> List.rev
        let after = List.skip finish lst

        List.concat [before; toReverse; after]

// 1.12.2
let indexOfMaxTailRec lst =
    let rec loop tailItems currentIndex maxValue maxIndex =
        match tailItems with
        | [] -> maxIndex
        | x :: rest ->
            if x > maxValue then
                loop rest (currentIndex + 1) x currentIndex
            else
                loop rest (currentIndex + 1) maxValue maxIndex
    match lst with
    | [] -> failwith "Пустой список"
    | x :: tailItems -> loop tailItems 1 x 0

let reverseBetweenMinMaxChurch list =
    let minIndex = indexOfMinTailRec list
    let maxIndex = indexOfMaxTailRec list
    let start, finish = 
            if minIndex < maxIndex then minIndex, maxIndex
            else maxIndex, minIndex
    let rec loop currentIndex tailItems res =
        match tailItems with
        | [] -> List.rev res
        | x::tail ->
            if currentIndex > start && currentIndex < finish then
                let mirroredPos = finish - (currentIndex - start)
                let mirroredValue = list.[mirroredPos]
                loop (currentIndex+1) tail (mirroredValue::res)
            else
                loop (currentIndex+1) tail (x::res)
    loop 0 list []