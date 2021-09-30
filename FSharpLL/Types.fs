module Types

// These are more than just cosmetic type aliases. Even though both are ultimately strings, these are not interchangeable types
type Routing = Routing of string
type AccountNumber = AccountNumber of string

let routing = Routing "123"
let account = AccountNumber "123"

let printRouting (routing : Routing) =
    printfn "%A" routing

printRouting routing
// printRouting account

// This is a record type. C# now has these (as of C# 9). They are by default immutable and also come with free structural equality
// logic built in.
type CreditCardInfo =
    { CardNumber: string;
      ExpirationMonth: int;
      ExpirationYear: int;
      CVV: int }

// This is a discriminated union type. A PaymentMethod must be one of the three available options. Furthermore, each of these options can
// have its own properties attached. Despite having different "shapes", the results all satisfy the requirements of being a PaymentMethod
// (from a data type perspective). Logic working with a PaymentMethod needs to be able to handle all forms.
type PaymentMethod =
    | Cash
    | Check of Routing * AccountNumber
    | CreditCard of CreditCardInfo

// Here we are creating instances of our discriminated union type
let cashPayment = PaymentMethod.Cash
let checkPayment = PaymentMethod.Check (Routing "123", AccountNumber "456")

// Here we are creating an instance of our record type. Notice that the type is inferred based on the properties we are passing in.
let cardInfo = { CardNumber = "1234"; CVV = 888; ExpirationMonth = 10; ExpirationYear = 2021 }

// Here we are modifying our record instance. Since records are immutable, this does not change the original. Instead, it returns a
// new instance with changes applied to it. The 'with' keyword allows us to change only a subset of the record's data and keep the
// rest of the values intact
let updatedCardInfo = { cardInfo with ExpirationYear = 2025 }

let cardPayment = PaymentMethod.CreditCard (cardInfo)

// Here is an example of a function that can operate on payment methods. Notice we are using pattern matching to handle all the cases
// of the union type. In the pattern match we are also handling the properties attached to the union case (routing number, etc.)
let processPayment payment =
    match payment with
    | Cash -> printfn "Paying with cash"
    | Check (routing, acct) -> printfn "Paying with check -- %A | %A" routing acct
    | CreditCard info -> printfn "Paying with card -- %s | %i | %i/%i" info.CardNumber info.CVV info.ExpirationMonth info.ExpirationYear

processPayment cashPayment
processPayment checkPayment
processPayment cardPayment