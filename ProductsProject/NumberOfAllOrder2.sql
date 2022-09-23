USE [restaurantdb]
GO

/****** Object:  View [dbo].[NumberOfAllOrder2]    Script Date: 23/09/2022 03:59:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[NumberOfAllOrder2] AS  select distinct RName , 
MAX(numberOfOrder)TheBestSellingMeal   
from [NumberOfallOrder]  
group by RName; 
GO

