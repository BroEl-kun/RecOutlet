USE [RecreationOutlet]
GO

--set IDENTITY_INSERT EXCEPTIONS ON
--GO

DELETE FROM EXCEPTIONS
GO

INSERT INTO EXCEPTIONS ([ExceptionsID],[ManagerID],[TransactionLineItemID],[PreviousTransactionLineItemID],[OverrideCode],[RefundCode]) VALUES
(1,'8',1329,1325,NULL,3),
(2,'8',1335,1330,NULL,1),
(3,'3',1336,1326,NULL,1)

GO

--set IDENTITY_INSERT EXCEPTIONS OFF
--GO

-- *********************************************************************
USE Master
GO