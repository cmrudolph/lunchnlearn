module TypesFunctions

// val intToString : x:int -> string
let intToString x = sprintf "x is %i" x

// val stringToInt : x:string -> int
let stringToInt x = System.Int32.Parse(x)

// val intToFloat : x:int -> float
let intToFloat x = float x

// val intToBool : x:int -> bool
let intToBool x = (x = 2)

// val stringToString : x:string -> string
let stringToString x = x + " world"

// Sometimes the compiler is not able to infer types correctly. The definition below is a good example
// let stringLength x = x.Length

// Here we need to use a type annotation. Type annotations are always an option, but sometimes become required
let stringLength (x:string) = x.Length

// You can also specify a type annotation for the return value
let stringLengthAsInt (x:string) :int = x.Length

// val evalWith5ThenAdd2 : (int -> int) -> int
let evalWith5ThenAdd2 fn = fn 5 + 2

// Here we see our first higher-order function. This is a VERY common thing in functional programming. The parameter
// is not a simple value, but a function. This function can be called as long as we pass a function that accepts and
// returns an int

let add1 x = x + 1

// Here we are invoking our higher-order function successfully by passing in a function that meets its requirements
evalWith5ThenAdd2 add1

let times2 x = x * 2

evalWith5ThenAdd2 times2

// val adderGenerator : numberToAdd:int -> (int -> int)
let adderGenerator numberToAdd = (+) numberToAdd

// And now we see functions that produce other functions as output. Given an integer, this function will produce a
// function that can map integers onto integers

let generatedAdd1 = adderGenerator 1
let generatedAdd2 = adderGenerator 2

// I have now created two int -> int functions, each with different baked-in behavior