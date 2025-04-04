module ProcessDigits

let rec processDigits num (func: int->int->int) acc =
    match num with
    | 0 -> acc
    | _ -> processDigits (num / 10) func (func acc (num % 10))