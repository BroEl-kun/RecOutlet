-- *********************************************************************
--	         Project: Recreation Outlet 
--
--       Description: This DDL creates tables
--
--	Revision History:
--        01/16/2014: Chris Parkins - Created initial version
--        01/19/2014: Frank Eddy - Added script header and renamed
--                    database to RecreationOutlet
--
-- *********************************************************************

--Tables

USE [RecreationOutlet]
GO

/****** Object:  Table [dbo].[BACKORDER]    Script Date: 1/14/2014 7:10:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BACKORDER](
	[BackorderID] [int] NOT NULL,
	[POLineItemID] [int] NOT NULL,
	[ReceivingID] [int] NOT NULL,
	[BackorderQty] [smallint] NOT NULL
) ON [PRIMARY]
GO

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
	[ExceptionsID] [int] NOT NULL,
	[ManagerID] [int] NULL,
	[TransactionLineItemID] [int] NOT NULL,
	[PreviousTransactionLineItemID] [int] NOT NULL,
	[OverrideCode] [tinyint] NULL,
	[RefundCode] [tinyint] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVENTORY]    Script Date: 1/14/2014 7:23:44 PM ******/

CREATE TABLE [dbo].[INVENTORY](
	[StoreID] [tinyint] NOT NULL,
	[RecID] [int] NOT NULL,
	[QtyOnHand] [smallint] NOT NULL,
	[QtyThreshold] [smallint] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVOICE]    Script Date: 1/14/2014 7:25:50 PM ******/

CREATE TABLE [dbo].[INVOICE](
	[InvoiceID] [bigint] NOT NULL,
	[CustomerID] [nvarchar](max) NOT NULL,
	[ShippingID] [int] NOT NULL,
	[Attention] [nvarchar](max) NOT NULL,
	[PaymentDue] [smalldatetime] NOT NULL,
	[SalesTaxDue] [smallmoney] NOT NULL,
	[DatePaid] [smalldatetime] NOT NULL,
	[AmountPaid] [smallmoney] NOT NULL,
	[InvoiceNotes] [nvarchar](50) NULL,
	[InvoiceCreatedBy] [nvarchar](50) NOT NULL,
	[InvoiceCreatedDate] [smalldatetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVOICE_CUSTOMER]    Script Date: 1/14/2014 7:27:40 PM ******/

CREATE TABLE [dbo].[INVOICE_CUSTOMER](
	[CustomerID] [int] NOT NULL,
	[CustomerName] [nvarchar](max) NOT NULL,
	[CustomerPhoneNumber] [int] NULL,
	[TaxExemptID] [int] NULL,
	[CustomerPaymentTerms] [nvarchar](50) NULL,
	[CustomerAddress] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[INVOICE_LINEITEM]    Script Date: 1/14/2014 7:28:47 PM ******/

CREATE TABLE [dbo].[INVOICE_LINEITEM](
	[InvoiceLineItemID] [int] NOT NULL,
	[InvoiceID] [bigint] NOT NULL,
	[RecRPC] [int] NOT NULL,
	[InvoicePrice] [smallmoney] NOT NULL,
	[InvoiceItemQuantity] [smallint] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM]    Script Date: 1/14/2014 7:30:01 PM ******/

CREATE TABLE [dbo].[ITEM](
	[RecRPC] [bigint] NOT NULL,
	[ItemUPC] [bigint] NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[VendorItemID] [int] NOT NULL,
	[ProductLineID] [int] NOT NULL,
	[SeasonCode] [nvarchar](50) NULL,
	[ItemID] [int] NOT NULL,
	[CategoryID] [tinyint] NOT NULL,
	[DepartmentID] [tinyint] NOT NULL,
	[SubcategoryID] [tinyint] NOT NULL,
	[MSRP] [money] NULL,
	[SellPrice] [money] NOT NULL,
	[TaxRateID] [tinyint] NOT NULL,
	[RestrictedAge] [tinyint] NULL,
	[LegacyID] [smallint] NULL,
	[ItemCreatedBy] [smallint] NOT NULL,
	[ItemCreatedDate] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_CATEGORY]    Script Date: 1/14/2014 7:31:43 PM ******/

CREATE TABLE [dbo].[ITEM_CATEGORY](
	[CategoryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_DEPARTMENT]    Script Date: 1/14/2014 7:32:32 PM ******/

CREATE TABLE [dbo].[ITEM_DEPARTMENT](
	[DepartmentID] [tinyint] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_IMAGE]    Script Date: 1/15/2014 8:28:20 PM ******/

CREATE TABLE [dbo].[ITEM_IMAGE](
	[ItemImageID] [int] NOT NULL,
	[RecRPC] [bigint] NOT NULL,
	[ItemPath] [nvarchar](256) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ITEM_SUBCATEGORY]    Script Date: 1/15/2014 8:30:35 PM ******/

CREATE TABLE [dbo].[ITEM_SUBCATEGORY](
	[SubcategoryID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SubcategoryName] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[LOCATION]    Script Date: 1/15/2014 8:31:35 PM ******/

CREATE TABLE [dbo].[LOCATION](
	[StoreID] [tinyint] IDENTITY(1,1) NOT NULL,
	[StoreName] [nvarchar](50) NOT NULL,
	[ManagerId] [smallint] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[MERCHANDISE_TRANSFER]    Script Date: 1/15/2014 8:32:50 PM ******/

CREATE TABLE [dbo].[MERCHANDISE_TRANSFER](
	[TransferID] [bigint] NOT NULL,
	[RecRPC] [int] NOT NULL,
	[ToLocationID] [tinyint] NOT NULL,
	[FromLocationID] [tinyint] NOT NULL,
	[TansferDate] [date] NOT NULL,
	[TansferComments] [nvarchar](max) NULL,
	[TransferCreatedBy] [smallint] NOT NULL,
	[TransferCreatedDate] [date] NOT NULL,
	[Quantity] [smallint] NOT NULL,
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
	[StoreID] [tinyint] NOT NULL,
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
	[WholesaleCost] [smallmoney] NOT NULL,
	[QtyOrdered] [smallint] NOT NULL,
	[QtyTypeID] [tinyint] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PRODUCT_LINE]    Script Date: 1/15/2014 8:37:38 PM ******/

CREATE TABLE [dbo].[PRODUCT_LINE](
	[ProductLineID] [int] IDENTITY(1,1) NOT NULL,
	[ProductLineName] [nvarchar](50) NOT NULL,
	[VendorID] [smallint] NOT NULL,
	[RepID] [smallint] NOT NULL
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
	[ShippingID] [int] NULL
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
	[POLineItemID] [int] NULL,
	[BackorderID] [int] NULL,
	[QtyTypeID] [tinyint] NULL,
	[ReceiveDate] [smalldatetime] NOT NULL,
	[ReceivingNotes] [nvarchar](max) NULL,
	[ReceivedQty] [smallint] NULL
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
	[SalesRepName] [nvarchar](max) NOT NULL,
	[SalesRepPhone] [nvarchar](15) NOT NULL,
	[SalesRepEmail] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SHIPPING_LOG]    Script Date: 1/15/2014 8:42:49 PM ******/

CREATE TABLE [dbo].[SHIPPING_LOG](
	[ShippingID] [int] NOT NULL,
	[ID] [bigint] NOT NULL,
	[OrderType] [nchar](1) NOT NULL,
	[BackorderID] [int] NULL,
	[ShippingNotes] [nvarchar](max) NULL,
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
	[StoreID] [tinyint] NOT NULL,
	[EmployeeID] [smallint] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[TerminalID] [nvarchar](50) NOT NULL,
	[TransTotal] [money] NOT NULL,
	[TransTax] [money] NOT NULL,
	[ManagerID] [int] NULL,
	[PaymentType] [nvarchar](50) NOT NULL,
	[PreviousTransactionID] [int] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TAX_RATE]    Script Date: 1/15/2014 8:44:22 PM ******/

CREATE TABLE [dbo].[TAX_RATE](
	[TaxRateID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TaxRateType] [nvarchar](50) NOT NULL,
	[TaxRate] [decimal](5, 3) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TRANSACTION_LINE_ITEM]    Script Date: 1/17/2014 7:22:23 PM ******/

CREATE TABLE [dbo].[TRANSACTION_LINE_ITEM](
	[TransactionLineItemID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionID] [int] NOT NULL,
	[StoreID] [tinyint] NOT NULL,
	[RecID] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[SaleEach] [money] NOT NULL,
	[CommissionEmployeeID] [smallint] NOT NULL,
	[OverrideCode] [int] NULL,
	[RefundCode] [int] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[VENDOR]    Script Date: 1/17/2014 7:24:17 PM ******/

CREATE TABLE [dbo].[VENDOR](
	[VendorID] [smallint] IDENTITY(1,1) NOT NULL,
	[VendorName] [nvarchar](max) NOT NULL,
	[ContactName] [nvarchar](max) NULL,
	[ContactPhone] [nvarchar](50) NOT NULL,
	[ContactFax] [nvarchar](50) NULL,
	[AltPhone] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Website] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


-- *********************************************************************
USE Master
GO