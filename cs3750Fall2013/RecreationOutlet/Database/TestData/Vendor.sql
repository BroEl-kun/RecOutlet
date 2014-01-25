USE [RecreationOutlet]
GO

set IDENTITY_INSERT VENDOR ON
GO

DELETE FROM VENDOR
GO

INSERT INTO VENDOR ([VendorID],[VendorName],[ContactName],[ContactPhone],[ContactFax],[AltPhone],[Address],[Website]) VALUES
(1,'ACME Inc.','Bob Smith','8015555555','8015555556','NULL','123 E 50 N, Ogden, UT','www.acme.com'),
(2,'Wayne Enterprises','Bruce Wayne','5555555555','NULL','NULL','1 Infinite Loop, Gotham City','NULL'),
(3,'TMI Corporation','Loud Howard','5937219823','5931893751','','400 W Blah Ave.','www.tmi.com'),
(4,'Skytech Worldwide','Lee Jennings','Lee Jennings','13084443211','13084474170','14 S California Ave, Omaha, Nebraska','www.skytech.com'),
(5,'Apple Inc.','NULL','1800APPLE','NULL','NULL','1 Infinite Loop, Cupertino, CA','www.apple.com'),
(6,'AsusTek','NULL','884345551','NULL','NULL','800 Corporate Way, Fremont, CA 94539 USA','www.asus.com'),
(7,'Acer International','NULL','2314895758','NULL','NULL','Acer America Corporation 333 West San Carlos Street Suite 1500 San Jose, CA 95110','NULL'),
(8,'Coca-Cola Inc.','NULL','8975553892','NULL','NULL','1 Coca Cola Plz NW, Atlanta, GA 30313','NULL'),
(9,'PepsiCo','NULL','8392575311','NULL','NULL','700 Anderson Hill Road Purchase, NY 10577','NULL'),
(10,'Dr. Pepper/7UP Co.','NULL','9994875333','NULL','NULL','Plano, TX','7up.com'),
(13,'Outdoor Products, Inc.','NULL','55555555555','NULL','NULL','1 Washington Blvd. Ogden, UT','NULL'),
(15,'Garmin International','NULL','9133978200','NULL','NULL','1200 E. 151st','www.garmin.com'),
(16,'Remington Arms Company','NULL','18002439700','NULL','NULL','870 Remington Drive','http://www.remington.com/'),
(18,'Microsoft Corporation','NULL','1800MICROSOFT','NULL','NULL','Somewhere','www.microsoft.com'),
(42,'Cisco Systems','NULL','18885553321','NULL','NULL','1234 W. 3200 S.','www.cisco.com'),
(43,'Test Vendor 1','NULL','8015555555','NULL','NULL','Somewhere','NULL'),
(44,'Test Vendor 2','NULL','8015555555','NULL','NULL','Somewhere','NULL'),
(45,'Rock & Road Corp.','NULL','83317760360','NULL','NULL','507 Mega Center','NULL'),
(55,'Infinity','NULL','8887182288','NULL','NULL','6920 Salashan Parkway','NULL'),
(56,'Tom Tom Inc','NULL','18006306523','NULL','NULL','5450 Jefferson','NULL')

GO

set IDENTITY_INSERT VENDOR OFF
GO

-- *********************************************************************
USE Master
GO