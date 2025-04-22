module PrimeDivisorsApp
open NumberTasks

// Задание 17 Построить приложение на F# , позволяющее пользователю решать задачу указанную задачу с применением высших функций класса List.
let readList () =
    System.Console.WriteLine "Введите список через пробел:"
    System.Console.ReadLine().Split()
    |> Array.map int
    |> Array.toList 

//  1. Даны две последовательности, найти наибольшую по длине общую подпоследовательность.
let rec lcs list1 list2 =
        match list1, list2 with
        | [], _ -> []
        | _, [] -> []
        | x::tailx, y::taily when x = y -> x :: lcs tailx taily
        | _::tailx, _::taily ->
            let lcs1 = lcs tailx list2
            let lcs2 = lcs list1 taily
            if List.length lcs1 > List.length lcs2 then lcs1 else lcs2


// 2. Дан список, построить кортеж, содержащий пять списков, при этом
// - первый список содержит результат деления на два только четных
// элементов исходного,
// - второй список содержит результат деления на три только тех элементов
// первого, которые делятся на три,
// - третий список содержит квадраты значений второго списка,
// - четвертый список содержит только те элементы третьего, которые
// встречаются в первом,
// - пятый список содержит все элементы второго, третьего и четвертого
// списков.
let fiveLists (list: int list) =
    let halveEvens = 
        list 
        |> List.filter (fun x -> x % 2 = 0) 
        |> List.map (fun x -> x / 2)

    let divideBy3 = 
        halveEvens 
        |> List.filter (fun x -> x % 3 = 0)
        |> List.map (fun x -> x / 3)

    let squares = 
        divideBy3 
        |> List.map (fun x -> x * x)

    let commonWithHalves = 
        squares 
        |> List.filter (fun x -> List.contains x halveEvens)

    let combined = List.concat [divideBy3; squares; commonWithHalves]

    halveEvens, divideBy3, squares, commonWithHalves, combined

// 3. Для введенного числа N построить список неповторяющихся кортежей (a,b), таких, что существует пара (x,y): X*Y=N, НОД(X,Y)=d, a=X/d, b=Y/d .
let factorTuples n =
    let rec gcd a b = 
        if b = 0 then a else gcd b (a % b)
    let divisors = [1..n] |> List.filter (fun x -> n % x = 0)
    divisors |> List.map (fun x -> 
        let y = n / x
        let d = gcd x y
        (x / d, y / d)) |> List.distinct

// 4. Для введенного списка построить новый с элементами вида (a,b,c), где a<b<c образуют Пифагорову тройку.
let findPythagoreanTriples list =
    list
    |> List.allPairs list  
    |> List.filter (fun (a, b) -> b > a)
    |> List.collect (fun (a, b) -> 
        list
        |> List.filter (fun c -> c > b && a * a + b * b = c * c)
        |> List.map (fun c -> (a, b, c))
    )
    |> List.distinct

// 5. Для введенного списка построить список из элементов, для которых в данном списке встречаются все простые делители.
let allPrimeDivisors (list: int list) =
    let allPrimes = list |> List.collect primeFactors |> List.distinct
    list |> List.filter (fun x ->
        let xPrimes = primeFactors x |> List.distinct
        allPrimes |> List.forall (fun p -> List.contains p xPrimes))

// 6. Отсортировать введенный список кортежей длины 5 по возрастанию в лексико-графическом порядке, причем в новом списке могут быть лишь
// кортежи из цифр в итоговый список записать числовое представление получившегося кортежа, то есть список вида
// [(7,3,4,5,6),(2,3,4,6,7),(2,3,4,5,6),(4,3,10,4,5)] должен быть преобразован в список [23456,23467,73456].
let sortAndConvertToNumbers (list: (int * int * int * int * int) list) =
    list
    |> List.filter (fun (a, b, c, d, e) -> List.forall (fun x -> x >= 0 && x <= 9) [a; b; c; d; e])
    |> List.sort
    |> List.map (fun (a, b, c, d, e) -> int (string a + string b + string c + string d + string e))

// 7. Для введенного списка построить новый список, который получен из начального упорядочиванием по параметру P(a), где
// P(a) – сумма делителей числа а, которые являются делителями хотя бы одного из элементов списка, стоящих на четных позициях и не являются
// делителями ни одного из элементов, которые меньше среднего арифметического данного списка.
let divisors n =
    [1..n] |> List.filter (fun d -> n % d = 0)
let sortByDivisorsParam list =
    let avg = float (List.sum list) / float (List.length list)
    list
    |> List.sortBy (fun a ->
        divisors a
        |> List.filter (fun d ->
            list |> List.indexed |> List.exists (fun (i, x) -> i % 2 = 0 && x % d = 0) &&
            list |> List.forall (fun x -> float x >= avg || x % d <> 0))
        |> List.sum)


// 8. Для введенного списка построить список, где каждый элемент – это среднее арифметическое тех цифр соответствующего числа из исходного
// списка, которые встречаются в списке чаще, чем половина всех остальных цифр(то есть если частота встречаемости цифр в исходном списке 0-0,1-0,2-
// 0,3-0,4-6,5-5,6-5,7-3,8-3,9-2, то для числа 745 необходимо поместить в список 4,5 ).
let digits n =
    let rec extractDigits n acc =
        if n = 0 then acc
        else extractDigits (n / 10) ((n % 10) :: acc)
    extractDigits n []
let digitFrequencies list =
    list |> List.collect digits |> List.countBy id |> Map.ofList
let averageOfFrequentDigits list =
    let freqs = digitFrequencies list
    let getFreq d = Map.tryFind d freqs |> Option.defaultValue 0 |> float

    list
    |> List.map (fun num ->
        digits num
        |> List.filter (fun d ->
            let dFreq = getFreq d
            let otherFreqs =
                [0..9]
                |> List.except [d]
                |> List.map getFreq
            dFreq > List.average otherFreqs)
        |> fun selected -> if selected = [] then 0.0 else selected |> List.map float |> List.average)

// 9. Для введенного списка построить новый список, в который войдут лишь те элементы, которые
// - больше, чем сумма всех предыдущих в исходном списке,
// - являются полным квадратом одного из элементов исходного списка,
// - делятся на все предыдущие элементы исходного списка.
// В итоговый список включить кортеж (число, сумма предыдущих, количество элементов в списке больше заданного).
let isSquareOfAny n list =
    list |> List.exists (fun x -> x * x = n)

let createSpecialList list =
    let rec processList remaining sumSoFar result =
        match remaining with
        | [] -> List.rev result
        | x :: tail ->
            let allPrevDivisible = list |> List.take (List.length list - List.length remaining) |> List.forall (fun p -> p <> 0 && x % p = 0)
            let isGreaterThanSum = x > sumSoFar
            let isSquare = isSquareOfAny x list
            let countGreater = list |> List.filter (fun y -> y > x) |> List.length
            if isGreaterThanSum && isSquare && allPrevDivisible then
                processList tail (sumSoFar + x) ((x, sumSoFar, countGreater) :: result)
            else
                processList tail (sumSoFar + x) result
    processList list 0 []

// 10. Для введенного списка вывести кортеж списков, составленных из
// List2 - номера элементов, которые могут быть получены как произведение двух любых других элементов списка
// List3 - номера элементов, которые могут быть получены как сумма трех любых других элементов списка.
// LIST 4- номера элементов, которые делятся ровно на четыре элемента из списка
let buildLists list =
    let findList2 list =
        let indices = [0..List.length list - 1]
        indices |> List.filter (fun i ->
            indices |> List.exists (fun j ->
                indices |> List.exists (fun k ->
                    i <> j && i <> k && j <> k && List.item i list = List.item j list * List.item k list)))
    let findList3 list =
        let indices = [0..List.length list - 1]
        indices |> List.filter (fun i ->
            let currentValue = List.item i list
            indices |> List.exists (fun j ->
                indices |> List.exists (fun k ->
                    indices |> List.exists (fun l ->
                        i <> j && i <> k && i <> l && j <> k && j <> l && k <> l && 
                        (List.item j list + List.item k list + List.item l list = currentValue)))))
    let findList4 list =
        let indices = [0..List.length list - 1]
        indices |> List.filter (fun i ->
            let countDivisors = indices |> List.filter (fun j -> i <> j && List.item i list % List.item j list = 0) |> List.length
            countDivisors = 4)
    let list2 = findList2 list
    let list3 = findList3 list
    let list4 = findList4 list

    (list2, list3, list4)

let appWithFunctions = 
    System.Console.WriteLine "Выберите одну из задач 1-10:"
    match System.Console.ReadLine() |> int with
    | 1 ->
        let seq1 = readList ()
        let seq2 = readList ()
        let result = lcs seq1 seq2
        printfn "Наибольшая общая подпоследовательность: %A" result
    | 2 ->
        let list = readList ()
        let result = fiveLists list
        printfn "5 списков: %A" result
    | 3 ->
        let n = System.Console.ReadLine() |> int
        let pairs = factorTuples n
        printfn "Пары: %A" pairs
    | 4 ->
        let list = readList ()
        let triples = findPythagoreanTriples list
        printfn "Пифагоровы тройки: %A" triples
    | 5 ->
        let list = readList ()
        // let list = [30; 60; 90; 210]
        let result = allPrimeDivisors list
        printfn "Элементы со всеми простыми делителями: %A" result
    | 6 ->
        let tuples = [(7,3,4,5,6); (2,3,4,6,7); (2,3,4,5,6); (4,3,10,4,5)]
        let result = sortAndConvertToNumbers tuples
        printfn "Сортировка списка картежей: %A" result
    | 7 ->
        let list = readList ()
        let sorted = sortByDivisorsParam list
        printfn "Сортировка по параметру - сумме делителя числа: %A" sorted
    | 8 ->
        let list = readList ()
        let means = averageOfFrequentDigits list
        printfn "Список средних популярных цифр: %A" means
    | 9 ->
        let list = readList ()
        // let list = [1; 4; 9; 16; 36; 2]
        let result = createSpecialList list
        printfn "Список кортежей: %A" result
    | 10 ->
        // let list = readList ()
        let list = [2; 3; 6; 12; 18; 3]
        let result = buildLists list
        printfn "Кортеж списков из 3-х списков: %A" result
    | _ -> printfn "Такой задачи нет"