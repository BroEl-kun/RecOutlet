USE [RecreationOutlet]
GO

set IDENTITY_INSERT LOCATION ON
GO

DELETE FROM LOCATION
GO

INSERT INTO LOCATION ([LocationID],[StoreName],[ManagerID]) VALUES
(1,'Ogden',3),
(2,'Salt Lake',8),
(3,'American Fork',9)


GO

set IDENTITY_INSERT LOCATION OFF
GO

-- *********************************************************************
USE Master
GO