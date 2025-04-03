module Language
open System

let question language =
    match language with
    | "F#" | "Prolog" -> "Вы подлиза"
    | "Ruby" -> "Класс, не верю"
    | "Python" -> "Предсказуемый выбор"
    | "C++" -> "Любите страдать, понимаю"
    | _ -> "Интересно..."
