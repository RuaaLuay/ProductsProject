USE [restaurantdb]
GO

/****** Object:  View [dbo].[TheBestSellingMealView]    Script Date: 23/09/2022 04:00:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[TheBestSellingMealView]as 
select b.RName resturantName,
a.MName mealName  
from [NumberOfAllOrder2] b  
join NumberOfallOrder a on a.numberOfOrder=b.TheBestSellingMeal
GO

