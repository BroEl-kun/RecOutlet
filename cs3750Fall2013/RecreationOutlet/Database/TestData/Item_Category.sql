USE [RecreationOutlet]
GO

set IDENTITY_INSERT ITEM_CATEGORY ON
GO

DELETE FROM ITEM_CATEGORY
GO


INSERT INTO ITEM_CATEGORY ([CategoryID],[CategoryName]) VALUES
(1,'Mugs'),
(2,'Coats'),
(3,'Bullets'),
(4,'Shells'),
(5,'Thermal Outerwear'),
(6,'Thermal Underwear'),
(7,'Chips'),
(8,'Jerky'),
(9,'Carbonated Beverages'),
(10,'First Aid Kits'),
(11,'Mosquito Repellant'),
(12,'Sunscreen'),
(13,'Socks'),
(14,'Sleeping Bag'),
(15,'Sleeping Pad'),
(16,'Winter Gloves'),
(17,'Thermal Socks'),
(18,'Athletic Socks'),
(19,'Boots'),
(20,'Running Shoes'),
(21,'Tents'),
(22,'Hiking Packs'),
(23,'Butane Stoves'),
(24,'Generators'),
(25,'Foam Pads'),
(26,'Cots'),
(27,'Memory Foam Pads'),
(28,'Snowshoes'),
(29,'Shovels'),
(30,'MREs'),
(31,'Bandages'),
(32,'Mess Kits'),
(33,'Bungee Cords'),
(34,'Tent Stakes'),
(35,'Personal Tents'),
(36,'Multi-person Tents'),
(37,'Tarps'),
(38,'Bear Spray'),
(39,'Coolers'),
(40,'Marshmallow Skewers'),
(41,'Charcoal'),
(42,'Dutch Ovens'),
(43,'Floormats'),
(44,'Hitch Accessories'),
(45,'Pillows'),
(46,'Shoe Insoles'),
(47,'Water Repellant'),
(48,'Water Skis'),
(49,'Adult Life Vests'),
(50,'LIfe Buoys'),
(51,'Other Buoys'),
(52,'Child Life Vests'),
(53,'Blankets'),
(54,'Aluminum Foil'),
(55,'Outdoor Lighting'),
(56,'Test Category 1'),
(57,'Bottle'),
(58,'GPS'),
(59,'Electronics')
GO

set IDENTITY_INSERT ITEM_CATEGORY OFF
GO

-- *********************************************************************
USE Master
GO