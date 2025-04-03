module CoprimeOperations

let rec gcd a b =
    match b with
    | 0 -> a
    | _ -> gcd b (a % b)


let coprimeOperation number op init =
    let rec applyOp result x =
        if x >= number then result
        else
            if gcd number x = 1 then
                applyOp (op result x) (x + 1)
            else
                applyOp result (x + 1)
    applyOp init 1

let userInputOperation number op =
    coprimeOperation number op 0