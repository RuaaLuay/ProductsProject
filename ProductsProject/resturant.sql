USE [restaurantdb]
GO

/****** Object:  Table [dbo].[restaurant]    Script Date: 23/09/2022 03:57:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[restaurant](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](50) NOT NULL,
	[CraetedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Archived] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[restaurant] ADD  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[restaurant] ADD  DEFAULT ('') FOR [PhoneNumber]
GO

ALTER TABLE [dbo].[restaurant] ADD  DEFAULT (getdate()) FOR [CraetedDate]
GO

ALTER TABLE [dbo].[restaurant] ADD  DEFAULT (getdate()) FOR [UpdatedDate]
GO

ALTER TABLE [dbo].[restaurant] ADD  DEFAULT ((0)) FOR [Archived]
GO

