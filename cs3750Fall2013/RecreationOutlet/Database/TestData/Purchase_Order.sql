USE [RecreationOutlet]
GO

--set IDENTITY_INSERT PURCHASE_ORDER ON
--GO

DELETE FROM PURCHASE_ORDER
GO

INSERT INTO PURCHASE_ORDER ([POID],[VendorID],[POCreatedBy],[POOrderDate],[POEstimatedShipDate],[POCreatedDate],[POFreightCost],[POTerms],[POComments],[ShippingID]) VALUES
(1108201301,2,1,41586,41596,41586,20.23,'45-Day','FRAGILE',NULL),
(1108201302,1,1,41586,41596,41586,23.12,'90-day','FRAGILE',NULL),
(1108201303,1,1,41586,41596,41586,15.33,'45-Day','FRAGILE',NULL),
(1108201304,1,1,41586,41596,41586,12.1,'56.1','None.',NULL),
(1108201305,2,1,41586,41596,41586,20.23,'30-day','None.',NULL),
(1112201301,2,1,41590,41600,41590,44.1,'90-day','None.',NULL),
(1112201302,1,1,41590,41600,41590,500,'net 30','don''t break',NULL),
(1114201301,1,1,41592,41602,41592,44.1,'60-day','NULL',NULL),
(1118201301,5,1,41596,41606,41596,55,'NULL','NULL',NULL),
(1120201301,5,1,41598,41608,41598,120,'orders sal','coats for winter',NULL),
(1121201301,6,1,41599,41609,41599,55.4,'Net-90','NULL',NULL),
(1205201301,1,1,41613,41623,41613,4,'90-day','No comments.',NULL),
(1207201301,1,1,41615,41625,41615,55,'NULL','NULL',NULL),
(1207201302,16,1,41615,41625,41615,55.4,'NULL','2014 ORDER',NULL),
(1207201303,7,1,41615,41625,41615,55.4,'NULL','NULL',NULL),
(1210201301,6,1,41618,41628,41618,45,'NULL','NULL',NULL),
(1210201302,6,1,41618,41628,41618,45,'NULL','NULL',NULL),
(1210201303,6,1,41618,41628,41618,55,'NULL','NULL',NULL),
(1210201304,18,1,41618,41628,41618,23,'NULL','NULL',NULL),
(1210201305,7,1,41618,41628,41618,32,'NULL','NULL',NULL),
(1210201306,5,1,41618,41628,41618,35,'NULL','NULL',NULL),
(1210201307,16,1,41618,41628,41618,35,'NULL','NULL',NULL),
(1210201308,45,1,41618,41628,41618,80,'NULL','NULL',NULL),
(1210201309,1,1,41618,41628,41618,18,'NULL','2016 ORDER',NULL),
(1210201310,1,1,41618,41628,41618,32,'NULL','NULL',NULL),
(1210201311,1,1,41618,41628,41618,32,'NULL','NULL',NULL),
(1210201312,1,1,41618,41628,41618,31,'NULL','NULL',NULL),
(1210201313,1,1,41618,41628,41618,32,'NULL','NULL',NULL),
(1210201314,13,1,41618,41628,41618,500,'NULL','NULL',NULL),
(1210201315,15,1,41618,41628,41618,97.31,'NULL','Holiday GPS order',NULL),
(1210201316,15,1,41618,41628,41618,55.93,'NULL','NULL',NULL),
(1210201317,6,1,41618,41628,41618,45,'NULL','NULL',NULL),
(1210201318,15,1,41618,41628,41618,800,'Net90','Christmas reorder',NULL)

GO

--set IDENTITY_INSERT PURCHASE_ORDER OFF
--GO

-- *********************************************************************
USE Master
GO