Imports CRUD.SearchTypeException

Module Utils
    Public Enum SearchType
        Alpha = 0
        Numeric = 1
        AlphaNumeric = 2
    End Enum

    REM ---

    REM 'Add the following directive to your file:
    REM 'Imports System.Linq.Expressions  

    REM Public Class SampleClass
    REM     Public Function AddIntegers(ByVal arg1 As Integer, ByVal arg2 As Integer) As Integer
    REM         Return (arg1 + arg2)
    REM     End Function
    REM End Class
    REM Public Shared Sub TestCall()
    REM     'This expression represents a call to an instance method that has two arguments.
    REM     'The first argument is an expression that creates a new object of the specified type.
    REM     
    REM     Dim callExpr As Expression = Expression.Call(
    REM         Expression.[New](GetType(SampleClass)),
    REM         GetType(SampleClass).GetMethod("AddIntegers", New Type() {GetType(Integer), GetType(Integer)}),
    REM         Expression.Constant(1),
    REM         Expression.Constant(2)
    REM     )

    REM     'Print the expression.
    REM     Console.WriteLine(callExpr.ToString())

    REM     'The following statement first creates an expression tree,
    REM     'then compiles it, and then executes it.
    REM     
    REM     Console.WriteLine(Expression.Lambda(Of Func(Of Integer))(callExpr).Compile()())
    REM End Sub()

    REM 'This code example produces the following output:
    REM
    REM 'new SampleClass().AddIntegers(1, 2)
    REM '3

    REM ---

    REM public System.Linq.Expressions.Expression<Func<Charity, bool>> IsSatisfied()
    REM {
    REM     String name = this.charityName;
    REM     String referenceNumber = this.referenceNumber;
    REM     Return p >=
    REM         (String.IsNullOrEmpty(name) || 
    REM             p.registeredName.ToLower().Contains(name.ToLower()) ||
    REM             p.alias.ToLower().Contains(name.ToLower()) ||
    REM             p.charityId.ToLower().Contains(name.ToLower())) &&
    REM         (string.IsNullOrEmpty(referenceNumber) ||
    REM             p.charityReference.ToLower().Contains(referenceNumber.ToLower()));
    REM }

    REM ---

    Public Function FindWholeText(Text As String, TextToSearch As String, Type As SearchType) As Boolean
        Dim Chr, ChrB As Char

        For Each Chr In TextToSearch.ToArray()
            If Type = SearchType.Alpha And Not ((Asc(Chr) >= 65 And Asc(Chr) <= 90) Or (Asc(Chr) >= 97 And Asc(Chr) <= 122)) Then REM 65 - 90 / 97 - 122
                Throw New SearchTypeException("Paramater TextToSearch is not an alphabetical value.")
                Exit For
            ElseIf Type = SearchType.Numeric And Not (Asc(Chr) >= 48 And Asc(Chr) <= 57) Then REM 48 - 57
                Throw New SearchTypeException("Paramater TextToSearch is not a numeric value.")
                Exit For
            ElseIf Type = SearchType.AlphaNumeric And Not ((Asc(Chr) >= 65 And Asc(Chr) <= 90) Or (Asc(Chr) >= 97 And Asc(Chr) <= 122) Or (Asc(Chr) >= 48 And Asc(Chr) <= 57)) Then REM 65 - 90 / 97 - 122 | 48 - 57
                Throw New SearchTypeException("Paramater TextToSearch is not an alphanumeric value.")
                Exit For
            End If
        Next

        Dim Length As Integer = TextToSearch.Length
        Dim Counter As Integer
        Dim Completed As Boolean = False
        Dim Corrected As Boolean = False

        Dim Input = Text.ToArray()
        Dim Index As Integer = 0
        Dim Iteration As Integer = 0

        For Each Chr In Text.ToArray()
            REM Counter = 0

            REM Index = StartIndex

            If Completed And Index > Input.Length - 1 Then
                Corrected = True
                Exit For
            ElseIf Completed And Iteration >= Index Then
                If Type = SearchType.Alpha Then REM 65 - 90 / 97 - 122
                    If Not ((Asc(Chr) >= 65 And Asc(Chr) <= 90) Or (Asc(Chr) >= 97 And Asc(Chr) <= 122)) Then
                        Corrected = True
                        Exit For
                    Else
                        Corrected = False
                        Exit For
                    End If
                ElseIf Type = SearchType.Numeric Then REM 48 - 57
                    If Not (Asc(Chr) >= 48 And Asc(Chr) <= 57) Then
                        Corrected = True
                        Exit For
                    Else
                        Corrected = False
                        Exit For
                    End If
                ElseIf Type = SearchType.AlphaNumeric Then REM 65 - 90 / 97 - 122 | 48 - 57
                    If Not ((Asc(Chr) >= 65 And Asc(Chr) <= 90) Or (Asc(Chr) >= 97 And Asc(Chr) <= 122) Or (Asc(Chr) >= 48 And Asc(Chr) <= 57)) Then
                        Corrected = True
                        Exit For
                    Else REM Chr is alphanumeric then it should be discarded
                        Corrected = False
                        Exit For
                    End If
                End If
            ElseIf Completed = False And Index < Input.Length - 1 Then
                REM Counter = 0
                For Each ChrB In TextToSearch.ToArray()
                    Counter = If(Input(Index) = ChrB, Counter + 1, 0) REM counter : no zero-based value
                    Index += 1

                    If Index < Input.Length - 1 Then Index += 1

                    If Counter = 0 Then
                        Exit For REM no need to continue searching for char matching
                    End If

                    If Length = Counter Then REM all chars found
                        Completed = True
                        Exit For
                    End If
                Next
            End If

            Iteration += 1
        Next

        Return Completed And Corrected
    End Function
End Module
