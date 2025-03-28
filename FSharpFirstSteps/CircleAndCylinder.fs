module CircleCylinder
open System

let circleArea rasius =
    Math.PI * rasius * rasius

let cylinderVolume_curry radius height =
   circleArea radius * height

let multiplyArea area height =
    area * height

let cylinderVolume_superpos = circleArea >> multiplyArea