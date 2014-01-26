USE [RecreationOutlet]
GO

set IDENTITY_INSERT EVENT_TYPE ON
GO

DELETE FROM EVENT_TYPE
GO

INSERT INTO EVENT_TYPE ([EventTypeCode],[EventDescription]) VALUES
(1,'Black Friday'),
(2,'Thanksgiving'),
(3,'Christmas'),
(4,'4th of July')

GO

set IDENTITY_INSERT EVENT_TYPE OFF
GO

-- *********************************************************************
USE Master
GO