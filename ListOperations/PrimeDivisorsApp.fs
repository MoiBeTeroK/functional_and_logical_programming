module PrimeDivisorsApp
open NumberTasks

// 17 задание
let readList () =
    System.Console.WriteLine "Введите список через пробел:"
    System.Console.ReadLine().Split()
    |> Array.map int
    |> Array.toList 

//  1
let rec lcs list1 list2 =
        match list1, list2 with
        | [], _ -> []
        | _, [] -> []
        | x::tailx, y::taily when x = y -> x :: lcs tailx taily
        | _::tailx, _::taily ->
            let lcs1 = lcs tailx list2
            let lcs2 = lcs list1 taily
            if List.length lcs1 > List.length lcs2 then lcs1 else lcs2


// 2
let fiveLists (list: int list) =
    let halveEvens = 
        list 
        |> List.filter (fun x -> x % 2 = 0) 
        |> List.map (fun x -> x / 2)

    let divideBy3 = 
        halveEvens 
        |> List.filter (fun x -> x % 3 = 0)

    let squares = 
        divideBy3 
        |> List.map (fun x -> x * x)

    let commonWithHalves = 
        squares 
        |> List.filter (fun x -> List.contains x halveEvens)

    let combined = List.concat [divideBy3; squares; commonWithHalves]

    halveEvens, divideBy3, squares, commonWithHalves, combined

// 3
let factorTuples n =
    let rec gcd a b =
        if b = 0 then a else gcd b (a % b)

    [ for x in 1 .. n do
        if n % x = 0 then
            let y = n / x
            let d = gcd x y
            yield (x / d, y / d) ]
    |> List.distinct

// 4
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

// 5
let allPrimeDivisors (list: int list) =
    let allPrimes = list |> List.collect primeFactors |> List.distinct
    list |> List.filter (fun x ->
        let xPrimes = primeFactors x |> List.distinct
        allPrimes |> List.forall (fun p -> List.contains p xPrimes))


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
        let result = allPrimeDivisors list
        printfn "Элементы со всеми простыми делителями: %A" result
    | _ -> printfn "Такой задачи нет"