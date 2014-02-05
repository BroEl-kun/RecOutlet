USE [RecreationOutlet]
GO

set IDENTITY_INSERT PO_LINEITEM ON
GO

DELETE FROM PO_LINEITEM
GO

INSERT INTO PO_LINEITEM ([POLineItemID],[POID],[RecRPC],[WholesaleCost],[QtyOrdered],[QtyTypeID]) VALUES
(1,'1121201301',807000001001,498,15,1),
(2,'1121201301',807000002001,498,10,1),
(3,'1210201308',4022000001001,125,4,1),
(4,'1210201308',4022000001002,125,61,1),
(5,'1210201308',4022000001003,125,31,1),
(6,'1210201310',4014000001030,75,3,1),
(7,'1210201311',807000002001,498,3,1),
(8,'1210201313',4014000001030,75,53,1),
(9,'1210201313',4014000001030,75,53,1),
(10,'1210201313',4014000001030,75,53,1),
(11,'1210201313',4014000001030,75,53,1),
(12,'1210201313',4014000001030,75,53,1),
(13,'1210201315',458000001031,299.99,100,1),
(14,'1210201315',458000002031,149.99,250,1),
(15,'1210201315',1358000001032,149.99,300,1),
(16,'1210201315',458000001031,299.99,100,1),
(17,'1210201315',458000002031,149.99,250,1),
(18,'1210201315',1358000001032,149.99,300,1),
(19,'1210201315',458000001031,299.99,100,1),
(20,'1210201315',458000002031,149.99,250,1),
(21,'1210201315',1358000001032,149.99,300,1)

GO

set IDENTITY_INSERT PO_LINEITEM OFF
GO

-- *********************************************************************
USE Master
GO