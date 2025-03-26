open System

type SolveResult =
    None
    | Linear of float
    | Quadratic of float*float

let solve a b c =
    let D = b * b - 4.0 * a * c
    if a = 0.0 then
        if b = 0.0 then None
        else Linear(-c / b)
    else
        if D < 0.0 then None
        else Quadratic((((-b + sqrt(D)) / (2.0 * a)), ((-b - sqrt(D)) / (2.0 * a))))

// let res : SolveResult = solve 1.0 2.0 3.0 // нет решений
// let res : SolveResult = solve 1.0 -5.0 6.0 // 2 корня
let res : SolveResult = solve 0.0 2.0 -3.0 //1 корень
match res with 
    | None -> Console.WriteLine("Нет решений") 
    | Linear x -> Console.WriteLine("Один корень: {0}", x)
    | Quadratic (x1, x2) -> Console.WriteLine("Два корня: {0} и {1}", x1, x2)