USE [restaurantdb]
GO

/****** Object:  View [dbo].[NumberOfAllOrder]    Script Date: 23/09/2022 03:59:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[NumberOfAllOrder] AS 
select R.Name RName,
RM.MealName MName,
COUNT(MC.Mid) numberOfOrder  from MenuCustomer MC 
join restaurantMenu RM on MC.Mid =RM.Id  
join restaurant R on RM.Rid = R.Id  
group by RM.MealName,R.Name;
GO

