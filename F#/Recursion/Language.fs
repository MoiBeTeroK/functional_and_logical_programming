module Language
open System

let question language =
    match language with
    | "F#" | "Prolog" -> "Вы подлиза"
    | "Ruby" -> "Класс, не верю"
    | "Python" -> "Предсказуемый выбор"
    | "C++" -> "Любите страдать, понимаю"
    | _ -> "Интересно..."

let super = Console.ReadLine >> question >> Console.WriteLine

let curry () = 
    let run input f output =
        let inp = input()
        let res = f inp
        output res
    run Console.ReadLine question Console.WriteLine