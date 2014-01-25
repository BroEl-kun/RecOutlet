USE [RecreationOutlet]
GO

set IDENTITY_INSERT PRODUCT_LINE ON
GO

DELETE FROM PRODUCT_LINE
GO

INSERT INTO PRODUCT_LINE ([ProductLineID],[ProductLineName],[VendorID],[RepID]) VALUES
(2,'WayneTech',2,1),
(3,'ACME Chemistry',1,2),
(6,'iPhone',5,1),
(15,'TMI Surveillance',3,3),
(16,'ASUS',6,4),
(17,'Coca-Cola Beverage Co.',8,5),
(18,'Pepsi-Cola',9,6),
(19,'Frito-Lay',9,6),
(20,'Tropicana',9,6),
(21,'Quaker',9,6),
(22,'Gatorade',9,6),
(23,'Minute Maid',8,7),
(25,'Camelbak',13,8),
(26,'Microsoft Software',18,9),
(27,'Microsoft Hardware',18,9),
(32,'Outbound',55,4),
(33,'Nuvi',15,11),
(34,'Garmin Vehicle GPS',15,11),
(35,'Garmin Personal GPS',15,11),
(36,'GPS',56,12),
(37,'other',56,12)


GO

set IDENTITY_INSERT PRODUCT_LINE OFF
GO

-- *********************************************************************
USE Master
GO