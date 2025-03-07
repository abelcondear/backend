
Imports CRUD.ItemResult

Public Class GridWindow
    Public Sub New()

        Dim ObProduct As ClsProducts = New ClsProducts

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        REM Me.DataContext = ObProduct

        Dim ListItems As List(Of ItemResult) = New List(Of ItemResult)

        Dim ItemSearchProducts = (
        From p In ObProduct.Products
        Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
        Join b In ObProduct.Sales On v.IdSale Equals b.Id
        Join c In ObProduct.Clients
        On b.IdClient Equals c.Id
        ).ToList()


        REM dataGrid.ItemsSource = ItemSearchProducts

        For Each Item In ItemSearchProducts
            ListItems.Add(New ItemResult() With {.Client = Item.c.Name, .Product = Item.p.Name, .UnitPrice = Item.v.UnitPrice, .Quantity = Item.v.Quantity.ToString(), .Total = Item.v.TotalPrice.ToString()})
        Next

        dataGrid.ItemsSource = ListItems
    End Sub
End Class
