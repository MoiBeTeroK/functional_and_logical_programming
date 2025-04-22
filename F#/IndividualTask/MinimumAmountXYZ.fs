// 142.Нужно найти минимальную сумму x + y + z с целыми числами x > y > z > 0 такой, что x + y, x - y, x + z, x - z, y + z, y - z являются идеальными квадратами.
open System

let isSquare n =
    let root = int (sqrt (float n))
    root * root = n

let squares = [1 .. 1000] |> List.map (fun x -> x * x)

let allPairs =
    squares
    |> List.collect (fun a ->
        squares
        |> List.filter (fun b -> a > b)
        |> List.map (fun b -> (a + b, (a, b))))

let groupedPairs =
    allPairs
    |> List.groupBy fst
    |> List.map (fun (key, lst) -> (key, List.map snd lst))

let findFirstTripleAndSum =
    groupedPairs
    |> List.tryPick (fun (_, pairs) ->
        pairs
        |> List.tryPick (fun (a, b) ->
            let x = (a + b) / 2
            let y = (a - b) / 2
            if y > 0 && x > y then
                pairs
                |> List.tryPick (fun (c, d) ->
                    let z = (c - d) / 2
                    if z > 0 && (c + d) / 2 = x && y > z && isSquare (y + z) && isSquare (y - z) then
                        Some ((x, y, z), x + y + z)
                    else
                        None
                )
            else
                None
        )
    )
    
[<EntryPoint>]
let main argv =
    match findFirstTripleAndSum with
        | Some ((x, y, z), totalSum) ->
            printfn "Найдена тройка: x = %d, y = %d, z = %d, сумма = %d" x y z totalSum
        | None ->
            printfn "Ничего не найдено"
    0