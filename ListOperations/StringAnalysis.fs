module StringAnalysis

// 19 задание
// 2. Дана строка, состоящая из символов латиницы. Необходимо проверить, упорядочены ли строчные символы этой строки по возрастанию.
let isOrdered (s: string) : bool =
    let lower = s.ToLower()  // преобразуем всю строку в нижний регистр
    let rec check i =
        match i with
        | _ when lower.Length < 2 || i >= lower.Length - 1 -> true
        | _ when lower.[i] > lower.[i + 1] -> false
        | _ -> check (i + 1)
    check 0

// 20 задание
// Отсортировать строки в указанном порядке: 2. В порядке увеличения разницы между частотой наиболее часто встречаемого символа в строке и частотой его появления в алфавите
let sortByFreqDiff (arr: string[]) =
    let all = System.String.Concat arr

    let getDiff (s: string) =
        let counts = Array.create 65536 0
        for c in s do
            counts.[int c] <- counts.[int c] + 1
        let mutable maxChar = ' '
        let mutable maxCount = 0
        for c in s do
            if counts.[int c] > maxCount then
                maxCount <- counts.[int c]
                maxChar <- c
        let globalCount = all |> Seq.filter (fun x -> x = maxChar) |> Seq.length
        abs (maxCount - globalCount)

    arr |> Array.sortBy getDiff

let inputStrings() =
    printfn "Введите количество строк:"
    let n = System.Console.ReadLine() |> int
    Array.init n (fun _ ->
        printfn "Введите строку:"
        System.Console.ReadLine()
    )