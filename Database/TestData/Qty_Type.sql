USE [RecreationOutlet]
GO

set IDENTITY_INSERT QTY_TYPE ON
GO

DELETE FROM QTY_TYPE
GO

INSERT INTO QTY_TYPE ([QtyTypeID],[QtyTypeDescription]) VALUES
(1,'Each'),
(2,'Case'),
(3,'Pallet')

GO

set IDENTITY_INSERT QTY_TYPE OFF
GO

-- *********************************************************************
USE Master
GO