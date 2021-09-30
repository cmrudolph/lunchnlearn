module Currying

// val printTwoParametersa : x:int -> y:int -> unit
let printTwoParametersa x y =
   printfn "x=%i y=%i" x y

// explicitly curried version (how the compiler rewrites it)
// val printTwoParametersb : x:int -> (int -> unit)
let printTwoParametersb x =
    let subFunction y =
        printfn "x=%i y=%i" x y
    subFunction

// By doing this, the compiler is ensuring that functions only have one parameter

// Here is an example of using the explicitly curried version
let x = 2
let y = 3
let curried = printTwoParametersb x
curried y

// Back to the original "two parameter" version. What happens when we call it without all the parameters specified?
// val whatIsThis : (int -> unit)
let whatIsThis = printTwoParametersa x

// The function is partially applied. All functions in F# support implicit currying. When you call a function with fewer