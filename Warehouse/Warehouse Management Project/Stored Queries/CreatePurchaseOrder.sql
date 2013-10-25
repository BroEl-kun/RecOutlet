SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
USE RecreationOutlet_Test1 --WE NEED TO CHANGE THIS WHEN THE DATABASE NAME CHANGES
GO
-- =============================================
-- Author:		Tyler M.
-- Create date: 10-25-2013
-- Description:	Stored Procedure for creating a new purchase order
-- =============================================

--Drop the procedure if it already exists...
IF OBJECT_ID('dbo.CreatePurchaseOrder', 'P') IS NOT NULL
	DROP PROCEDURE dbo.CreatePurchaseOrder;
GO

CREATE PROCEDURE dbo.CreatePurchaseOrder 
	-- Add the parameters for the stored procedure here
	@POID bigint,
	@VendorID smallint,
	@POCreateBy smallint,
	@POOrderDate datetime,
	@POEstShipDate datetime,
	@POFreightCost money,
	@POTerms varchar(10),
	@POComments varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	-- In other words, this avoids the 'x rows affected' message
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.PURCHASE_ORDER(
		POID, VendorID, POCreatedBy, POOrderDate,
		POEstimatedShipDate, POCreatedDate,
		POFreightCost, POTerms, POComments
	)
	VALUES (
		@POID, @VendorID, @POCreateBy, @POOrderDate,
		@POEstShipDate, @POOrderDate, @POFreightCost, --NOTE: Created date is the same as order date right now.
		@POTerms, @POComments
	)
END

GO
