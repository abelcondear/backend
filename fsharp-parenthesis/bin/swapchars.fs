module swapchars

// ---------------------------
//Task: Converting this string into new one where the parenthesis are balanced
// ---------------------------

open System.IO
open System
open pluseq

module rchr = replacechrat
module lk = lookup

let swap input: string =
    //function body
    //let blank = " "
    let mutable output = ""
    let mutable count = 0

    let mutable oparentheses_pos = 0
    let mutable cparentheses_pos = 0

    output <- input //copy input

    for chr in input do 
        &count += 1    

        if chr = '(' then ( 
            //output <- rchr.re output blank count //replace current char by blank 
            output <- rchr.re output "[" count //replace current char by blank 

            //printf "****|%d|%d|%d|\n" count (count+1) input.Length

            if count <= input.Length then ( //not greater than string length          
                oparentheses_pos <- count //from current position
                cparentheses_pos <- lk.lookup_close input oparentheses_pos

                (*
                we should take into account we are expecting pair parentheses which its 
                corresponding opening and closing parentheses ( "(" and ")" )
                in case, this is not happening then we should ignore it
                *)

                //printf "|%s|%d|%d|\n" input count cparentheses_pos

                if cparentheses_pos = 0 then (                 
                    oparentheses_pos <- count //current position. it reads this parentheses "(".
                    cparentheses_pos <- lk.lookup_close input 1 //look for this parentheses ")" from the start

                    output <- rchr.re output ")" oparentheses_pos //swap parenthesis, from opening to closing parenthesis
                    output <- rchr.re output "(" cparentheses_pos //swap parenthesis, from closing to opening parenthesis
                )
                else (            
                    //output <- rchr.re output blank cparentheses_pos
                    output <- rchr.re output "]" cparentheses_pos
                )
            )
                    
                    
        )

    output <- output.Replace("[", "(").Replace("]", ")")
    output

