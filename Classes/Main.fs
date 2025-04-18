open System
open GeometryShapes
open Figures
open Maybe

[<EntryPoint>]
let main argv =
    // 1 задание
    // let rectangle = new Rectangle(2.0, 6.0)
    // let square = new Square(5.0)
    // let circle = new Circle(4.5)

    // printfn "Реализация метода ToString():"
    // printfn "%s" (rectangle.ToString())
    // printfn "%s" (square.ToString())
    // printfn "%s" (circle.ToString())

    // let printInformation (shape: IPrint) =
    //     shape.Print()
 
    // printfn "Реализация метода интерфейса:"
    // printInformation rectangle
    // printInformation square
    // printInformation circle

    // printfn "Площадь прямоугольника: %.2f" (areaShape rectangle)
    // printfn "Площадь квадрата: %.2f" (areaShape square)
    // printfn "Площадь круга: %.2f" (areaShape circle)

    // 2 задание
    checkFunctorLaws()
    checkApplicativeLaws()
    checkMonadLaws()
 

    0