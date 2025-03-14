Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Products
    Public Sub New()
        SaleItems = New HashSet(Of SaleItems)()
    End Sub

    Public Property Id As Integer

    <Required>
    <StringLength(255)>
    Public Property Name As String

    Public Property Price As Double?

    <StringLength(255)>
    Public Property Category As String

    Public Overridable Property SaleItems As ICollection(Of SaleItems)
End Class
