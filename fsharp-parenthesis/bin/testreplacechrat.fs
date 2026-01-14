module testreplacechrat

open replacechrat
open Xunit

[<Fact>]
let ``description of first unit test`` () =
    <@ (11 + 3) / 2 = String.length ("hello world".Substring(4, 5)) @>

[<Fact>]
let ``description of second unit test`` () =
    let x = List.rev [1;2;3;4]
    <@ x = [4;3;1;2] @>