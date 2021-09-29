module Values

// The "let" keyword is used to bind a name to something. In this case, we are binding the names below to
// functions. Both name point to the same thing (a function that adds 1 to an integer)
let add1 x = x + 1
let plus1 = add1

// Invoking functions is as simple as replacing the variable (x) with a suitable value. Here we are ignoring
// the result of the function (useless)
add1 5

// Here we are capturing the result of the function and binding it to a new name (sum)
let sum = plus1 5

// We can also bind constants to names
let five = 5

let ``this is a crazy name!`` = 6
let sum2 = plus1 ``this is a crazy name!``

// When is this crazy nonsense useful? Naming things like test methods is a good case. Also, situations where
// you want to express domain rules via natural language or when creating custom domain languages:
//   let [<Test>] ``When input is 2 then expect square is 4``=

// We will later see that functions are also values that can be passed around just like "simple" values

// Values vs Objects
// - A value is a member of a domain
// - A value is usually immutable
// - A value does not have behavior attached
// - An object encapsulates data and assocaited behavior
// - An object usually has state (often mutable)
// - An object's behavior is usually accessed on the object (via dot methods)

