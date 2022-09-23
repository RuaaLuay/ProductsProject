USE [restaurantdb]
GO

/****** Object:  Table [dbo].[restaurantMenu]    Script Date: 23/09/2022 03:58:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[restaurantMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RId] [int] NOT NULL,
	[MealName] [varchar](255) NOT NULL,
	[PriceInNis] [float] NOT NULL,
	[PriceInUsd] [float] NOT NULL,
	[Quantity] [int] NOT NULL,
	[CraetedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Archived] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT ('') FOR [MealName]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT ((0)) FOR [PriceInNis]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT ((0)) FOR [PriceInUsd]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT ((0)) FOR [Quantity]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT (getdate()) FOR [CraetedDate]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[restaurantMenu] ADD  DEFAULT ((0)) FOR [Archived]
GO

ALTER TABLE [dbo].[restaurantMenu]  WITH CHECK ADD FOREIGN KEY([RId])
REFERENCES [dbo].[restaurant] ([Id])
GO

