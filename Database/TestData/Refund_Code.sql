USE [RecreationOutlet]
GO

--set IDENTITY_INSERT REFUND_CODE ON
--GO

DELETE FROM REFUND_CODE
GO

INSERT INTO REFUND_CODE ([RefundCode],[RefundReason]) VALUES
(1,'None'),
(2,'Exchange'),
(3,'Defective Item'),
(4,'Other')



GO

--set IDENTITY_INSERT REFUND_CODE OFF
--GO

-- *********************************************************************
USE Master
GO