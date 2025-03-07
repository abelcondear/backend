Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

Partial Public Class SaleItems
    Public Property Id As Integer

    Public Property IdSale As Integer

    Public Property IdProduct As Integer

    Public Property UnitPrice As Double?

    Public Property Quantity As Double?

    Public Property TotalPrice As Double?

    Public Overridable Property Products As Products

    Public Overridable Property Sales As Sales
End Class
