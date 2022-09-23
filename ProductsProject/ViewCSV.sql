USE [restaurantdb]
GO

/****** Object:  View [dbo].[ViewCSV]    Script Date: 23/09/2022 04:00:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewCSV] AS 
select R.Name RestaurantName , 
COUNT(MC.Cid) NumberOfOrderedCustomer ,  
SUM(RM.PriceInUsd) ProfitInUsd , 
SUM(RM.PriceInNis) ProfitInNis ,  
m.mealName TheBestSellingMeal , 
N.NameCustumer MostPurchasedCustomer
from MenuCustomer MC  
join restaurantMenu RM on MC.Mid =RM.Id  
join restaurant R on RM.Rid = R.Id  
join [TheBestSellingMealView] m on m.resturantName=R.Name  
join [MostPurchasedCustomer] N on N.resturantName=R.Name 
group by (R.Name),(m.mealName),(N.NameCustumer)
GO

