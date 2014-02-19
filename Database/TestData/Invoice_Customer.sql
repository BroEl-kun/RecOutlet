USE [RecreationOutlet]
GO

--set IDENTITY_INSERT INVOICE_CUSTOMER ON
--GO

DELETE FROM INVOICE_CUSTOMER
GO

INSERT INTO INVOICE_CUSTOMER ([CustomerID],[CustomerName],[TaxExemptID],[CustomerPaymentTerms],[CustomerAddress],[CustomerState],[CustomerZip],[CustomerPhone]) VALUES
(1,2,1,'Net 10','send to OG','UT','84120','4356987119'),
(2,5,1,'Net 10','send to OG','UT','84403','8014587130'),
(3,7,1,'Net 30','send to OG','UT','89271','8012368794'),
(4,9,2,'Net 10','send to AF','UT','87435','4352222222'),
(5,11,1,'Net 30','send to AF','UT','86355','4358752001'),
(6,15,3,'Net 30','send to SL','OR','22568','3659874201'),
(7,16,1,'Net 30','send to SL','OR','23697','9876589632'),
(8,18,1,'Net 30','send to AF','OR','21104','1123569782'),
(9,20,2,'Net 30','send to AF','OR','22798','1865324987'),
(10,21,2,'Net 10','send to SL','OR','26350','3689753249')

GO

--set IDENTITY_INSERT INVOICE_CUSTOMER OFF
--GO

-- *********************************************************************
USE Master
GO