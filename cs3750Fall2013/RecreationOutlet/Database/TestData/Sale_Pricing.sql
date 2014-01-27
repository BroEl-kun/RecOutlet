USE [RecreationOutlet]
GO

--set IDENTITY_INSERT SALE_PRICING ON
--GO

DELETE FROM SALE_PRICING
GO

INSERT INTO SALE_PRICING ([EventTypeCode],[RecRPC],[SalePrice],[BeginDate],[EndDate],[Comments]) VALUES
(1,'458000002031',9.99,'11/24/2014','11/25/2014',NULL),
(1,'1358000001032',29.99,'11/24/2014','11/25/2014',NULL),
(3,'807000001001',35.99,'12/20/2014','1/1/2015',NULL),
(2,'4014000001030',5.99,'11/24/2014','11/27/2014',NULL),
(4,'4057000002008',12.99,'7/1/2014','7/6/2014',NULL)

GO

--set IDENTITY_INSERT SALE_PRICING OFF
--GO

-- *********************************************************************
USE Master
GO