Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class Sales
    Public Sub New()
        SaleItems = New HashSet(Of SaleItems)()
    End Sub

    Public Property Id As Integer

    Public Property IdClient As Integer

    <Column("Date")>
    Public Property _Date As Date?

    Public Property Total As Double?

    Public Overridable Property Clients As Clients

    Public Overridable Property SaleItems As ICollection(Of SaleItems)
End Class
