module ChooseFunction
open CountDivNotDivByThree
open FindMinOddDigit
open SumOfSpecialDivisors

let chooseFunction n =
    match n with
    | 1 -> countDivNotDivByThree
    | 2 -> findMinOddDigit
    | 3 -> sumOfSpecialDivisors
    | _ -> failwith "Неверный номер функции"
