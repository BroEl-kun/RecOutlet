USE [RecreationOutlet]
GO

set IDENTITY_INSERT TAX_TYPE ON
GO

DELETE FROM TAX_TYPE
GO

INSERT INTO TAX_TYPE ([TaxTypeID],[TaxTypeName]) VALUES
(1,'Food'),
(2,'Apparel'),
(3,'Services'),
(4,'General Sale')

GO

set IDENTITY_INSERT TAX_TYPE OFF
GO

-- *********************************************************************
USE Master
GO