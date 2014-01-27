USE [RecreationOutlet]
GO

--set IDENTITY_INSERT BACKORDER ON
--GO

DELETE FROM BACKORDER
GO

INSERT INTO BACKORDER ([BackOrderID],[ReceivingID],[BackorderQty]) VALUES
(1,2,20),
(2,5,5),
(3,9,15)

GO

--set IDENTITY_INSERT BACKORDER OFF
--GO

-- *********************************************************************
USE Master
GO