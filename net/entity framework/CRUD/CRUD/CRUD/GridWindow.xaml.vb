

Public Class GridWindow
    Public Sub New()

        Dim ObProduct As ClsProducts = New ClsProducts

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = ObProduct

        REM Dim ItemSearchProducts = (
        REM From p In ObProduct.Products
        REM Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
        REM Join b In ObProduct.Sales On v.IdSale Equals b.Id
        REM Join c In ObProduct.Clients
        REM On b.IdClient Equals c.Id
        REM )

        Dim ItemSearchProducts As List(Of Products) = (
                From p In ObProduct.Products
        ).ToList()
        REM Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct

        REM Dim listDataSource As List(Of ItemResult)

        REM Dim Item = New ItemResult
        REM Item.Name = "Favio"
        REM Item.Age = 54

        REM listDataSource.Add(Item)

        dataGrid.ItemsSource = ItemSearchProducts
        REM listDataSource.ItemSource = listDataSource

    End Sub
End Class
