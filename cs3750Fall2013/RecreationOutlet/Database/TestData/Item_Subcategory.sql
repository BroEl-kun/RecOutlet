USE [RecreationOutlet]
GO

set IDENTITY_INSERT ITEM_SUBCATEGORY ON
GO

DELETE FROM ITEM_SUBCATEGORY
GO


INSERT INTO ITEM_SUBCATEGORY ([SubcategoryID],[SubcategoryName]) VALUES
(1,'Red'),
(2,'Blue'),
(3,'Green'),
(4,'Black'),
(5,'Chrome'),
(6,'0.22'),
(7,'0.38'),
(8,'Stainless Steel'),
(9,'Carbon Fiber'),
(10,'Kevlar'),
(11,'Extra Small'),
(12,'Small'),
(13,'Medium'),
(14,'Large'),
(15,'Extra Large'),
(16,'General'),
(17,'White'),
(18,'Orange'),
(19,'Yellow'),
(20,'12-oz'),
(21,'20-oz'),
(22,'1-liter'),
(23,'2-liter'),
(24,'1/2-gallon'),
(25,'1-gallon'),
(26,'1-quart'),
(27,'8-oz'),
(30,'Lightweight'),
(31,'Automotive GPS'),
(32,'Personal GPS')


GO

set IDENTITY_INSERT ITEM_SUBCATEGORY OFF
GO

-- *********************************************************************
USE Master
GO