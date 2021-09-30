module PartialApplication

// create an "adder" by partial application of add
// val add42 : (int -> int)
let add42 = (+) 42
add42 1
add42 3

// create a new list by applying the add42 function to each element
// (List.map looks like this -- val it : (('a -> 'b) -> 'a list -> 'b list)
//   First parameter is a function that transforms 'a to 'b (generics)
//   Second parameter is a list of 'a (the list to transform)
//   Output is a list of 'b (the transformed list)
List.map add42 [1;2;3]

// create a "tester" by partial application of "less than"
// val twoIsLessThan : (int -> bool)
let twoIsLessThan = (<) 2
twoIsLessThan 1
twoIsLessThan 3

// filter each element with the twoIsLessThan function
List.filter twoIsLessThan [1;2;3]

// create a "printer" by partial application of printfn
let printer = printfn "printing param=%i"

// loop over each element and call the printer function
List.iter printer [1;2;3]

// create an adder that supports a pluggable logging function
// logger:(string -> int -> unit) -> x:int -> y:int -> int
// Here, the first parameter is the 'injected' logger implementation (a function that receives a string and an int and returns unit)
let adderWithPluggableLogger logger x y =
  logger "x" x
  logger "y" y
  let result = x + y
  logger "x+y"  result
  result

// create a logging function that writes to the console
let consoleLogger argName argValue =
  printfn "%s=%A" argName argValue

// create an adder with the console logger partially applied
let addWithConsoleLogger = adderWithPluggableLogger consoleLogger
addWithConsoleLogger 1 2
addWithConsoleLogger 42 99

// The above should suggest that parameter order matters more in F# than in other languages. Partial application works from
// left to right, meaning the things that are intended to be "baked in" should come first.

// Now is also a good time to talk about the pipeline. F# has a special syntax where the return value from a step can be piped into
// another function. The important thing to understand about this is that the piped value goes to the LAST parameter in the next
// function. Designing functions to work with piped data requires considering this parameter order requirement (e.g. these list
// transformation functions take the list as the last parameter)
[1;2;3;4]
|> List.filter twoIsLessThan
|> List.map add42
|> List.iter printer