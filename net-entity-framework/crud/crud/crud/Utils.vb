Imports CRUD.SearchTypeException

Module Utils
    Public Enum SearchType
        Alpha = 0
        Numeric = 1
        AlphaNumeric = 2
    End Enum

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
