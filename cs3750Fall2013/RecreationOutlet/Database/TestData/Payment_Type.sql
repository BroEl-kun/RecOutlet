USE [RecreationOutlet]
GO

set IDENTITY_INSERT PAYMENT_TYPE ON
GO

DELETE FROM PAYMENT_TYPE
GO

INSERT INTO PAYMENT_TYPE ([PaymentTypeID],[PaymentTypeName]) VALUES
(1,'Cash'),
(2,'Credit'),
(3,'Debit'),
(4,'Gift Card')

GO

set IDENTITY_INSERT PAYMENT_TYPE OFF
GO

-- *********************************************************************
USE Master
GO