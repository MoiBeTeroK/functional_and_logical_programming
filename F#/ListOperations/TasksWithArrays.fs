module TasksWithArrays

// Задание 18 Решить задачу с использование класса массив.
// 1. Создать новый массив, в котором порядок элементов существующего массива будет изменен на обратный (Привет -> тевирП).
let reverseString (input: string) : string = input.ToCharArray() |> Array.rev |> System.String

// 2. Дан массив А [1; 2; 3;] и массив B [4; 5; 7] скопировать последний элемент массива В в массив А.
let appendLastBToA (a: int[]) (b: int[]) : int[] = Array.append a [|b.[b.Length - 1]|]

// 3 Объединить два произвольных массива в один.
let combineArrays (a: int[]) (b: int[]) : int[] = Array.append a b


// 4 Создать функцию фильтр для массива А [1; 2; 3; 4; 5; 6; 7; 8; 9; 10; 11; 12] в котором элементы будут делиться на 3 без остатка.
let filterDivisibleBy3 (arr: int[]) : int[] = Array.filter (fun x -> x % 3 = 0) arr


// 5 Напишите программу, которая вводит с клавиатуры два непустых массива целых чисел в диапазоне от нуля до девяти,
// и, считая эти массивы десятичным представлением двух чисел, печатает их разность.
let digitsToNumber (digits: int[]) : int = digits |> Array.fold (fun acc d -> acc * 10 + d) 0

// 6. Напишите программу, которая вводит с клавиатуры два непустых неубывающих массива целых чисел, и печатает те
// и только те элементы, которые встречаются хотя бы в одном из массивов (объединение множеств).
let unionNonDecreasingArrays (a: int[]) (b: int[]) : int[] = 
    let isNonDecreasing arr = arr |> Array.pairwise |> Array.forall (fun (a, b) -> a <= b)
    if not (isNonDecreasing a || isNonDecreasing b) then
        failwith "Массивы не являются неубывающими!"
    b |> Array.append a |> Array.distinct

// 7. Напишите программу, которая вводит с клавиатуры два непустых неубывающих массива целых чисел, и печатает те
// и только те элементы, которые встречаются в обоих массивах (пересечение множеств).
let intersectionNonDecreasingArrays (a: int[]) (b: int[]) : int[] = 
    let isNonDecreasing arr = arr |> Array.pairwise |> Array.forall (fun (a, b) -> a <= b)
    if not (isNonDecreasing a || isNonDecreasing b) then failwith "Массивы не являются неубывающими!"
    a |> Array.filter (fun x -> Array.contains x b) |> Array.distinct

// 8. Напишите программу, которая вводит с клавиатуры два непустых неубывающих массива целых чисел, и печатает те
// и только те элементы, которые входят только в один из масси- вов (симметрическая разность множеств).
let symmetricDifference (a: int[]) (b: int[]) : int[] =
    let isNonDecreasing arr = arr |> Array.pairwise |> Array.forall (fun (a, b) -> a <= b)
    if not (isNonDecreasing a || isNonDecreasing b) then failwith "Массивы не являются неубывающими!"
    let onlyInA = a |> Array.filter (fun x -> not (Array.contains x b))
    let onlyInB = b |> Array.filter (fun x -> not (Array.contains x a))
    Array.append onlyInA onlyInB |> Array.distinct


// 9. Напишите программу, заносящую в массив первые 100 натуральных чисел, делящихся на 13 или на 17, и печатающую его.
let rec getNumbersDivisibleBy13Or17 (n: int) (numbers: int list) : int list =
    if numbers.Length = 100 then
        numbers
    else
        let newNumbers = 
            if (n % 13 = 0 || n % 17 = 0) then
                numbers @ [n]
            else
                numbers
        getNumbersDivisibleBy13Or17 (n + 1) newNumbers

let getFirst100NumbersDivisibleBy13Or17 () : int[] =
    getNumbersDivisibleBy13Or17 1 [] |> List.toArray

// 10. Напишите программу, вводящую целые коэффициенты многочлена и находящую все его рациональные корни.
let divisorsNum (n: int) =
    let absN = abs n
    [1..absN] |> List.filter (fun x -> absN % x = 0) 

// Функция для вычисления значения многочлена в точке x
let evaluatePolynomial (coeffs: int[]) (x: int) : int =
    coeffs
    |> Array.mapi (fun i coeff -> coeff * pown x (coeffs.Length - i - 1))
    |> Array.sum

let findRationalRoots (coeffs: int[]) =
    let leadingCoefficient = coeffs.[0]
    let constantTerm = coeffs.[coeffs.Length - 1]
    
    let pCandidates = divisorsNum constantTerm
    let qCandidates = divisorsNum leadingCoefficient

    let candidates = 
        [| for p in pCandidates do
            for q in qCandidates do
                let potentialRoot = p / q
                if evaluatePolynomial coeffs potentialRoot = 0 then yield potentialRoot |]
    
    candidates