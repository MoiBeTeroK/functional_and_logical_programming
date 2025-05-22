open System
let isPerfectSquare n =
    let root = int (sqrt (float n))
    root * root = n

let trySolution a c e =
    let aa = a * a
    let cc = c * c
    let ee = e * e

    let ff = aa - cc
    let bb = cc - ee
    let dd = bb + ff

    if isPerfectSquare ff && isPerfectSquare bb && isPerfectSquare dd then 
        let x2 = cc + dd
        let y2 = ee + ff
        let z2 = cc - dd

        if x2 % 2 = 0 && y2 % 2 = 0 && z2 % 2 = 0 then
            let x = x2 / 2
            let y = y2 / 2
            let z = z2 / 2

            if z > 0 && x > y && y > z then
                Some (x, y, z)
            else None
        else None
    else None

let rec generateCombinations a =
    seq {1..a-1} |> Seq.collect (fun c -> seq {1..c-1} |> Seq.map (fun e -> (a, c, e)))
    |> Seq.append <| seq {
        yield! generateCombinations (a + 1)
    }

let findFirstSolution () = generateCombinations 2|> Seq.tryPick (fun (a, c, e) -> trySolution a c e)

let printSolution (x, y, z) =
    printfn "x = %d y = %d z = %d" x y z
    printfn "x + y + z = %d" (x + y + z)

[<EntryPoint>]
let main argv =
    match findFirstSolution () with
    | Some solution -> printSolution solution
    | None -> printfn "No solution found"
    0