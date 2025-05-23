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
        | [] -> res
        | x::tail ->
            if currentIndex > start && currentIndex < finish then
                let mirroredPos = finish - (currentIndex - start)
                let mirroredValue = list.[mirroredPos]
                loop (currentIndex+1) tail (res @ [mirroredValue])
            else
                loop (currentIndex+1) tail (res @ [x])
    loop 0 list []

// 1.22.1 Дан целочисленный массив и интервал a..b. Необходимо найти количество минимальных элементов в этом интервале.
let countMinInInterval (lst: int list) a b =
    if a < 0 || b >= List.length lst || a > b then failwith "Некорректные индексы. Убедитесь, что 0 <= a <= b < длина списка."
    let subList = lst |> List.skip a |> List.take (b - a + 1)
    let _, minCount = 
        subList |> List.fold (fun (minElem, count) x ->
            if x < minElem then (x, 1)
            elif x = minElem then (minElem, count + 1)
            else (minElem, count)
        ) (System.Int32.MaxValue, 0)
    minCount

//1.22.2
let findMinElement lst =
    let targetIndex = indexOfMinTailRec lst
    let rec getByIndex lst index =
        match lst, index with
        | x::_, 0 -> x
        | _::xs, i -> getByIndex xs (i - 1)
        | [], _ -> failwith "Индекс вне диапазона списка"
    getByIndex lst targetIndex
let countMinInRangeChurch lst a b =
    if a < 0 || b >= List.length lst || a > b then failwith "Некорректные индексы. Убедитесь, что 0 <= a <= b < длина списка."
    let rec takeRange start stop acc list = 
        match list with
        | [] -> acc
        | x::tail -> 
            if start > stop then acc
            elif start > 0 then takeRange (start-1) (stop-1) acc tail
            else takeRange start (stop-1) (x::acc) tail
    
    let sublist = takeRange a b [] lst
    let minVal = findMinElement sublist

    let rec countMin count list = 
        match list with
        | [] -> count
        | x::tail -> countMin (if x = minVal then count + 1 else count) tail
    
    countMin 0 sublist

// 1.32.1 Дан целочисленный массив. Найти количество его локальных максимумов.
let countLocalMaxima (lst: int list) =
    if List.length lst < 1 then failwith "Пустой список"
    else
        lst |> List.indexed |> List.filter (fun (i, x) ->
            match i with
            | 0 -> x > List.head (List.tail lst)
            | i when i = List.length lst - 1 -> x > List.last (List.take (List.length lst - 1) lst)
            | i -> x > List.item (i - 1) lst && x > List.item (i + 1) lst)
        |> List.length

// 1.32.2
let countLocalMaximaChurch lst =
    let rec loop acc lst =
        match lst with
        | x :: y :: z :: tail ->
            let newAcc = if y > x && y > z then acc + 1 else acc
            loop newAcc (y :: z :: tail)
        | [x; y] ->
            if y > x then acc + 1 else acc
        | _ -> acc

    let acc0 =
        match lst with
        | x :: y :: _ when x > y -> 1
        | _ -> 0

    loop acc0 lst

// 1.42.1 Дан целочисленный массив. Найти все элементы, которые меньше среднего арифметического элементов массива.
let findElementsLessThanAverage lst = 
    let average = float (List.sum lst) / float (List.length lst)
    List.filter (fun x -> float x < average) lst

// 1.42.2
let findElementsLessThanAverageChurch lst = 
    let rec sumAndCount accSum accCount lst =
        match lst with
        | [] -> (accSum, accCount)
        | x::tail -> sumAndCount (accSum + x) (accCount + 1) tail

    let sum, count = sumAndCount 0 0 lst
    let average = float sum / float count

    let rec loop acc lst =
        match lst with
        | [] -> acc
        | x::tail when float x < average -> loop (acc @ [x]) tail
        | _::tail -> loop acc tail
    loop [] lst

// 1.52.1 Для введенного числа построить список всех его простых делителей, причем если введенное число делится на простое число p в степени α, то в
// итоговом списке число p должно повторятся α раз. Результирующий список должен быть упорядочен по возрастанию.
let primeFactors n =
    let rec loop n p acc =
        match n with
        | 1 -> acc
        | _ when n % p = 0 -> loop (n / p) p (p :: acc)
        | _ -> loop n (p + 1) acc

    if n < 2 then []
    else loop n 2 [] |> List.rev

// 1.52.2
let primeFactorsChurch n =
    let rec reverse acc lst =
        match lst with
        | [] -> acc
        | x :: tail -> reverse (x :: acc) tail

    let rec decompose n p acc =
        match n with
        | 1 -> acc
        | _ when n % p = 0 -> decompose (n / p) p (p :: acc)
        | _ -> decompose n (p + 1) acc


    if n < 2 then []
    else reverse [] (decompose n 2 [])
