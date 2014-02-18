USE [RecreationOutlet]
GO

set IDENTITY_INSERT VENDOR ON
GO

DELETE FROM VENDOR
GO

INSERT INTO VENDOR ([VendorID],[VendorName],[ContactName],[ContactPhone],[ContactFax],[AltPhone],[VendorAddress],[VendorState],[VendorZip],[VendorWebsite]) VALUES
(1,'ACME Inc.','Bob Smith','8015555555','8015555556','NULL','123 E 50 N, Ogden','UT','98135','www.acme.com'),
(2,'Wayne Enterprises','Bruce Wayne','5555555555','NULL','NULL','1 Infinite Loop, Gotham City','NY','55875','NULL'),
(3,'TMI Corporation','Loud Howard','5937219823','5931893751','','400 W Blah Ave.','ID','12304','www.tmi.com'),
(4,'Skytech Worldwide','Lee Jennings','13084443211','13084443211','13084443211','14 S California Ave, Omaha','NE','13985','www.skytech.com'),
(5,'Apple Inc.','NULL','1800APPLE','NULL','NULL','1 Infinite Loop, Cupertino','CA','98637','www.apple.com'),
(6,'AsusTek','NULL','884345551','NULL','NULL','800 Corporate Way, Fremont','CA','46985','www.asus.com'),
(7,'Acer International','NULL','2314895758','NULL','NULL','333 West San Carlos Street Suite 1500 San Jose ','CA','95110','NULL'),
(8,'Coca-Cola Inc.','NULL','8975553892','NULL','NULL','1 Coca Cola Plz NW, Atlanta ','GA','30313','NULL'),
(9,'PepsiCo','NULL','8392575311','NULL','NULL','700 Anderson Hill Road Purchase ','NY','10577','NULL'),
(10,'Dr. Pepper/7UP Co.','NULL','9994875333','NULL','NULL','687 Plano Street','TX','68732','7up.com'),
(13,'Outdoor Products, Inc.','NULL','55555555555','NULL','NULL','1 Washington Blvd. Ogden','UT','81234','NULL'),
(15,'Garmin International','NULL','9133978200','NULL','NULL','1200 E. 151st','KS','27981','www.garmin.com'),
(16,'Remington Arms Company','NULL','18002439700','NULL','NULL','870 Remington Drive','MN','77763','www.remington.com'),
(18,'Microsoft Corporation','NULL','1800MICRO','NULL','NULL','1 157th Ave NE, Redmond ','WA','98052','www.microsoft.com'),
(42,'Cisco Systems','NULL','18885553321','NULL','NULL','1234 W. 3200 S.','WA','44569','www.cisco.com'),
(45,'Rock & Road Corp.','NULL','83317760360','NULL','NULL','507 Mega Center','RI','25793','NULL'),
(55,'Infinity','NULL','8887182288','NULL','NULL','6920 Salashan Parkway','VT','98532','NULL'),
(56,'Tom Tom Inc','NULL','18006306523','NULL','NULL','5450 Jefferson','OR','11899','NULL')

GO

set IDENTITY_INSERT VENDOR OFF
GO

-- *********************************************************************
USE Master
GO