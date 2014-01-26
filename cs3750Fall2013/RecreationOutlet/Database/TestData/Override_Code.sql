USE [RecreationOutlet]
GO

--set IDENTITY_INSERT OVERRIDE_CODE ON
--GO

DELETE FROM OVERRIDE_CODE
GO

INSERT INTO OVERRIDE_CODE ([OverrideCode],[OverrideReason]) VALUES
(1,'Ad-match'),
(2,'Manual Discount'),
(3,'Price Override'),
(4,'Other')

GO

--set IDENTITY_INSERT OVERRIDE_CODE OFF
--GO

-- *********************************************************************
USE Master
GO