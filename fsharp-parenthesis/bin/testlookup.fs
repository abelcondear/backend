module testlookup

open System.IO
open System

open pluseq
open lookup 

let input = ")()()()("
let start_position = 1

let mutable pos_open = lookup_open input start_position

let mutable while_continue = true
while while_continue do
    pos_open <- lookup_open input pos_open
    if pos_open = 0 then ( while_continue <- false )
    else ( printf "openings counter=%d\n" pos_open )

    if while_continue && pos_open < input.Length then ( 
        &pos_open += 1 //move next position

        let key = System.Console.ReadKey(true)
        if key.KeyChar.Equals(ConsoleKey.Enter) then ( while_continue <- false )    
    )
    else ( 
        while_continue <- false 
    )

printf "\n\n"
let mutable pos_close = lookup_close input start_position

while_continue <- true
while while_continue do
    pos_close <- lookup_close input pos_close
    if pos_close = 0 then ( while_continue <- false )
    else ( printf "closings counter=%d\n" pos_close )
    
    if while_continue && pos_close < input.Length then ( 
        &pos_close += 1 //move next position

        let key = System.Console.ReadKey(true)
        if key.KeyChar.Equals(ConsoleKey.Enter) then ( while_continue <- false )        
    )
    else ( 
        while_continue <- false 
    )

