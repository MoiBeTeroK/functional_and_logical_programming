module StringAnalysis

// 19 задание
// 2. Дана строка, состоящая из символов латиницы. Необходимо проверить, упорядочены ли строчные символы этой строки по возрастанию.
let isOrdered (s: string) : bool =
    let lowercaseLetters = 
        s 
        |> Seq.filter (fun c -> c >= 'a' && c <= 'z') 
        |> Seq.toList

    let rec check list =
        match list with
        | [] | [_] -> true
        | x :: y :: tail when x <= y -> check (y :: tail)
        | _ -> false
    check lowercaseLetters


// 20 задание
// Отсортировать строки в указанном порядке: 2. В порядке увеличения разницы между частотой наиболее часто встречаемого символа в строке и частотой его появления в алфавите
let sortByFreqDiff (arr: string[]) =
    let all = System.String.Concat arr

    let getMostFrequentChar (s: string) = s |> Seq.countBy id |> Seq.maxBy snd

    let getDiff (s: string) =
        let maxChar, maxCount = getMostFrequentChar s
        let globalCount = all |> Seq.filter ((=) maxChar) |> Seq.length
        abs (maxCount - globalCount)

    arr |> Array.sortBy getDiff

let inputStrings() =
    printfn "Введите количество строк:"
    let n = System.Console.ReadLine() |> int
    Array.init n (fun _ ->
        printfn "Введите строку:"
        System.Console.ReadLine()
    )