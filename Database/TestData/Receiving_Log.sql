USE [RecreationOutlet]
GO

set IDENTITY_INSERT RECEIVING_LOG ON
GO

DELETE FROM RECEIVING_LOG
GO

INSERT INTO RECEIVING_LOG ([ReceivingID],[POLineItemID],[QtyTypeID],[ReceiveDate],[ReceivingNotes],[ReceivedQty]) VALUES
(1,2,1,41640,'',10),
(2,5,1,41641,'send to OG',31),
(3,7,1,41642,'',3),
(4,9,2,41643,'',45),
(5,11,1,41675,'',NULL),
(6,15,3,41949,'',NULL),
(7,16,1,41646,'',100),
(8,18,1,41647,'send to AF',300),
(9,20,2,41648,'',240),
(10,21,2,41739,'',NULL)

GO

set IDENTITY_INSERT RECEIVING_LOG OFF
GO

-- *********************************************************************
USE Master
GO