// ---------------------------
//Task: Converting this string into new one where the parenthesis are balanced
// ---------------------------

open System.IO
open System

open pluseq

module sw = swapchars

let input = ")()()()("

printf "Swaping parentheses.\n\n"

printf "input=%s\n" input
printf "output=%s\n" ( sw.swap input )

printf "\nEnding ...\n"
System.Console.ReadKey(true) |> ignore 

exit(0)

