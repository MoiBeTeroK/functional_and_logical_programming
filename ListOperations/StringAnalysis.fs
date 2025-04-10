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