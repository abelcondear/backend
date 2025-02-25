module replacechrat

open pluseq

let re str chr position: string =
    //function body
    let mutable retval =""
    let mutable count = 0

    for c in str do
        &count += 1

        if count = position then ( retval <- retval + chr )
        else ( retval <- retval + c.ToString() )

    retval


(*
let replacecharat str chr position: string = 
    //function body
    let mutable retval = ""
    let mutable count = 0
    
    for c in str do
        &count += 1

        if count = position then ( &retval += chr )
        else ( &retval += c )

    retval
 *)

