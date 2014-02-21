-- *********************************************************************
--	         Project: Recreation Outlet 
--
--       Description: This DDL creates tables
--
--	Revision History:
--        01/16/2014: Chris Parkins - Created initial version
--        01/19/2014: Frank Eddy - Added script header and renamed
--                    database to RecreationOutlet
--		  01/25/2014: Chris Parkins - Removed columns from Shipping_Log,
--					  Backorder, Receiving_Log
--		  01/27/2014: Chris Parkins - Altered keys, now functions
--					  according to V1 ERDs
--		  01/30/2014: Chris Parkins - Payment and Store Transaction column
--					  changes (And TransLineItems)
--		  02/01/2014: Chris Parkins - Transaction Line Item table edits
--		  02/09/2014: Chris Parkins - Phase 2 Warehouse changes
--		  02/11/2014: Chris Parkins - Added Tax table changes
--		  02/20/2014: Chris Parkins - All Phone lengths changed to 15,
--					  Addresses have address line 2, city, country,
--					  and item quantities bumped to full ints.
--
-- *********************************************************************

--Tables

USE [RecreationOutlet]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  Table [dbo].[BACKORDER]    Script Date: 1/14/2014 7:10:16 PM ******/

--CREATE TABLE [dbo].[BACKORDER](
--	[BackorderID] [int] NOT NULL,
--	--[POLineItemID] [int] NOT NULL,
--	[ReceivingID] [int] NOT NULL,
--	[BackorderQty] [int] NOT NULL
--) ON [PRIMARY]
--GO

/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 1/14/2014 7:19:46 PM ******/

CREATE TABLE [dbo].[EMPLOYEE](
	[EmployeeId] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[PIN] [nchar](4) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EVENT_TYPE]    Script Date: 1/14/2014 7:21:02 PM ******/

CREATE TABLE [dbo].[EVENT_TYPE](
	[EventTypeCode] [tinyint] IDENTITY(1,1) NOT NULL,
	[EventDescription] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[EXCEPTIONS]    Script Date: 1/14/2014 7:22:10 PM ******/

CREATE TABLE [dbo].[EXCEPTIONS](
	[ExceptionsID] [int] NOT NULL, --Need IDENTITY(1,1)?
	[ManagerID] [int] NULL,
	[TransactionLineItemID] [int] NOT NULL,
	[PreviousTransactionLineItemID] [int] NOT NULL,
	[OverrideCode] [tinyint] NULL,
	[RefundCode] [tinyint] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVENTORY]    Script Date: 1/14/2014 7:23:44 PM ******/

CREATE TABLE [dbo].[INVENTORY](
	[InventoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationID] [tinyint] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[QtyTypeID] [tinyint] NOT NULL,
	[QtyOnHand] [int] NOT NULL,
	[QtyThreshold] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVOICE]    Script Date: 1/14/2014 7:25:50 PM ******/

CREATE TABLE [dbo].[INVOICE](
	[InvoiceID] [bigint] NOT NULL, --Need IDENTITY(1,1)?
	[CustomerID] [int] NOT NULL,
	--[ShippingID] [int] NOT NULL,	
	[InvoiceCreatedBy] [smallint] NOT NULL,
	[InvoiceCreatedDate] [smalldatetime] NOT NULL,
	[Attention] [nvarchar](50) NULL,
	--[PaymentDue] [smalldatetime] NOT NULL,
	[TotalSalesTax] [smallmoney] NOT NULL,
	[TotalAmount] [smallmoney] NOT NULL,
	[TotalAmountPaid] [smallmoney] NOT NULL,
	[LastPaymentReceived] [smalldatetime] NULL,
	[InvoiceNotes] [nvarchar](100) NULL
) ON [PRIMARY] -- TEXTIMAGE_ON [PRIMARY]	--So would it be more efficient to actually use nvarchar(max) at least once then use the TEXTIMAGE_ON?

GO

/****** Object:  Table [dbo].[INVOICE_CUSTOMER]    Script Date: 1/14/2014 7:27:40 PM ******/

CREATE TABLE [dbo].[INVOICE_CUSTOMER](
	[CustomerID] [int] NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[TaxExemptID] [int] NULL,
	[CustomerPaymentTerms] [nvarchar](50) NULL,
	[CustomerAddress] [nvarchar](50) NULL,
	[CustomerAddress2] [nvarchar](50) NULL,
	[CustomerCity] [nvarchar](25) NULL,
	[CustomerState] [nvarchar](2) NULL,
	[CustomerZip] [nvarchar](10) NULL,
	[CustomerCountry] [nvarchar](50) NULL,
	[CustomerPhone] [nvarchar](15) NULL
) ON [PRIMARY] --TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVOICE_LINEITEM]    Script Date: 1/14/2014 7:28:47 PM ******/

CREATE TABLE [dbo].[INVOICE_LINEITEM](
	[InvoiceLineItemID] [int] NOT NULL,
	[InvoiceID] [bigint] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[QtyTypeID] [tinyint] NOT NULL,
	[ItemQty] [int] NOT NULL,
	[UnitPrice] [smallmoney] NOT NULL,
	[UnitCost] [smallmoney] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM]    Script Date: 1/14/2014 7:30:01 PM ******/

CREATE TABLE [dbo].[ITEM](
	[RecRPC] [bigint] NOT NULL,
	[CategoryID] [tinyint] NOT NULL,
	--[CategoryID] [smallint] NOT NULL,
	[DepartmentID] [tinyint] NOT NULL,
	--[DepartmentID] [smallint] NOT NULL,
	--[SubcategoryID] [tinyint] NOT NULL,
	[SubcategoryID] [smallint] NOT NULL,
	[ProductLineID] [int] NOT NULL,
	--[TaxRateID] [tinyint] NOT NULL,
	[TaxTypeID] [tinyint] NOT NULL,
	[LegacyID] [smallint] NULL,
	[ItemUPC] [bigint] NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[VendorItemID] [int] NOT NULL,
	[SeasonCode] [nvarchar](50) NULL,
	[ItemID] [int] NOT NULL,
	[MSRP] [money] NULL,
	[SellPrice] [money] NOT NULL,
	[RestrictedAge] [tinyint] NULL,
	[ItemCreatedBy] [smallint] NOT NULL,
	[ItemCreatedDate] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_CATEGORY]    Script Date: 1/14/2014 7:31:43 PM ******/

CREATE TABLE [dbo].[ITEM_CATEGORY](
	[CategoryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryDescription] [nvarchar](max) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_DEPARTMENT]    Script Date: 1/14/2014 7:32:32 PM ******/

CREATE TABLE [dbo].[ITEM_DEPARTMENT](
	[DepartmentID] [tinyint] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[DepartmentDescription] [nvarchar](max) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_IMAGE]    Script Date: 1/15/2014 8:28:20 PM ******/

CREATE TABLE [dbo].[ITEM_IMAGE](
	[ItemImageID] [int] IDENTITY(1,1) NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[ItemImagePath] [nvarchar](256) NOT NULL,
	[ItemImageDescription] [nvarchar](max) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_SUBCATEGORY]    Script Date: 1/15/2014 8:30:35 PM ******/

CREATE TABLE [dbo].[ITEM_SUBCATEGORY](
	--[SubcategoryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SubcategoryID] [smallint] IDENTITY(1,1) NOT NULL,
	[SubcategoryName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LOCATION]    Script Date: 1/15/2014 8:31:35 PM ******/

CREATE TABLE [dbo].[LOCATION](
	[LocationID] [tinyint] IDENTITY(1,1) NOT NULL,
	[ManagerId] [smallint] NOT NULL,
	[StoreName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[Address2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [char](2) NULL,
	[Zip] [nvarchar](10) NULL,
	[Country] [nvarchar](50) NULL,
	[Phone] [nvarchar](15) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[MERCHANDISE_TRANSFER]    Script Date: 1/15/2014 8:32:50 PM ******/

CREATE TABLE [dbo].[MERCHANDISE_TRANSFER](
	[TransferID] [bigint] IDENTITY(1,1) NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[ToLocationID] [tinyint] NOT NULL,
	[FromLocationID] [tinyint] NOT NULL,
	[TansferDate] [date] NOT NULL,
	[TansferComments] [nvarchar](max) NULL,
	[TransferCreatedBy] [smallint] NOT NULL,
	[TransferCreatedDate] [date] NOT NULL,
	[Quantity] [int] NOT NULL,
	[QtyTypeID] [tinyint] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[OVERRIDE_CODE]    Script Date: 1/15/2014 8:33:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OVERRIDE_CODE](
	[OverrideCode] [tinyint] NOT NULL,
	[OverrideReason] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PAYMENT]    Script Date: 1/15/2014 8:34:51 PM ******/

CREATE TABLE [dbo].[PAYMENT](
	[PaymentID] [smallint] IDENTITY(1,1) NOT NULL,
	[PaymentTypeID] [tinyint] NOT NULL,
	[TransactionID] [int] NOT NULL,
	--[LocationID] [tinyint] NOT NULL,
	[PaymentAmount] [smallmoney] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PAYMENT_TYPE]    Script Date: 1/15/2014 8:35:43 PM ******/

CREATE TABLE [dbo].[PAYMENT_TYPE](
	[PaymentTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[PaymentTypeName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PO_LINEITEM]    Script Date: 1/15/2014 8:36:41 PM ******/

CREATE TABLE [dbo].[PO_LINEITEM](
	[POLineItemID] [int] IDENTITY(1,1) NOT NULL,
	[POID] [bigint] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[QtyTypeID] [tinyint] NOT NULL,
	[WholesaleCost] [smallmoney] NOT NULL,
	[QtyOrdered] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PRODUCT_LINE]    Script Date: 1/15/2014 8:37:38 PM ******/

CREATE TABLE [dbo].[PRODUCT_LINE](
	[ProductLineID] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [smallint] NOT NULL,
	[RepID] [smallint] NOT NULL,
	[ProductLineName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PURCHASE_ORDER]    Script Date: 1/15/2014 8:38:23 PM ******/

CREATE TABLE [dbo].[PURCHASE_ORDER](
	[POID] [bigint] NOT NULL,
	[VendorID] [smallint] NOT NULL,
	[POCreatedBy] [smallint] NOT NULL,
	[POOrderDate] [smalldatetime] NULL,
	[POEstimatedShipDate] [smalldatetime] NULL,
	[POCreatedDate] [smalldatetime] NOT NULL,
	[POFreightCost] [nvarchar](50) NULL,
	[POTerms] [nvarchar](50) NULL,
	[POComments] [nvarchar](50) NULL,
	[ShippingID] [int] NULL,
	[POCancelIfNotReceivedBy] [smalldatetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[QTY_TYPE]    Script Date: 1/15/2014 8:39:07 PM ******/

CREATE TABLE [dbo].[QTY_TYPE](
	[QtyTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[QtyTypeDescription] [nvarchar](50) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[RECEIVING_LOG]    Script Date: 1/15/2014 8:39:51 PM ******/

CREATE TABLE [dbo].[RECEIVING_LOG](
	[ReceivingID] [int] IDENTITY(1,1) NOT NULL,
	[POLineItemID] [int] NULL,		--They can receive items without first ordering them. Ex. samples
	--[BackorderID] [int] NULL,
	[QtyTypeID] [tinyint] NULL,
	[ReceiveDate] [smalldatetime] NOT NULL,
	[ReceivingNotes] [nvarchar](max) NULL,
	[ReceivedQty] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[REFUND_CODE]    Script Date: 1/15/2014 8:40:49 PM ******/

CREATE TABLE [dbo].[REFUND_CODE](
	[RefundCode] [tinyint] NOT NULL,
	[RefundReason] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SALE_PRICING]    Script Date: 1/15/2014 8:41:21 PM ******/

CREATE TABLE [dbo].[SALE_PRICING](
	[EventTypeCode] [tinyint] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[SalePrice] [smallmoney] NOT NULL,
	[BeginDate] [date] NULL,
	[EndDate] [date] NULL,
	[Comments] [nvarchar](50) NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SALES_REP]    Script Date: 1/15/2014 8:42:05 PM ******/

CREATE TABLE [dbo].[SALES_REP](
	[RepID] [smallint] IDENTITY(1,1) NOT NULL,
	[SalesRepName] [nvarchar](100) NOT NULL,
	[SalesRepPhone] [nvarchar](15) NOT NULL,
	[SalesRepEmail] [nvarchar](50) NULL
) ON [PRIMARY] --TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SHIPPING_LOG]    Script Date: 1/15/2014 8:42:49 PM ******/

CREATE TABLE [dbo].[SHIPPING_LOG](
	[ShippingID] [int] NOT NULL,
	[InvoiceID] [bigint] NOT NULL,
	--[ID] [bigint] NOT NULL,
	--[OrderType] [nchar](1) NOT NULL,
	--[BackorderID] [int] NULL,
	[ShippingNotes] [nvarchar](max) NULL,
	[ShippingWeight] [int] NULL,
	[ShippingFrieghtCost] [smallmoney] NOT NULL,
	[Attention] [nvarchar](50) NOT NULL,
	[EstimatedShipDate] [smalldatetime] NULL,
	[ShipDate] [smalldatetime] NULL,
	[ShipSource] [nvarchar](50) NULL,
	[TrackingNum] [nvarchar](50) NULL,
	[FreightProvider] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[STORE_TRANSACTION]    Script Date: 1/15/2014 8:43:44 PM ******/

CREATE TABLE [dbo].[STORE_TRANSACTION](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[LocationID] [tinyint] NOT NULL,
	[EmployeeID] [smallint] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TerminalID] [nvarchar](50) NOT NULL,
	[TransTotal] [money] NOT NULL,
	[TransTax] [money] NOT NULL,
	[ManagerID] [int] NULL,
	--[PaymentID] [smallint] NOT NULL,
	[PreviousTransactionID] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TAX_RATE]    Script Date: 1/15/2014 8:44:22 PM ******/

CREATE TABLE [dbo].[TAX_RATE](
	[TaxRateID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TaxTypeID] [tinyint] NOT NULL,
	[LocationID] [tinyint] NULL,
	[TaxRate] [decimal] NOT NULL, --Is this the correct data type?
	[StartDate] [smalldatetime] NOT NULL,
	[EndDate] [smalldatetime] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TAX_TYPE]    Script Date: 1/15/2014 8:44:22 PM ******/

CREATE TABLE [dbo].[TAX_TYPE](
	[TaxTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	--[TaxRateType] [nvarchar](50) NOT NULL,
	--[TaxRate] [decimal](5, 3) NOT NULL
	[TaxTypeName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TRANSACTION_LINEITEM]    Script Date: 1/17/2014 7:22:23 PM ******/

CREATE TABLE [dbo].[TRANSACTION_LINEITEM](
	[TransactionLineItemID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	--[LocationID] [tinyint] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
	--[SaleEach] [money] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[UnitCost] [money] NOT NULL,
	[CommissionEmployeeID] [smallint] NOT NULL,
	--[OverrideCode] [int] NULL,
	--[RefundCode] [int] NULL
	[ItemTaxTotal] [money] NOT NULL,
	[ItemTotal] [money] NOT NULL,
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[VENDOR]    Script Date: 1/17/2014 7:24:17 PM ******/

CREATE TABLE [dbo].[VENDOR](
	[VendorID] [smallint] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](100) NOT NULL,
	[ContactName] [nvarchar](100) NULL,
	[ContactPhone] [nvarchar](15) NOT NULL,
	[ContactFax] [nvarchar](15) NULL,
	[AltPhone] [nvarchar](15) NULL,
	[VendorAddress] [nvarchar](50) NULL,
	[VendorAddress2] [nvarchar](50) NULL,
	[VendorCity] [nvarchar](25) NULL,
	[VendorState] [nvarchar](2) NULL,
	[VendorZip] [nvarchar](10) NULL,
	[VendorCountry] [nvarchar](50) NULL,
	[VendorWebsite] [nvarchar](100) NULL
) ON [PRIMARY] --TEXTIMAGE_ON [PRIMARY]

GO


-- *********************************************************************
USE Master
GO