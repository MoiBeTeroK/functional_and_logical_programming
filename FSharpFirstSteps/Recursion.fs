module Recursion

let rec sumDigitsUp n =
    if n = 0 then 0
    else (n%10) + sumDigitsUp (n/10)

let sumDigitsDown n =
    let rec loop n currentSum =
        if n = 0 then currentSum
        else loop (n / 10) (currentSum +  n % 10 )
    loop n 0