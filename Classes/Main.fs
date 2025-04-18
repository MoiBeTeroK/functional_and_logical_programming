open System
open GeometryShapes

[<EntryPoint>]
let main argv =
    let rectangle = new Rectangle(5.0, 3.0)
    let square = new Square(4.0)
    let circle = new Circle(2.5)

    printfn "Реализация метода ToString():"
    printfn "%s" (rectangle.ToString())
    printfn "%s" (square.ToString())
    printfn "%s" (circle.ToString())

    let printInformation (shape: IPrint) =
        shape.Print()
 
    printfn "Реализация метода интерфейса:"
    printInformation rectangle
    printInformation square
    printInformation circle

    0