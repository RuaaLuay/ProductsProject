USE [restaurantdb]
GO

/****** Object:  View [dbo].[NumberOfallCustomer2]    Script Date: 23/09/2022 03:59:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[NumberOfallCustomer2] AS  select RName ,
MAX(numberOfCustomer)MostPurchasedCustomer  
from [NumberOfallCustomer]  group by RName;
GO

