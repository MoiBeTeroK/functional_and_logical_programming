module CountDivNotDivByThree

let countDivNotDivByThree n =
    let rec run n divisor count =
        match divisor with
        | divisor when divisor > n -> count
        | _ when n % divisor = 0 && divisor % 3 <> 0 -> run n (divisor + 1) (count + 1)
        | _ -> run n (divisor + 1) count
    run n 1 0