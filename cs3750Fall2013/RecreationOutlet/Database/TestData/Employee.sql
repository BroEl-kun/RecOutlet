USE [RecreationOutlet]
GO

set IDENTITY_INSERT EMPLOYEE ON
GO

DELETE FROM EMPLOYEE
GO

INSERT INTO EMPLOYEE ([EmployeeID],[Name],[Position],[Username],[PIN]) VALUES
(1,'Neo Anderson','Security Expert','TheOne','1234')

GO

set IDENTITY_INSERT EMPLOYEE OFF
GO

-- *********************************************************************
USE Master
GO