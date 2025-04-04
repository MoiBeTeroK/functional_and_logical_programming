module SumOfSpecialDivisors

let sumOfSpecialDivisors n =
    let digitsStr = n.ToString()
    let digits = [for c in digitsStr -> int (string c)]
    let sumDigits = List.sum digits
    let prodDigits = List.reduce (*) digits
    let rec gcd a b =
        match b with
        | 0 -> abs a
        | _ -> gcd b (a % b)
    
    let rec findDivisors d total =
        if d > n then total
        else 
            let newTotal = 
                if n % d = 0 && gcd d sumDigits = 1 && gcd d prodDigits <> 1 then 
                    total + d 
                else total
            findDivisors (d + 1) newTotal
    
    findDivisors 1 0