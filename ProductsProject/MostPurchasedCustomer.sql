USE [restaurantdb]
GO

/****** Object:  View [dbo].[MostPurchasedCustomer]    Script Date: 23/09/2022 03:58:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[MostPurchasedCustomer]as  
select b.RName resturantName,a.FName NameCustumer 
from [NumberOfallCustomer2] b   
join [NumberOfallCustomer] a on a.numberOfCustomer=b.MostPurchasedCustomer
GO

