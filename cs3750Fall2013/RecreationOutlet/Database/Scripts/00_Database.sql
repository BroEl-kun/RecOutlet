-- *********************************************************************
--	         Project: Recreation Outlet 
--
--       Description: This DDL creates the database
--
--	Revision History:
--        01/19/2014: Frank Eddy - Create initial version
-- 
-- *********************************************************************
-- STEP 1: Create Database and Specify File Location and Size Parameters
-- *********************************************************************
USE Master
GO

IF EXISTS (SELECT * FROM sysdatabases WHERE name='RecreationOutlet')
DROP DATABASE RecreationOutlet
GO

CREATE DATABASE RecreationOutlet
ON PRIMARY
(
	NAME = 'RecreationOutlet',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\RecreationOutlet.mdf',
	SIZE = 6MB,
	MAXSIZE = 8MB,
	FILEGROWTH = 500KB
)
LOG ON
(
	NAME = 'RecreationOutlet_LOG',
	FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\RecreationOutlet.ldf',
	SIZE = 1200KB,
	MAXSIZE = 5MB,
	FILEGROWTH = 500KB
)
GO

-- *********************************************************************
USE Master
GO