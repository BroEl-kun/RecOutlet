
USE [RecreationOutlet]
GO

--set IDENTITY_INSERT ITEM ON
--GO

DELETE FROM ITEM
GO

INSERT INTO ITEM ([RecRPC],[ItemUPC],[Name],[Description],[VendorItemID],[ProductLineID],[SeasonCode],[ItemID],[CategoryID],[DepartmentID],[SubcategoryID],[MSRP],[SellPrice],[TaxTypeID],[RestrictedAge],[LegacyID],[ItemCreatedBy],[ItemCreatedDate]) VALUES
(458000001031,0,'Nuvi 3597LMTHD','Garmin Vehicle GPS with HD screen, Lifetime Maps, Lifetime Traffic',322134,35,'All',1,58,4,31,329.99,299.99,1,0,NULL,1,'12/10/2013'),
(458000002031,0,'Nuvi 2457 LMT','Garmin GPS with lifetime maps, Lifetime traffic.',322253,34,'All',2,58,4,31,159.99,149.99,1,0,NULL,1,'12/10/2013'),
(459000001031,0,'echoMap','Top pick color GPS',80000,36,'Summer',1,59,4,31,1000,800,1,0,NULL,1,'12/10/2013'),
(807000001001,0,'AS Laptop 17 B3250','ASUS 17" laptop Model A5300',398579,16,'All',1,7,8,1,549.99,498,1,18,NULL,1,'12/10/2013'),
(807000002001,0,'AS Laptop 17 B6000','ASUS 17" laptop Model B6000',398581,16,'All',2,7,8,1,549.99,498,1,18,NULL,1,'12/10/2013'),
(1358000001032,0,'eTrex 20','Garmin eTrek 20 Personal GPS (AA-battery Operated)',487944,35,'All',1,58,13,32,199.99,149.99,1,0,NULL,1,'12/10/2013'),
(4014000001030,0,'Ultra Lite Mummy Sleeping Bag','1.35 lbs sleeping bag',54136,32,'Summer',1,14,40,30,75,75,1,0,NULL,1,'12/10/2013'),
(4014000002030,0,'Hike Lite Mummy Sleeping Bag','1.8 lbs sleeping bag',54136,32,'Summer',2,14,40,30,90,89,1,0,NULL,1,'12/10/2013'),
(4022000001001,0,'Rim Runner Pack(Red)','100 oz. Rim Runner Pack',90756,25,'Summer',1,8,40,1,132,125,1,0,NULL,1,'12/10/2013'),
(4022000001002,0,'Rim Runner Pack(Blue)','100 oz. Rim Runner Pack',90756,25,'Summer',1,8,40,2,132,125,1,0,NULL,1,'12/10/2013'),
(4022000001003,0,'Rim Runner Pack(Green)','100 oz. Rim Runner Pack',90756,25,'Summer',1,8,40,3,132,125,1,0,NULL,1,'12/10/2013'),
(4022000001004,0,'Rogue Pack(Black)','70 oz. Rogue Pack',90756,25,'Summer',1,8,40,4,82,75,1,0,NULL,1,'12/10/2013'),
(4022000002001,0,'Rogue Pack(Red)','70 oz. Rogue Pack',90756,25,'Summer',2,8,40,1,82,75,1,0,NULL,1,'12/10/2013'),
(4022000002002,0,'Rogue Pack(Blue)','70 oz. Rogue Pack',90756,25,'Summer',2,8,40,2,82,75,1,0,NULL,1,'12/10/2013'),
(4057000001003,0,'Groove Bottle(Green)','0.6L bottle',53674,25,'All',1,57,40,3,20,20,1,0,NULL,1,'12/10/2013'),
(4057000002008,0,'Stainless Steel Groove Bottle','0.6L bottle stainless steel',61457,25,'All',2,57,40,8,43,39,1,0,NULL,1,'12/10/2013')

GO

--set IDENTITY_INSERT ITEM OFF
--GO

-- *********************************************************************
USE Master
GO