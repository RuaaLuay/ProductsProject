USE [restaurantdb]
GO

/****** Object:  View [dbo].[NumberOfallCustomer]    Script Date: 23/09/2022 03:59:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[NumberOfallCustomer]
AS  select R.Name RName,
CONCAT(C.FirstName, ' ',C.LastName)FName,
COUNT(MC.Mid) numberOfCustomer 
from MenuCustomer MC   
join customer C on MC.Cid =C.Id  
join restaurantMenu RM on MC.Mid =RM.Id 
join restaurant R on RM.Rid = R.Id   
group by CONCAT(C.FirstName, ' ',C.LastName),(R.Name) 
GO

