USE [products]
GO

CREATE TABLE [dbo].[SaleItems](
	
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSale] [int] NOT NULL,
	[IdProduct] [int] NOT NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [float] NULL,
	[TotalPrice] [float] NULL,
	
	PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
	WITH 
	(
		PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON
	) 
	ON [PRIMARY]
	
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SaleItems]  WITH CHECK ADD FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Products] ([Id])
GO

ALTER TABLE [dbo].[SaleItems]  WITH CHECK ADD FOREIGN KEY([IdSale])
REFERENCES [dbo].[Sales] ([Id])
GO

