USE [RecreationOutlet]
GO

set IDENTITY_INSERT SALES_REP ON
GO

DELETE FROM SALES_REP
GO

INSERT INTO SALES_REP ([RepID],[SalesRepName],[SalesRepPhone],[SalesRepEmail]) VALUES
(1,'Jorge Garcia','1003332131','j.garcia@waynetech.com'),
(2,'Wile E. Coyote','1004441000','w.coyote@acme.com'),
(3,'J. Cummings','5555555555','jcummings@tmi.com'),
(4,'Kelly Lin','328949087','klin@asustek.com'),
(5,'Jay Blaine','953334312','jb@cocacola.com'),
(6,'Tricia Lynch','8749234432','NULL'),
(7,'Jennifer Duke','3921233444','NULL'),
(8,'Shay Smith','8015553244','Ssmith@gmail.com'),
(9,'Bill Gates','5555555555','b.gates@microsoft.com'),
(11,'Rachel McCormick','3449893382','rmccormick@garmin.com'),
(12,'Jeff','18005554646','Jeff@tomtom.com')

GO

set IDENTITY_INSERT SALES_REP OFF
GO

-- *********************************************************************
USE Master
GO