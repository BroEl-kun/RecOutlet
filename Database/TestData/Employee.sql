USE [RecreationOutlet]
GO

set IDENTITY_INSERT EMPLOYEE ON
GO

DELETE FROM EMPLOYEE
GO

INSERT INTO EMPLOYEE ([EmployeeID],[Name],[Position],[Username],[PIN]) VALUES
(1,'Neo Anderson','Security Expert','neoanderson','1234'),
(2,'Sam Daniels','Cashier','samdaniels','9875'),
(3,'Justin Smith','Manager','justinsmith','3254'),
(4,'Rebecca Hancock','Cashier','rebeccahancock','1120'),
(5,'Amy Withers','Cashier','amywithers','7853'),
(6,'Bobby Lara','Sales Assistant','bobbylara','3835'),
(7,'Bryan Torres','Stock Assistant','bryantorres','1248'),
(8,'Lisa Collins','Assistant Manager','lisacollins','9667'),
(9,'Erin Dickenson','Manager','erindickenson','4871'),
(10, 'Recreation', 'Owner', 'recreation', '1234')

GO

set IDENTITY_INSERT EMPLOYEE OFF
GO

-- *********************************************************************
USE Master
GO