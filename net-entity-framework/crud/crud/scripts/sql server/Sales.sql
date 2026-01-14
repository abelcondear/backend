USE [products]
GO

CREATE TABLE [dbo].[Sales](
	
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdClient] [int] NOT NULL,
	[Date] [datetime] NULL,
	[Total] [float] NULL,
	
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
	) ON [PRIMARY]
	
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Sales]  WITH CHECK ADD FOREIGN KEY([IdClient])
REFERENCES [dbo].[Clients] ([Id])
GO

