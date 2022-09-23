USE [restaurantdb]
GO

/****** Object:  Table [dbo].[MenuCustomer]    Script Date: 23/09/2022 03:57:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MId] [int] NOT NULL,
	[CId] [int] NOT NULL,
	[CraetedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Archived] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MenuCustomer] ADD  DEFAULT (getdate()) FOR [CraetedDate]
GO

ALTER TABLE [dbo].[MenuCustomer] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[MenuCustomer] ADD  DEFAULT ((0)) FOR [Archived]
GO

ALTER TABLE [dbo].[MenuCustomer]  WITH CHECK ADD FOREIGN KEY([CId])
REFERENCES [dbo].[customer] ([Id])
GO

ALTER TABLE [dbo].[MenuCustomer]  WITH CHECK ADD FOREIGN KEY([MId])
REFERENCES [dbo].[restaurantMenu] ([Id])
GO

ALTER TABLE [dbo].[MenuCustomer]  WITH CHECK ADD CHECK  (([Id]>(0)))
GO

