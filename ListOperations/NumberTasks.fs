module NumberTasks
// Вариант 2, задания 2, 12, 22, 32, 42, 52

// 11.2.1 Дан целочисленный массив. Необходимо найти индекс минимального элемента.
let indexOfMinList lst = lst |> List.mapi (fun i x -> (i, x)) |> List.minBy snd |> fst

// 11.2.2
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

