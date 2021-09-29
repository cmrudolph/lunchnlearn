module Mathematical

// val add1 : x:int -> int
let add1 x = x + 1

// val add2 : x:int64 -> int64
let add2 x = x + 2L

// val add3 : x:float -> float
let add3 x = x + 3.0

// - A function maps a domain onto a range. In this case, add1 maps integers onto integers
// - F# inferred the types for us. Unlike C#, we did not need to tell the compiler that we were
//   working with ints
// - A mathematical function always gives the same output for a given input
// - A mathematical function has no side effects. It cannot affect the input or anything else

// Functions with consistent behavior and no side effects are called "pure" functions. These have benefits:
// - They are easy to parallelize
// - They can be lazy evaluated (same result whether invoked now or later)
// - Their results can be cached (they always produce the same output)