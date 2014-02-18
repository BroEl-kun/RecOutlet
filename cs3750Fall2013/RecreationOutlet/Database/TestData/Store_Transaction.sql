USE [RecreationOutlet]
GO

set IDENTITY_INSERT STORE_TRANSACTION ON
GO

DELETE FROM STORE_TRANSACTION
GO

INSERT INTO STORE_TRANSACTION ([TransactionID],[LocationID],[EmployeeID],[TransactionDate],[TerminalID],[TransTotal],[TransTax],[ManagerID],[PaymentType],[PreviousTransactionID]) VALUES
(1,1,123,41598.9982291667,'Reg 001',10.65,0.65,999,'Cash',0),
(2,1,123,41598.9988541667,'Reg 001',10.65,0.65,999,'Cash',0),
(3,1,123,41599.0008333333,'Reg 001',10.65,0.65,999,'Cash',0),
(4,1,123,41599.0063888889,'Reg 001',10.65,0.65,999,'Cash',0),
(5,1,123,41599.0072337963,'Reg 001',47.91,2.92,999,'Cash',0),
(6,1,123,41599.0081712963,'Reg 001',10.65,0.65,999,'Cash',0),
(7,1,123,41599.0191782407,'Reg 001',10.65,0.65,999,'Cash',0),
(8,1,123,41599.0226273148,'Reg 001',10.65,0.65,999,'Cash',0),
(9,1,123,41599.0280787037,'Reg 001',106.5,6.5,999,'Cash',0),
(10,1,123,41599.0424421296,'Reg 001',10.65,0.65,999,'Cash',0),
(11,1,123,41599.042974537,'Reg 001',10.65,0.65,999,'Cash',0),
(12,1,123,41599.0475578704,'Reg 001',10.65,0.65,999,'Cash',0),
(13,1,123,41599.3467592593,'Reg 001',69.23,4.23,999,'Cash',0),
(14,1,123,41604.3715972222,'Reg 001',74.54,4.55,999,'Cash',0),
(15,1,123,41610.892650463,'Reg 001',1160.67,70.84,999,'Cash',0),
(16,1,123,41610.8950578704,'Reg 001',10.65,0.65,999,'Cash',0),
(17,1,123,41610.9567708333,'Reg 001',15.98,0.98,999,'Cash',0),
(18,1,123,41611.342962963,'Reg 001',47.91,2.92,999,'Credit',0),
(19,1,123,41611.3445486111,'Reg 001',10.65,0.65,999,'Credit',0),
(20,1,123,41611.3461921296,'Reg 001',46.86,2.86,999,'Cash',0),
(21,1,123,41611.3480208333,'Reg 001',10.65,0.65,999,'Cash',0),
(22,1,123,41611.3587731481,'Reg 001',106.5,6.5,999,'Cash',0),
(23,1,123,41611.417037037,'Reg 001',47.91,2.92,999,'Credit',0),
(24,1,123,41611.4366435185,'Reg 001',47.91,2.92,999,'Credit',0),
(25,1,123,41611.4371759259,'Reg 001',106.5,6.5,999,'Credit',0),
(26,1,123,41611.4428009259,'Reg 001',47.91,2.92,999,'Credit',0),
(27,1,123,41611.4430555556,'Reg 001',47.91,2.92,999,'Credit',0),
(28,1,123,41611.4441203704,'Reg 001',47.91,2.92,999,'Credit',0),
(29,1,123,41611.4445138889,'Reg 001',47.91,2.92,999,'Credit',0),
(30,1,123,41611.4448726852,'Reg 001',47.91,2.92,999,'Credit',0),
(31,1,123,41613.5084837963,'Reg 001',47.13,2.88,999,'Cash',0),
(32,1,123,41613.5092476852,'Reg 001',74.54,4.55,999,'Cash',0),
(33,1,123,41613.5109143518,'Reg 001',74.54,4.55,999,'Cash',0),
(34,1,123,41613.5124305556,'Reg 001',74.54,4.55,999,'Cash',0),
(35,1,123,41613.5143865741,'Reg 001',74.54,4.55,999,'Cash',0),
(36,1,123,41613.5300810185,'Reg 001',149.08,9.1,999,'Credit',0),
(37,1,123,41613.5426967593,'Reg 001',1192.63,72.79,999,'Cash',0),
(38,1,123,41616.482349537,'Reg 001',48.97,2.99,999,'Cash',0),
(39,1,123,41617.485150463,'Reg 001',376.83,23,999,'Credit',0),
(40,1,123,41617.4881712963,'Reg 001',10.12,0.62,999,'Cash',0),
(41,1,123,41617.492337963,'Reg 001',47.91,2.92,999,'Cash',0),
(42,1,123,41617.493275463,'Reg 001',10.65,0.65,999,'Cash',0),
(43,1,123,41617.9654282407,'Reg 001',5303.7,323.7,999,'Cash',0),
(44,1,123,41617.9804513889,'Reg 001',4242.96,258.96,999,'Cash',0),
(45,1,123,41618.4807407407,'Reg 001',159.74,9.75,999,'Credit',0),
(46,1,123,41618.5085416666,'Reg 001',7.46,0.46,999,'Cash',0),
(47,1,123,41618.5504513889,'Reg 001',4248.13,259.28,999,'Credit',0)

GO

set IDENTITY_INSERT STORE_TRANSACTION OFF
GO

-- *********************************************************************
USE Master
GO