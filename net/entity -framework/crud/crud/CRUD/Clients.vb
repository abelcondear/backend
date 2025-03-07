Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Clients
    Public Sub New()
        Sales = New HashSet(Of Sales)()
    End Sub

    Public Property Id As Integer

    <Required>
    <StringLength(255)>
    Public Property Name As String

    <StringLength(255)>
    Public Property Phone As String

    <StringLength(255)>
    Public Property Mail As String

    Public Overridable Property Sales As ICollection(Of Sales)
End Class
