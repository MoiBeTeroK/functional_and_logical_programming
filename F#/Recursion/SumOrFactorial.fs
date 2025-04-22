module SumOrFactorial

let factorial num =
    let rec factorialtLoop mult num =
        match num with
        | 0 -> mult
        | _ -> factorialtLoop (mult * num) (num - 1)
    factorialtLoop 1 num

let rec sumDigitsUp n =
    match n with
    | 0 -> 0
    | _ -> (n % 10) + sumDigitsUp (n / 10)


let SumOrFact trueFalse =
    match trueFalse with
    | true -> sumDigitsUp
    | false -> factorial