module ProcessDigits

let rec processDigits num (func: int->int->int) acc =
    match num with
    | 0 -> acc
    | _ -> processDigits (num / 10) func (func acc (num % 10))


let rec processDigitsCondition num (func: int->int->int) acc (condition: int->bool) =
    match num with 
    | 0 -> acc
    | _ ->
        let trueFalse = condition (num % 10)
        match trueFalse with
        | true -> processDigitsCondition (num / 10) func (func acc (num % 10)) condition
        | false -> processDigitsCondition (num / 10) func acc condition