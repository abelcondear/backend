Class MainWindow
    Private Sub CmdSale_Click(sender As Object, e As RoutedEventArgs) Handles CmdSale.Click
        Dim ObProducts As ClsProducts = New ClsProducts
        Dim ObSales As ClsProducts = New ClsProducts

        Dim QueryProducts As IQueryable(Of Products)
        Dim QueryClients As IQueryable(Of Clients)

        Dim ListClientName As List(Of String) = New List(Of String)
        Dim ListProductName As List(Of String) = New List(Of String)

        Dim ClientName As String = "Coke"
        ListClientName.Add("Coke")
        ListClientName.Add("Pepsi")

        Dim ProductName As String = "Coke Zero"
        ListProductName.Add("Coke Zero")
        ListProductName.Add("Coke Classic")
        ListProductName.Add("Pepsi Zero")
        ListProductName.Add("Pepsi Classic")

        Dim p As String = String.Join(",", ListProductName.ToArray())
        Dim c As String = String.Join(",", ListClientName.ToArray())

        QueryProducts = ObProducts.Products.Where(Function(product) p.IndexOf(product.Name) <> -1)
        QueryClients = ObSales.Clients.Where(Function(client) c.IndexOf(client.Name) <> -1)

        Dim Rnd As New Random

        Dim ItemSaleItems As SaleItems = New SaleItems
        Dim ItemSales As Sales = New Sales

        Dim ListItemSaleItems As List(Of SaleItems) = New List(Of SaleItems)

        Dim ListOutter As List(Of Clients) = QueryClients.ToList()
        Dim ListInner As List(Of Products) = QueryProducts.ToList()

        REM Dim IdProduct As Integer
        REM Dim UnitPrice As Double
        Dim Quantity As Integer
        Dim IncrementedTotal As Double = 0.0

        Dim MaxAmount As Integer = 0
        Dim MaxQuantity As Integer = 9
        Dim RndValue As Double = 0.0
        Dim Count As Integer

        For Each ItemOutter In ListOutter
            Count = 0
            IncrementedTotal = 0.0

            RndValue = Math.Floor(((Rnd.NextDouble() * (ListInner.Count() - 1.0)) + 1.0))
            MaxAmount = Convert.ToInt32(RndValue)
            ListItemSaleItems.Clear()

            For Each ItemInner In ListInner
                Count = Count + 1

                RndValue = Math.Floor(((Rnd.NextDouble() * (MaxQuantity - 1.0)) + 1.0))

                Quantity = Convert.ToInt32(RndValue)

                ItemSaleItems = New SaleItems REM Create new instance on every iteration so that it allocates data into a new memory space
                ItemSaleItems.IdProduct = ItemInner.Id
                ItemSaleItems.UnitPrice = ItemInner.Price
                ItemSaleItems.Quantity = Quantity
                ItemSaleItems.TotalPrice = ItemInner.Price * Quantity

                ListItemSaleItems.Add(ItemSaleItems)

                IncrementedTotal += ItemSaleItems.TotalPrice

                If Count = MaxAmount Then
                    ItemSales.IdClient = ItemOutter.Id
                    ItemSales._Date = Now()
                    ItemSales.Total = IncrementedTotal

                    ObProducts.Sales.Add(ItemSales)
                    ObProducts.SaveChanges()

                    For Each Item In ListItemSaleItems

                        Item.IdSale = ItemSales.Id

                        ObSales.SaleItems.Add(Item)
                        ObSales.SaveChanges()
                    Next

                    Exit For

                End If
            Next

        Next

        MessageBox.Show("Sale added.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        LoadData()
    End Sub

    Private Sub CmdFind_Click(sender As Object, e As RoutedEventArgs) Handles CmdFind.Click
        Dim ObProduct As ClsProducts = New ClsProducts
        Dim ItemClients As IQueryable(Of Clients)
        Dim ItemProducts As IQueryable(Of Products)

        ItemClients = ObProduct.Clients.Where(Function(i) i.Name.IndexOf("Coke") <> -1)
        ItemProducts = ObProduct.Products.Where(Function(i) i.Name.IndexOf("Coke Zero") <> -1)

        For Each item In ItemClients
            MessageBox.Show($"Client ""{item.Name}"" found.", "Find", MessageBoxButton.OK, MessageBoxImage.Information)
        Next

        For Each item In ItemProducts
            MessageBox.Show($"Product ""{item.Name}"" found.", "Find", MessageBoxButton.OK, MessageBoxImage.Information)
        Next
    End Sub

    Private Sub CmdFindProduct_Click(sender As Object, e As RoutedEventArgs) Handles CmdFindProduct.Click
        Dim ObProduct As ClsProducts = New ClsProducts

        Dim ClientName As String = "Coke"
        Dim ProductName As String = "Coke Zero"

        REM Search products (mandatory) and clients (optional)
        Dim ItemSearchProducts = (
         From p In ObProduct.Products.Where(Function(product) product.Name.IndexOf(ProductName) <> -1)
         Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
         Join b In ObProduct.Sales On v.IdSale Equals b.Id
         Join c In ObProduct.Clients.Where(Function(client) client.Name.IndexOf(ClientName) <> -1 Or 1 = 1)
         On b.IdClient Equals c.Id
        )

        If ItemSearchProducts.Count() = 0 Then
            REM Search products (optional) and clients (mandatory)
            ItemSearchProducts = (
                From p In ObProduct.Products.Where(Function(product) product.Name.IndexOf(ProductName) <> -1 Or 1 = 1)
                Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
                Join b In ObProduct.Sales On v.IdSale Equals b.Id
                Join c In ObProduct.Clients.Where(Function(client) client.Name.IndexOf(ClientName) <> -1)
                On b.IdClient Equals c.Id
            )
        End If

        If ItemSearchProducts.Count() = 0 Then
            MessageBox.Show("There is no result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemSearchProducts
                MessageBox.Show($"Product ""{Item.p.Name}"" found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If
    End Sub

    Private Sub CmdSalePlusRemove_Click(sender As Object, e As RoutedEventArgs) Handles CmdSalePlusRemove.Click
        REM TODO

        Dim ObProducts As ClsProducts = New ClsProducts
        Dim ObSales As ClsProducts = New ClsProducts

        Dim ObSaleDelete As ClsProducts = New ClsProducts
        Dim QyItemSearchSaleItems As IQueryable(Of SaleItems)

        Dim QueryProducts As IQueryable(Of Products)
        Dim QueryClients As IQueryable(Of Clients)

        Dim ListClientName As List(Of String) = New List(Of String)
        Dim ListProductName As List(Of String) = New List(Of String)
        Dim ListSaleId As List(Of String) = New List(Of String)

        Dim ClientName As String = "Coke"
        ListClientName.Add("Coke")
        ListClientName.Add("Pepsi")

        Dim ProductName As String = "Coke Zero"
        ListProductName.Add("Coke Zero")
        ListProductName.Add("Coke Classic")
        ListProductName.Add("Pepsi Zero")
        ListProductName.Add("Pepsi Classic")

        Dim p As String = String.Join(",", ListProductName.ToArray())
        Dim c As String = String.Join(",", ListClientName.ToArray())
        Dim s As String = ""

        QueryProducts = ObProducts.Products.Where(Function(product) p.IndexOf(product.Name) <> -1)
        QueryClients = ObSales.Clients.Where(Function(client) c.IndexOf(client.Name) <> -1)

        Dim Rnd As New Random

        Dim ItemSaleItems As SaleItems = New SaleItems
        Dim ItemSales As Sales = New Sales

        Dim ListItemSaleItems As List(Of SaleItems) = New List(Of SaleItems)

        Dim ListOutter As List(Of Clients) = QueryClients.ToList()
        Dim ListInner As List(Of Products) = QueryProducts.ToList()

        Dim Quantity As Integer = 0
        Dim IncrementedTotal As Double = 0.0

        Dim MaxAmount As Integer = 0
        Dim MaxQuantity As Integer = 9
        Dim RndValue As Double = 0.0
        Dim Count As Integer

        For Each ItemOutter In ListOutter
            Count = 0
            IncrementedTotal = 0.0

            RndValue = Math.Floor(((Rnd.NextDouble() * (ListInner.Count() - 1.0)) + 1.0))
            MaxAmount = Convert.ToInt32(RndValue)
            ListItemSaleItems.Clear()

            For Each ItemInner In ListInner
                Count = Count + 1

                RndValue = Math.Floor(((Rnd.NextDouble() * (MaxQuantity - 1.0)) + 1.0))

                Quantity = Convert.ToInt32(RndValue)

                ItemSaleItems = New SaleItems() REM Create new instance on every iteration so that it allocates data into a new memory space
                ItemSaleItems.IdProduct = ItemInner.Id
                ItemSaleItems.UnitPrice = ItemInner.Price
                ItemSaleItems.Quantity = Quantity
                ItemSaleItems.TotalPrice = ItemInner.Price * Quantity

                ListItemSaleItems.Add(ItemSaleItems)

                IncrementedTotal += ItemSaleItems.TotalPrice

                If Count = MaxAmount Then

                    ItemSales.IdClient = ItemOutter.Id
                    ItemSales._Date = Now()
                    ItemSales.Total = IncrementedTotal REM It keeps the incremented amount, already set before

                    ObProducts.Sales.Add(ItemSales) REM the sale must be done after all items have been sold out
                    ObProducts.SaveChanges()

                    ListSaleId.Add(ItemSaleItems.Id.ToString())

                    For Each Item In ListItemSaleItems

                        Item.IdSale = ItemSales.Id

                        ObSales.SaleItems.Add(Item)
                        ObSales.SaveChanges()
                    Next

                    Exit For
                End If
            Next

        Next

        MessageBox.Show("Sale added.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        s = String.Join(",", ListSaleId.ToArray())

        QyItemSearchSaleItems = ObSaleDelete.SaleItems.Where _
        (
            Function(item) s.IndexOf(item.IdSale.ToString()) <> -1
        )

        ObSaleDelete.SaleItems.RemoveRange(QyItemSearchSaleItems) REM remove range it is not working up to now
        ObSaleDelete.SaveChanges()

        MessageBox.Show("Sale removed.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)

        LoadData()
    End Sub

    Private Sub CmdFindV2_Click(sender As Object, e As RoutedEventArgs) Handles CmdFindV2.Click
        Dim ObProducts As ClsProducts = New ClsProducts

        Dim QueryProducts As IQueryable(Of Products)

        Dim ListProductName As List(Of String) = New List(Of String)

        Dim ProductName As String = "Coke Zero"
        ListProductName.Add("Coke Zero")
        ListProductName.Add("Coke Classic")
        ListProductName.Add("Pepsi Zero")
        ListProductName.Add("Pepsi Classic")

        Dim p As String = String.Join(",", ListProductName.ToArray())

        QueryProducts = ObProducts.Products.Where(Function(product) p.IndexOf(product.Name) <> -1)


        Dim Rnd As New Random

        Dim List As List(Of Products) = QueryProducts.ToList()
        Dim ListId As List(Of String) = New List(Of String)

        For Each Item In List
            ListId.Add(Item.Id)
        Next

        Dim d As String = String.Join(",", ListId.ToArray())

        Dim ItemSearchSaleItems = ObProducts.SaleItems.Where(Function(product) p.IndexOf(product.IdProduct.ToString()) <> -1)

        Dim ItemSearchProducts = (
            From r In ObProducts.Products.Where(Function(product) p.IndexOf(product.Name) <> -1)
            Join v In ObProducts.SaleItems.Where(Function(item) item.IdSale = d.IndexOf(item.IdProduct.ToString()) <> -1)
            On r.Id Equals v.IdProduct
        )

        If ItemSearchProducts.Count() = 0 Then
            MessageBox.Show("There is no result.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
        Else
            For Each Item In ItemSearchProducts
                MessageBox.Show($"Product ""{Item.r.Name}"" found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Next
        End If
    End Sub

    Private Sub MainWindow_Initialized(sender As Object, e As EventArgs) Handles Me.Initialized
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim ObProduct As ClsProducts = New ClsProducts

        Dim ItemClients As Clients = New Clients

        Dim ItemProducts As Products = New Products

        Dim listProducts As List(Of Products) = ObProduct.Products.ToList()

        ListProduct.Items.Clear()
        For Each item In listProducts

            ListProduct.Items.Add(item.Name)
        Next

        Dim listClients As List(Of Clients) = ObProduct.Clients.ToList()

        ListClient.Items.Clear()
        For Each item In listClients
            ListClient.Items.Add(item.Name)
        Next

        Dim ItemSearchProducts = (
                From p In ObProduct.Products
                Join v In ObProduct.SaleItems On p.Id Equals v.IdProduct
                Join b In ObProduct.Sales On v.IdSale Equals b.Id
                Join c In ObProduct.Clients
                On b.IdClient Equals c.Id
        )

        Dim ListItems = ItemSearchProducts.ToList()

        ListResult.Items.Clear()
        ListResult.Items.Add("Client | Product | UnitPrice | Quantity | Total")
        For Each Item In ListItems
            ListResult.Items.Add(
                Item.c.Name + " | " +
                Item.p.Name + " | " +
                Item.v.UnitPrice.ToString() + " | " +
                Item.v.Quantity.ToString() + " | " +
                Item.v.TotalPrice.ToString()
            )
        Next
    End Sub
End Class

