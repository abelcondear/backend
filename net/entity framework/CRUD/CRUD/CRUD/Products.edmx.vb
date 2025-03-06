Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class ClsProducts
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=fdf0000")
    End Sub

    Public Overridable Property Clients As DbSet(Of Clients)
    Public Overridable Property Products As DbSet(Of Products)
    Public Overridable Property SaleItems As DbSet(Of SaleItems)
    Public Overridable Property Sales As DbSet(Of Sales)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Clients)() _
            .Property(Function(e) e.Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clients)() _
            .Property(Function(e) e.Phone) _
            .IsUnicode(False)

        REM modelBuilder.Entity(Of ItemResult)() _
        REM .Property(Function(e) e.Name) _
        REM .IsUnicode(False)

        modelBuilder.Entity(Of Clients)() _
            .Property(Function(e) e.Mail) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Clients)() _
            .HasMany(Function(e) e.Sales) _
            .WithRequired(Function(e) e.Clients) _
            .HasForeignKey(Function(e) e.IdClient) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Products)() _
            .Property(Function(e) e.Name) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Products)() _
            .Property(Function(e) e.Category) _
            .IsUnicode(False)

        modelBuilder.Entity(Of Products)() _
            .HasMany(Function(e) e.SaleItems) _
            .WithRequired(Function(e) e.Products) _
            .HasForeignKey(Function(e) e.IdProduct) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Sales)() _
            .HasMany(Function(e) e.SaleItems) _
            .WithRequired(Function(e) e.Sales) _
            .HasForeignKey(Function(e) e.IdSale) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
