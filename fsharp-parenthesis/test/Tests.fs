module Tests

open Xunit

module sw = swapchars

[<Fact>]
let ``Testing swaping parentheses. Text: ")()()()(". Expected result: "(()()())"`` () =
    //body function
    Assert.True( sw.swap ")()()()(" = "(()()())" )

[<Fact>]
let ``Testing swaping parentheses. Text: ")()(((()()(". Expected result: "(()(((()())"`` () =
    //body function
    Assert.True( sw.swap ")()(((()()(" = "(()(((()())" )

[<Fact>]
let ``Testing swaping parentheses. Text: "((()))". Expected result: "((()))"`` () =
    //body function
    Assert.True( sw.swap "((()))" = "((()))" )

[<Fact>]
let ``Testing swaping parentheses. Text: "(((())(". Expected result: "((((())"`` () =
    //body function
    Assert.True( sw.swap "(((())(" = "((((())" )
    
