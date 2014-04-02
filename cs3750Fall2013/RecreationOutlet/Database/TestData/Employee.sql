USE [RecreationOutlet]
GO

set IDENTITY_INSERT EMPLOYEE ON
GO

DELETE FROM EMPLOYEE
GO

INSERT INTO EMPLOYEE ([EmployeeID],[FirstName],[LastName],[Position],[Username],[Password],[PasswordSalt]) VALUES
(1,'Neo','Anderson','Security Expert','neoanderson','Elo5EVVD2xfMpPVCeiKh0Aq9af/pBCTChdEX3IZT3JRhuexXf0EAFhlYfmTy1qNrlAJjYiEr+hQc/xImopvmGQ==            ','100000.0ROL0cY9L1Ds46wzRaPljQf0XSA9yA7C6lxbpDpJQwbRSw==     '),
(2,'Sam','Daniels','Cashier','samdaniels','null','null'),
(3,'Justin','Smith','Manager','justinsmith','null','null'),
(4,'Rebecca','Hancock','Cashier','rebeccahancock','null','null'),
(5,'Amy','Withers','Cashier','amywithers','null','null'),
(6,'Bobby','Lara','Sales Assistant','bobbylara','null','null'),
(7,'Bryan','Torres','Stock Assistant','bryantorres','null','null'),
(8,'Lisa','Collins','Assistant Manager','lisacollins','null','null'),
(9,'Erin','Dickenson','Manager','erindickenson','null','null'),
(10,'Recreation','Outlet','Owner','recreation','rE7/jWU3dcNLZnJWY6gUcZtzlR3H1sl1ta5PmMjiuEFbOs3RUyKNLcSwlMCb4i9CveVXADfvW0tpkOOX2ySSqA==','100000.eexOOogSi9Svfak82JdMdm1aPPol+nW3kahSpLz2Xtiayw=='),
(11,'Jorge','Clapp','Manager','jorgeclapp','null','null'),
(12,'Hilda','Ricks','Sales Assistant','hildaricks','null','null'),
(13,'Edwin','Toth','Stock Assistant','edwintoth','null','null'),
(14,'Ryder','Chirside','Security Expert','ryderchirside','null','null'),
(15,'Abbey','Rosman','Manager','abbeyrosman','null','null'),
(16,'Rohini','Bakkeren','CEO','rohinibakkeren','null','null'),
(17,'Juliane','Mikaelsen','Cashier','julianemikaelsen','null','null'),
(18,'Germana','Lorenzo','Assistant Manager','germanalorenzo','null','null'),
(19,'Consuelo','Milani','Stock Assistant','consuelomilani','null','null'),
(20,'Samuel','Murray','Security Expert','samuelmurray','null','null'),
(21,'Chelsea','Patton','Manager','chelseaoneal','null','null'),
(22,'Ales','Fisher','Sales Assistant','alexfisher','null','null'),
(23,'Matt','Griffen','Owner','mattgriffen','null','null'),
(24,'Carolyn','Riccardi','Cashier','carolynriccardi','null','null'),
(25,'Klaudia ','Schwartz','Assistant Manager','Klaudiaschwartz','null','null'),
(26,'Ralf','Faber','Stock Assistant','ralffaber','null','null'),
(27,'Lee ','Yang','Manager','leeyang','null','null')


GO

set IDENTITY_INSERT EMPLOYEE OFF
GO

-- *********************************************************************
USE Master
GO