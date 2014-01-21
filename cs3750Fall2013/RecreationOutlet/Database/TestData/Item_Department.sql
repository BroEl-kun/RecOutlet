USE [RecreationOutlet]
GO

--set IDENTITY_INSERT ITEM_DEPARTMENT ON
--GO

DELETE FROM ITEM_DEPARTMENT
GO

INSERT INTO ITEM_DEPARTMENT (DepartmentID,DepartmentName) VALUES
(1,'Test Department'),
(2,'Climbing'),
(3,'Test Department'),
(4,'Automotive'),
(5,'Winter Clothing'),
(7,'Footwear'),
(8,'Packs'),
(9,'Emergency'),
(10,'Snow Hardgoods'),
(11,'Outerwear'),
(12,'Stoves'),
(13,'Hiking'),
(14,'Water Sports'),
(15,'Furniture'),
(40,'Outdoor Sports'),
(82,'Impulse Merchandise'),
(90,'Food')


GO

--set IDENTITY_INSERT ITEM_DEPARTMENT OFF
--GO

-- *********************************************************************
USE Master
GO