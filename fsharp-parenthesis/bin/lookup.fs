module lookup

open pluseq

let lookup_open str start_from: int32 =
    //function body
    let mutable retval = 0
    let mutable count = 0
    let mutable flag = false

    for chr in str do
        &count += 1

        if count = start_from then (
            flag <- true
        )

        if chr = '(' && flag then (
            flag <- false
            retval <- count            
        )

    retval

let lookup_close str start_from: int32 =
    //function body
    let mutable retval = 0
    let mutable count = 0
    let mutable flag = false

    for chr in str do
        &count += 1

        if count = start_from then (
            flag <- true
        )

        if chr = ')' && flag = true then (
            flag <- false
            retval <- count                       
        )

    retval



