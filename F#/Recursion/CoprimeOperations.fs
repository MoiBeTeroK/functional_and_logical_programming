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


let eulerPhi n =
    coprimeOperation n (fun acc x -> acc + 1) 0


let coprimeWithCondition number condition =
    let rec applyCondition x result =
        if x >= number then result
        else
            if gcd number x = 1 && condition x then
                applyCondition (x + 1) (List.append result [x])
            else
                applyCondition (x + 1) result
    applyCondition 1 []