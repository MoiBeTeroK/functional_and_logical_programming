module SumOfSpecialDivisors
open CoprimeOperations

// let sumOfSpecialDivisors n =
//     let digitsStr = n.ToString()
//     let digits = [for c in digitsStr -> int (string c)]
//     let sumDigits = List.sum digits
//     let prodDigits = List.reduce (*) digits
//     let rec gcd a b =
//         match b with
//         | 0 -> abs a
//         | _ -> gcd b (a % b)
    
//     let rec findDivisors d total =
//         if d > n then total
//         else 
//             let newTotal = 
//                 if n % d = 0 && gcd d sumDigits = 1 && gcd d prodDigits <> 1 then 
//                     total + d 
//                 else total
//             findDivisors (d + 1) newTotal
    
//     findDivisors 1 0


// Функция для извлечения цифр числа
let getDigits n =
    [for c in n.ToString() -> int (string c)]

// Функция для вычисления суммы цифр
let sumOfDigits digits =
    List.sum digits

// Функция для вычисления произведения цифр
let productOfDigits digits =
    List.reduce (*) digits

// Функция для нахождения делителей числа с учетом условий задачи
let rec findDivisors d total n sumDigits prodDigits =
    if d > n then total
    else 
        let newTotal = 
            if n % d = 0 && gcd d sumDigits = 1 && gcd d prodDigits <> 1 then 
                total + d 
            else total
        findDivisors (d + 1) newTotal n sumDigits prodDigits

// Главная функция для нахождения суммы специальных делителей
let sumOfSpecialDivisors n =
    let digits = getDigits n
    let sumDigits = sumOfDigits digits
    let prodDigits = productOfDigits digits
    findDivisors 1 0 n sumDigits prodDigits