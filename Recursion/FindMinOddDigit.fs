module FindMinOddDigit

let findMinOddDigit n =
    let rec findMin n minDigit =
        match n with
        | 0 -> minDigit
        | _ when n % 10 % 2 <> 0 -> 
            findMin (n / 10) (if minDigit = -1 then n % 10 else min minDigit (n % 10))
        | _ -> findMin (n / 10) minDigit
    findMin n -1