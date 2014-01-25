USE [RecreationOutlet]
GO

set IDENTITY_INSERT TAX_RATE ON
GO

DELETE FROM TAX_RATE
GO

INSERT INTO TAX_RATE ([TaxRateID],[TaxRateType],[TaxRate]) VALUES
(1,'General Sales',6.5),
(2,'Food',3)

GO

set IDENTITY_INSERT TAX_RATE OFF
GO

-- *********************************************************************
USE Master
GO