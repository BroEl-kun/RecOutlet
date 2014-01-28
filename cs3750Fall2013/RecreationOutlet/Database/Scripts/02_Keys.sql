-- *********************************************************************
--	         Project: Recreation Outlet 
--
--       Description: This DDL creates primary and foreign keys
--
--	Revision History:
--        01/16/2014: Chris Parkins - Created initial version
--        01/19/2014: Frank Eddy - Added script header and renamed
--                    database to RecreationOutlet
--		  01/22/2014: Chris Parkins - Reorganized into Primary then
--					  Foriegn keys
--		  01/25/2014: Chris Parkins - Numerous foreign key edits.
--		  01/27/2014: Chris Parkins - Altered keys, now functions
--					  according to V1 ERDs.
--
-- *********************************************************************

--Constraints
USE [RecreationOutlet]
GO

-- *********************************************************************
-- STEP 1:  Add Primary Keys to Tables
-- *********************************************************************

/****** Object:  Index [PK_BACKORDER]    Script Date: 1/14/2014 7:18:08 PM ******/
ALTER TABLE [dbo].[BACKORDER] ADD  CONSTRAINT [PK_BACKORDER] PRIMARY KEY CLUSTERED 
(
	[BackorderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_EMPLOYEE]    Script Date: 1/14/2014 7:20:34 PM ******/
ALTER TABLE [dbo].[EMPLOYEE] ADD  CONSTRAINT [PK_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_EVENT_TYPE]    Script Date: 1/14/2014 7:21:45 PM ******/
ALTER TABLE [dbo].[EVENT_TYPE] ADD  CONSTRAINT [PK_EVENT_TYPE] PRIMARY KEY CLUSTERED 
(
	[EventTypeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_EXCEPTIONS]    Script Date: 1/14/2014 7:23:22 PM ******/
ALTER TABLE [dbo].[EXCEPTIONS] ADD  CONSTRAINT [PK_EXCEPTIONS] PRIMARY KEY CLUSTERED 
(
	[ExceptionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_INVENTORY]    Script Date: 1/14/2014 7:24:43 PM ******/
ALTER TABLE [dbo].[INVENTORY] ADD  CONSTRAINT [PK_INVENTORY] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC,
	[RecRPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[INVENTORY]  WITH CHECK ADD  CONSTRAINT [FK_INVENTORY_LOCATION] FOREIGN KEY([StoreID])
--REFERENCES [dbo].[LOCATION] ([StoreID])
--GO

--ALTER TABLE [dbo].[INVENTORY] CHECK CONSTRAINT [FK_INVENTORY_LOCATION]
--GO

/****** Object:  Index [PK_INVOICE]    Script Date: 1/14/2014 7:26:24 PM ******/
ALTER TABLE [dbo].[INVOICE] ADD  CONSTRAINT [PK_INVOICE] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[INVOICE]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_SHIPPING_LOG] FOREIGN KEY([ShippingID])
--REFERENCES [dbo].[SHIPPING_LOG] ([ShippingID])
--GO

--ALTER TABLE [dbo].[INVOICE] CHECK CONSTRAINT [FK_INVOICE_SHIPPING_LOG]
--GO

/****** Object:  Index [PK_INVOICE_CUSTOMER]    Script Date: 1/14/2014 7:28:15 PM ******/
ALTER TABLE [dbo].[INVOICE_CUSTOMER] ADD  CONSTRAINT [PK_INVOICE_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_INVOICE_LINEITEM]    Script Date: 1/14/2014 7:29:14 PM ******/
ALTER TABLE [dbo].[INVOICE_LINEITEM] ADD  CONSTRAINT [PK_INVOICE_LINEITEM] PRIMARY KEY CLUSTERED 
(
	[InvoiceLineItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_ITEM]    Script Date: 1/14/2014 7:30:46 PM ******/
ALTER TABLE [dbo].[ITEM] ADD  CONSTRAINT [PK_ITEM] PRIMARY KEY CLUSTERED 
(
	[RecRPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_CATEGORY] FOREIGN KEY([CategoryID])
--REFERENCES [dbo].[ITEM_CATEGORY] ([CategoryID])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_CATEGORY]
--GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_DEPARTMENT] FOREIGN KEY([DepartmentID])
--REFERENCES [dbo].[ITEM_DEPARTMENT] ([DepartmentID])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_DEPARTMENT]
--GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_SUBCATEGORY] FOREIGN KEY([SubcategoryID])
--REFERENCES [dbo].[ITEM_SUBCATEGORY] ([SubcategoryID])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_SUBCATEGORY]
--GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_PRODUCT_LINE] FOREIGN KEY([ProductLineID])
--REFERENCES [dbo].[PRODUCT_LINE] ([ProductLineID])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_PRODUCT_LINE]
--GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_TAX_RATE] FOREIGN KEY([TaxRateID])
--REFERENCES [dbo].[TAX_RATE] ([TaxRateID])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_TAX_RATE]
--GO

/****** Object:  Index [PK_ITEM_CATEGORY]    Script Date: 1/14/2014 7:32:04 PM ******/
ALTER TABLE [dbo].[ITEM_CATEGORY] ADD  CONSTRAINT [PK_ITEM_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_ITEM_DEPARTMENT]    Script Date: 1/14/2014 8:00:35 PM ******/
ALTER TABLE [dbo].[ITEM_DEPARTMENT] ADD  CONSTRAINT [PK_ITEM_DEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_ITEM_IMAGE]    Script Date: 1/15/2014 8:29:41 PM ******/
ALTER TABLE [dbo].[ITEM_IMAGE] ADD  CONSTRAINT [PK_ITEM_IMAGE] PRIMARY KEY CLUSTERED 
(
	[ItemImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[ITEM_IMAGE]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_IMAGE_ITEM] FOREIGN KEY([RecRPC])
--REFERENCES [dbo].[ITEM] ([RecRPC])
--GO

--ALTER TABLE [dbo].[ITEM_IMAGE] CHECK CONSTRAINT [FK_ITEM_IMAGE_ITEM]
--GO

/****** Object:  Index [PK_ITEM_SUBCATEGORY]    Script Date: 1/15/2014 8:31:08 PM ******/
ALTER TABLE [dbo].[ITEM_SUBCATEGORY] ADD  CONSTRAINT [PK_ITEM_SUBCATEGORY] PRIMARY KEY CLUSTERED 
(
	[SubcategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_LOCATION]    Script Date: 1/15/2014 8:31:40 PM ******/
ALTER TABLE [dbo].[LOCATION] ADD  CONSTRAINT [PK_LOCATION] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[LOCATION]  WITH CHECK ADD  CONSTRAINT [FK_LOCATION_EMPLOYEE] FOREIGN KEY([ManagerId])
--REFERENCES [dbo].[EMPLOYEE] ([EmployeeId])
--GO

--ALTER TABLE [dbo].[LOCATION] CHECK CONSTRAINT [FK_LOCATION_EMPLOYEE]
--GO

/****** Object:  Index [PK_MERCHANDISE_TRANSFER]    Script Date: 1/15/2014 8:33:06 PM ******/
ALTER TABLE [dbo].[MERCHANDISE_TRANSFER] ADD  CONSTRAINT [PK_MERCHANDISE_TRANSFER] PRIMARY KEY CLUSTERED 
(
	[TransferID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_OVERRIDE_CODE]    Script Date: 1/15/2014 8:33:56 PM ******/
ALTER TABLE [dbo].[OVERRIDE_CODE] ADD  CONSTRAINT [PK_OVERRIDE_CODE] PRIMARY KEY CLUSTERED 
(
	[OverrideCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_PAYMENT]    Script Date: 1/15/2014 8:34:56 PM ******/
ALTER TABLE [dbo].[PAYMENT] ADD  CONSTRAINT [PK_PAYMENT] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeID] ASC,
	[PaymentID] ASC,
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENT_LOCATION] FOREIGN KEY([StoreID])
--REFERENCES [dbo].[LOCATION] ([StoreID])
--GO

--ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_PAYMENT_LOCATION]
--GO

--ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENT_PAYMENT_TYPE] FOREIGN KEY([PaymentTypeID])
--REFERENCES [dbo].[PAYMENT_TYPE] ([PaymentTypeID])
--GO

--ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_PAYMENT_PAYMENT_TYPE]
--GO

/****** Object:  Index [PK_PAYMENT_TYPE]    Script Date: 1/15/2014 8:35:46 PM ******/
ALTER TABLE [dbo].[PAYMENT_TYPE] ADD  CONSTRAINT [PK_PAYMENT_TYPE] PRIMARY KEY CLUSTERED 
(
	[PaymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_PO_LINEITEM]    Script Date: 1/15/2014 8:36:45 PM ******/
ALTER TABLE [dbo].[PO_LINEITEM] ADD  CONSTRAINT [PK_PO_LINEITEM] PRIMARY KEY CLUSTERED 
(
	[POLineItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_ITEM] FOREIGN KEY([RecRPC])
--REFERENCES [dbo].[ITEM] ([RecRPC])
--GO

--ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_ITEM]
--GO

--ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_PURCHASE_ORDER] FOREIGN KEY([POID])
--REFERENCES [dbo].[PURCHASE_ORDER] ([POID])
--GO

--ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_PURCHASE_ORDER]
--GO

--ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_QTY_TYPE] FOREIGN KEY([QtyTypeID])
--REFERENCES [dbo].[QTY_TYPE] ([QtyTypeID])
--GO

--ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_QTY_TYPE]
--GO

/****** Object:  Index [PK_PRODUCT_LINE]    Script Date: 1/15/2014 8:37:41 PM ******/
ALTER TABLE [dbo].[PRODUCT_LINE] ADD  CONSTRAINT [PK_PRODUCT_LINE] PRIMARY KEY CLUSTERED 
(
	[ProductLineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[PRODUCT_LINE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_LINE_SALES_REP] FOREIGN KEY([RepID])
--REFERENCES [dbo].[SALES_REP] ([RepID])
--GO

--ALTER TABLE [dbo].[PRODUCT_LINE] CHECK CONSTRAINT [FK_PRODUCT_LINE_SALES_REP]
--GO

--ALTER TABLE [dbo].[PRODUCT_LINE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_LINE_VENDOR] FOREIGN KEY([VendorID])
--REFERENCES [dbo].[VENDOR] ([VendorID])
--GO

--ALTER TABLE [dbo].[PRODUCT_LINE] CHECK CONSTRAINT [FK_PRODUCT_LINE_VENDOR]
--GO

/****** Object:  Index [PK_PURCHASE_ORDER]    Script Date: 1/15/2014 8:38:27 PM ******/
ALTER TABLE [dbo].[PURCHASE_ORDER] ADD  CONSTRAINT [PK_PURCHASE_ORDER] PRIMARY KEY CLUSTERED 
(
	[POID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_EMPLOYEE] FOREIGN KEY([POCreatedBy])
--REFERENCES [dbo].[EMPLOYEE] ([EmployeeId])
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_EMPLOYEE]
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_SHIPPING_LOG] FOREIGN KEY([ShippingID])
--REFERENCES [dbo].[SHIPPING_LOG] ([ShippingID])
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_SHIPPING_LOG]
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_VENDOR] FOREIGN KEY([VendorID])
--REFERENCES [dbo].[VENDOR] ([VendorID])
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_VENDOR]
--GO

/****** Object:  Index [PK_QTY_TYPE]    Script Date: 1/15/2014 8:39:11 PM ******/
ALTER TABLE [dbo].[QTY_TYPE] ADD  CONSTRAINT [PK_QTY_TYPE] PRIMARY KEY CLUSTERED 
(
	[QtyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_RECEIVING_LOG]    Script Date: 1/15/2014 8:39:55 PM ******/
ALTER TABLE [dbo].[RECEIVING_LOG] ADD  CONSTRAINT [PK_RECEIVING_LOG] PRIMARY KEY CLUSTERED 
(
	[ReceivingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_BACKORDER] FOREIGN KEY([BackorderID])
--REFERENCES [dbo].[BACKORDER] ([BackorderID])
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_BACKORDER]
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_PO_LINEITEM] FOREIGN KEY([POLineItemID])
--REFERENCES [dbo].[PO_LINEITEM] ([POLineItemID])
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_PO_LINEITEM]
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_QTY_TYPE] FOREIGN KEY([QtyTypeID])
--REFERENCES [dbo].[QTY_TYPE] ([QtyTypeID])
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_QTY_TYPE]
--GO

/****** Object:  Index [PK_REFUND_CODE]    Script Date: 1/15/2014 8:40:52 PM ******/
ALTER TABLE [dbo].[REFUND_CODE] ADD  CONSTRAINT [PK_REFUND_CODE] PRIMARY KEY CLUSTERED 
(
	[RefundCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_SALE_PRICING]    Script Date: 1/15/2014 8:41:25 PM ******/
ALTER TABLE [dbo].[SALE_PRICING] ADD  CONSTRAINT [PK_SALE_PRICING] PRIMARY KEY CLUSTERED 
(
	[EventTypeCode] ASC,
	[RecRPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[SALE_PRICING]  WITH CHECK ADD  CONSTRAINT [FK_SALE_PRICING_EVENT_TYPE] FOREIGN KEY([EventTypeCode], [RecRPC])
--REFERENCES [dbo].[SALE_PRICING] ([EventTypeCode], [RecRPC])
--GO

--ALTER TABLE [dbo].[SALE_PRICING] CHECK CONSTRAINT [FK_SALE_PRICING_EVENT_TYPE]
--GO

/****** Object:  Index [PK_SALES_REP]    Script Date: 1/15/2014 8:42:09 PM ******/
ALTER TABLE [dbo].[SALES_REP] ADD  CONSTRAINT [PK_SALES_REP] PRIMARY KEY CLUSTERED 
(
	[RepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_SHIPPING_LOG]    Script Date: 1/15/2014 8:42:53 PM ******/
ALTER TABLE [dbo].[SHIPPING_LOG] ADD  CONSTRAINT [PK_SHIPPING_LOG] PRIMARY KEY CLUSTERED 
(
	[ShippingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_BACKORDER] FOREIGN KEY([BackorderID])
--REFERENCES [dbo].[BACKORDER] ([BackorderID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_BACKORDER]
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_INVOICE] FOREIGN KEY([ID])
--REFERENCES [dbo].[INVOICE] ([InvoiceID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_INVOICE]
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_PURCHASE_ORDER] FOREIGN KEY([ID])
--REFERENCES [dbo].[PURCHASE_ORDER] ([POID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_PURCHASE_ORDER]
--GO

/****** Object:  Index [PK_STORE_TRANSACTION]    Script Date: 1/15/2014 8:43:49 PM ******/
ALTER TABLE [dbo].[STORE_TRANSACTION] ADD  CONSTRAINT [PK_STORE_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC,
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_TAX_RATE]    Script Date: 1/15/2014 8:44:26 PM ******/
ALTER TABLE [dbo].[TAX_RATE] ADD  CONSTRAINT [PK_TAX_RATE] PRIMARY KEY CLUSTERED 
(
	[TaxRateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

/****** Object:  Index [PK_TRANSACTION_LINEITEM]    Script Date: 1/17/2014 7:22:31 PM ******/
ALTER TABLE [dbo].[TRANSACTION_LINEITEM] ADD  CONSTRAINT [PK_TRANSACTION_LINEITEM] PRIMARY KEY CLUSTERED 
(
	[TransactionLineItemID] ASC--,
	--[TransactionID] ASC,
	--[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--ALTER TABLE [dbo].[TRANSACTION_LINE_ITEM]  WITH CHECK ADD  CONSTRAINT [FK_TRANSACTION_LINE_ITEM_STORE_TRANSACTION] FOREIGN KEY([TransactionID], [StoreID])
--REFERENCES [dbo].[STORE_TRANSACTION] ([TransactionID], [StoreID])
--GO

--ALTER TABLE [dbo].[TRANSACTION_LINE_ITEM] CHECK CONSTRAINT [FK_TRANSACTION_LINE_ITEM_STORE_TRANSACTION]
--GO

/****** Object:  Index [PK_VENDOR]    Script Date: 1/17/2014 7:24:21 PM ******/
ALTER TABLE [dbo].[VENDOR] ADD  CONSTRAINT [PK_VENDOR] PRIMARY KEY CLUSTERED 
(
	[VendorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- ******************************************************************																				--------------------------------------------
-- STEP 2: Add Foreign Keys to Tables
-- Read as: Table X has a Foreign Key coming from Table Y ON Y.PK
-- ******************************************************************

--Remember: FK constraints point FROM the FK table TO the PK table

/****** Object:  Index [PK_BACKORDER]    Script Date: 1/14/2014 7:24:43 PM ******/

ALTER TABLE [dbo].[BACKORDER]  WITH CHECK ADD  CONSTRAINT [FK_BACKORDER_RECEIVING_LOG] FOREIGN KEY([ReceivingID])
REFERENCES [dbo].[RECEIVING_LOG] ([ReceivingID])
GO

ALTER TABLE [dbo].[BACKORDER] CHECK CONSTRAINT [FK_BACKORDER_RECEIVING_LOG]
GO

/****** Object:  Index [PK_EXCEPTIONS]    Script Date: 1/14/2014 7:24:43 PM ******/

ALTER TABLE [dbo].[EXCEPTIONS]  WITH CHECK ADD  CONSTRAINT [FK_EXCEPTIONS_TRANSACTION_LINEITEM] FOREIGN KEY([TransactionLineItemID])
REFERENCES [dbo].[TRANSACTION_LINEITEM] ([TransactionLineItemID])
GO

ALTER TABLE [dbo].[EXCEPTIONS] CHECK CONSTRAINT [FK_EXCEPTIONS_TRANSACTION_LINEITEM]
GO

ALTER TABLE [dbo].[EXCEPTIONS]  WITH CHECK ADD  CONSTRAINT [FK_EXCEPTIONS_OVERRIDE_CODE] FOREIGN KEY([OverrideCode])
REFERENCES [dbo].[OVERRIDE_CODE] ([OverrideCode])
GO

ALTER TABLE [dbo].[EXCEPTIONS] CHECK CONSTRAINT [FK_EXCEPTIONS_OVERRIDE_CODE]
GO

ALTER TABLE [dbo].[EXCEPTIONS]  WITH CHECK ADD  CONSTRAINT [FK_EXCEPTIONS_REFUND_CODE] FOREIGN KEY([RefundCode])
REFERENCES [dbo].[REFUND_CODE] ([RefundCode])
GO

ALTER TABLE [dbo].[EXCEPTIONS] CHECK CONSTRAINT [FK_EXCEPTIONS_REFUND_CODE]
GO

/****** Object:  Index [PK_INVENTORY]    Script Date: 1/14/2014 7:24:43 PM ******/

ALTER TABLE [dbo].[INVENTORY]  WITH CHECK ADD  CONSTRAINT [FK_INVENTORY_LOCATION] FOREIGN KEY([StoreID])
REFERENCES [dbo].[LOCATION] ([StoreID])
GO

ALTER TABLE [dbo].[INVENTORY] CHECK CONSTRAINT [FK_INVENTORY_LOCATION]
GO

ALTER TABLE [dbo].[INVENTORY]  WITH CHECK ADD  CONSTRAINT [FK_INVENTORY_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[INVENTORY] CHECK CONSTRAINT [FK_INVENTORY_ITEM]
GO

/****** Object:  Index [PK_INVOICE]    Script Date: 1/14/2014 7:26:24 PM ******/

--ALTER TABLE [dbo].[INVOICE]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_INVOICE_LINEITEM] FOREIGN KEY([InvoiceID])
--REFERENCES [dbo].[INVOICE_LINEITEM] ([InvoiceID])
--GO

--ALTER TABLE [dbo].[INVOICE] CHECK CONSTRAINT [FK_INVOICE_INVOICE_LINEITEM]
--GO

ALTER TABLE [dbo].[INVOICE]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_SHIPPING_LOG] FOREIGN KEY([ShippingID])
REFERENCES [dbo].[SHIPPING_LOG] ([ShippingID])
GO

ALTER TABLE [dbo].[INVOICE] CHECK CONSTRAINT [FK_INVOICE_SHIPPING_LOG]
GO

ALTER TABLE [dbo].[INVOICE]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_INVOICE_CUSTOMER] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[INVOICE_CUSTOMER] ([CustomerID])
GO

ALTER TABLE [dbo].[INVOICE] CHECK CONSTRAINT [FK_INVOICE_INVOICE_CUSTOMER]
GO

ALTER TABLE [dbo].[INVOICE]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_EMPLOYEE] FOREIGN KEY([InvoiceCreatedBy])
REFERENCES [dbo].[EMPLOYEE] ([EmployeeID])
GO

ALTER TABLE [dbo].[INVOICE] CHECK CONSTRAINT [FK_INVOICE_EMPLOYEE]
GO

--/****** Object:  Index [PK_INVOICE_CUSTOMER]    Script Date: 1/14/2014 7:26:24 PM ******/

--ALTER TABLE [dbo].[INVOICE_CUSTOMER]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_CUSTOMER_INVOICE] FOREIGN KEY([CustomerID])
--REFERENCES [dbo].[INVOICE] ([CustomerID])
--GO

--ALTER TABLE [dbo].[INVOICE_CUSTOMER] CHECK CONSTRAINT [FK_INVOICE_CUSTOMER_INVOICE]
--GO

/****** Object:  Index [PK_INVOICE_LINEITEM]    Script Date: 1/14/2014 7:26:24 PM ******/

ALTER TABLE [dbo].[INVOICE_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_LINEITEM_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[INVOICE_LINEITEM] CHECK CONSTRAINT [FK_INVOICE_LINEITEM_ITEM]
GO

ALTER TABLE [dbo].[INVOICE_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_INVOICE_LINEITEM_INVOICE] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[INVOICE] ([InvoiceID])
GO

ALTER TABLE [dbo].[INVOICE_LINEITEM] CHECK CONSTRAINT [FK_INVOICE_LINEITEM_INVOICE]
GO

/****** Object:  Index [PK_ITEM]    Script Date: 1/14/2014 7:30:46 PM ******/

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_CATEGORY] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ITEM_CATEGORY] ([CategoryID])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_CATEGORY]
GO

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_DEPARTMENT] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[ITEM_DEPARTMENT] ([DepartmentID])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_DEPARTMENT]
GO

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_ITEM_SUBCATEGORY] FOREIGN KEY([SubcategoryID])
REFERENCES [dbo].[ITEM_SUBCATEGORY] ([SubcategoryID])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_ITEM_SUBCATEGORY]
GO

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_PRODUCT_LINE] FOREIGN KEY([ProductLineID])
REFERENCES [dbo].[PRODUCT_LINE] ([ProductLineID])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_PRODUCT_LINE]
GO

ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_TAX_RATE] FOREIGN KEY([TaxRateID])
REFERENCES [dbo].[TAX_RATE] ([TaxRateID])
GO

ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_TAX_RATE]
GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_SALE_PRICING] FOREIGN KEY([RecRPC])
--REFERENCES [dbo].[SALE_PRICING] ([RecRPC])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_SALE_PRICING]
--GO

--ALTER TABLE [dbo].[ITEM]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_INVOICE_LINEITEM] FOREIGN KEY([RecRPC])
--REFERENCES [dbo].[INVOICE_LINEITEM] ([RecRPC])
--GO

--ALTER TABLE [dbo].[ITEM] CHECK CONSTRAINT [FK_ITEM_INVOICE_LINEITEM]
--GO

/****** Object:  Index [PK_ITEM_IMAGE]    Script Date: 1/15/2014 8:29:41 PM ******/

ALTER TABLE [dbo].[ITEM_IMAGE]  WITH CHECK ADD  CONSTRAINT [FK_ITEM_IMAGE_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[ITEM_IMAGE] CHECK CONSTRAINT [FK_ITEM_IMAGE_ITEM]
GO

/****** Object:  Index [PK_LOCATION]    Script Date: 1/15/2014 8:31:40 PM ******/

ALTER TABLE [dbo].[LOCATION]  WITH CHECK ADD  CONSTRAINT [FK_LOCATION_EMPLOYEE] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[EMPLOYEE] ([EmployeeId])
GO

ALTER TABLE [dbo].[LOCATION] CHECK CONSTRAINT [FK_LOCATION_EMPLOYEE]
GO

/****** Object:  Index [PK_MERCHANDISE_TRANSFER]    Script Date: 1/15/2014 8:31:40 PM ******/

--ALTER TABLE [dbo].[MERCHANDISE_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_MERCHANDISE_TRANSFER_INVENTORY] FOREIGN KEY([RecRPC])
--REFERENCES [dbo].[INVENTORY] ([RecRPC])
--GO

--ALTER TABLE [dbo].[MERCHANDISE_TRANSFER] CHECK CONSTRAINT [FK_MERCHANDISE_TRANSFER_INVENTORY]
--GO

ALTER TABLE [dbo].[MERCHANDISE_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_MERCHANDISE_TRANSFER_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[MERCHANDISE_TRANSFER] CHECK CONSTRAINT [FK_MERCHANDISE_TRANSFER_ITEM]
GO

ALTER TABLE [dbo].[MERCHANDISE_TRANSFER]  WITH CHECK ADD  CONSTRAINT [FK_MERCHANDISE_TRANSFER_QTY_TYPE] FOREIGN KEY([QtyTypeID])
REFERENCES [dbo].[QTY_TYPE] ([QtyTypeID])
GO

ALTER TABLE [dbo].[MERCHANDISE_TRANSFER] CHECK CONSTRAINT [FK_MERCHANDISE_TRANSFER_QTY_TYPE]
GO

/****** Object:  Index [PK_PAYMENT]    Script Date: 1/15/2014 8:34:56 PM ******/

ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENT_LOCATION] FOREIGN KEY([StoreID])
REFERENCES [dbo].[LOCATION] ([StoreID])
GO

ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_PAYMENT_LOCATION]
GO

ALTER TABLE [dbo].[PAYMENT]  WITH CHECK ADD  CONSTRAINT [FK_PAYMENT_PAYMENT_TYPE] FOREIGN KEY([PaymentTypeID])
REFERENCES [dbo].[PAYMENT_TYPE] ([PaymentTypeID])
GO

ALTER TABLE [dbo].[PAYMENT] CHECK CONSTRAINT [FK_PAYMENT_PAYMENT_TYPE]
GO

/****** Object:  Index [PK_PO_LINEITEM]    Script Date: 1/15/2014 8:36:45 PM ******/

ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_ITEM]
GO

ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_PURCHASE_ORDER] FOREIGN KEY([POID])
REFERENCES [dbo].[PURCHASE_ORDER] ([POID])
GO

ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_PURCHASE_ORDER]
GO

ALTER TABLE [dbo].[PO_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_PO_LINEITEM_QTY_TYPE] FOREIGN KEY([QtyTypeID])
REFERENCES [dbo].[QTY_TYPE] ([QtyTypeID])
GO

ALTER TABLE [dbo].[PO_LINEITEM] CHECK CONSTRAINT [FK_PO_LINEITEM_QTY_TYPE]
GO

/****** Object:  Index [PK_PRODUCT_LINE]    Script Date: 1/15/2014 8:37:41 PM ******/

ALTER TABLE [dbo].[PRODUCT_LINE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_LINE_SALES_REP] FOREIGN KEY([RepID])
REFERENCES [dbo].[SALES_REP] ([RepID])
GO

ALTER TABLE [dbo].[PRODUCT_LINE] CHECK CONSTRAINT [FK_PRODUCT_LINE_SALES_REP]
GO

ALTER TABLE [dbo].[PRODUCT_LINE]  WITH CHECK ADD  CONSTRAINT [FK_PRODUCT_LINE_VENDOR] FOREIGN KEY([VendorID])
REFERENCES [dbo].[VENDOR] ([VendorID])
GO

ALTER TABLE [dbo].[PRODUCT_LINE] CHECK CONSTRAINT [FK_PRODUCT_LINE_VENDOR]
GO

/****** Object:  Index [PK_PURCHASE_ORDER]    Script Date: 1/15/2014 8:38:27 PM ******/

ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_EMPLOYEE] FOREIGN KEY([POCreatedBy])
REFERENCES [dbo].[EMPLOYEE] ([EmployeeId])
GO

ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_EMPLOYEE]
GO

--ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_SHIPPING_LOG] FOREIGN KEY([ShippingID])
--REFERENCES [dbo].[SHIPPING_LOG] ([ShippingID])
--GO

--ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_SHIPPING_LOG]
--GO

ALTER TABLE [dbo].[PURCHASE_ORDER]  WITH CHECK ADD  CONSTRAINT [FK_PURCHASE_ORDER_VENDOR] FOREIGN KEY([VendorID])
REFERENCES [dbo].[VENDOR] ([VendorID])
GO

ALTER TABLE [dbo].[PURCHASE_ORDER] CHECK CONSTRAINT [FK_PURCHASE_ORDER_VENDOR]
GO

/****** Object:  Index [PK_RECEIVING_LOG]    Script Date: 1/15/2014 8:39:55 PM ******/

--ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_BACKORDER] FOREIGN KEY([BackorderID])
--REFERENCES [dbo].[BACKORDER] ([BackorderID])
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_BACKORDER]
--GO

ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_PO_LINEITEM] FOREIGN KEY([POLineItemID])
REFERENCES [dbo].[PO_LINEITEM] ([POLineItemID])
GO

ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_PO_LINEITEM]
GO

--ALTER TABLE [dbo].[RECEIVING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_RECEIVING_LOG_QTY_TYPE] FOREIGN KEY([QtyTypeID])
--REFERENCES [dbo].[QTY_TYPE] ([QtyTypeID])
--GO

--ALTER TABLE [dbo].[RECEIVING_LOG] CHECK CONSTRAINT [FK_RECEIVING_LOG_QTY_TYPE]
--GO

/****** Object:  Index [PK_SALE_PRICING]    Script Date: 1/15/2014 8:41:25 PM ******/

ALTER TABLE [dbo].[SALE_PRICING]  WITH CHECK ADD  CONSTRAINT [FK_SALE_PRICING_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[SALE_PRICING] CHECK CONSTRAINT [FK_SALE_PRICING_ITEM]
GO

ALTER TABLE [dbo].[SALE_PRICING]  WITH CHECK ADD  CONSTRAINT [FK_SALE_PRICING_EVENT_TYPE] FOREIGN KEY([EventTypeCode])
REFERENCES [dbo].[EVENT_TYPE] ([EventTypeCode])
GO

ALTER TABLE [dbo].[SALE_PRICING] CHECK CONSTRAINT [FK_SALE_PRICING_EVENT_TYPE]
GO

/****** Object:  Index [PK_SHIPPING_LOG]    Script Date: 1/15/2014 8:42:53 PM ******/

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_BACKORDER] FOREIGN KEY([BackorderID])
--REFERENCES [dbo].[BACKORDER] ([BackorderID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_BACKORDER]
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_INVOICE] FOREIGN KEY([ID])
--REFERENCES [dbo].[INVOICE] ([InvoiceID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_INVOICE]
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG]  WITH CHECK ADD  CONSTRAINT [FK_SHIPPING_LOG_PURCHASE_ORDER] FOREIGN KEY([ID])
--REFERENCES [dbo].[PURCHASE_ORDER] ([POID])
--GO

--ALTER TABLE [dbo].[SHIPPING_LOG] CHECK CONSTRAINT [FK_SHIPPING_LOG_PURCHASE_ORDER]
--GO

/****** Object:  Index [PK_STORE_TRANSACTION]    Script Date: 1/15/2014 8:41:25 PM ******/

ALTER TABLE [dbo].[STORE_TRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_STORE_TRANSACTION_LOCATION] FOREIGN KEY([StoreID])
REFERENCES [dbo].[LOCATION] ([StoreID])
GO

ALTER TABLE [dbo].[STORE_TRANSACTION] CHECK CONSTRAINT [FK_STORE_TRANSACTION_LOCATION]
GO

ALTER TABLE [dbo].[STORE_TRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_STORE_TRANSACTION_EMPLOYEE] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[EMPLOYEE] ([EmployeeID])
GO

ALTER TABLE [dbo].[STORE_TRANSACTION] CHECK CONSTRAINT [FK_STORE_TRANSACTION_EMPLOYEE]
GO

ALTER TABLE [dbo].[STORE_TRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_STORE_TRANSACTION_PAYMENT] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[PAYMENT] ([PaymentID])
GO

ALTER TABLE [dbo].[STORE_TRANSACTION] CHECK CONSTRAINT [FK_STORE_TRANSACTION_PAYMENT]
GO

/****** Object:  Index [PK_TRANSACTION_LINE_ITEM]    Script Date: 1/17/2014 7:22:31 PM ******/

ALTER TABLE [dbo].[TRANSACTION_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_TRANSACTION_LINEITEM_STORE_TRANSACTION] FOREIGN KEY([TransactionID], [StoreID])
REFERENCES [dbo].[STORE_TRANSACTION] ([TransactionID], [StoreID])
GO

ALTER TABLE [dbo].[TRANSACTION_LINEITEM] CHECK CONSTRAINT [FK_TRANSACTION_LINEITEM_STORE_TRANSACTION]
GO

ALTER TABLE [dbo].[TRANSACTION_LINEITEM]  WITH CHECK ADD  CONSTRAINT [FK_TRANSACTION_LINEITEM_ITEM] FOREIGN KEY([RecRPC])
REFERENCES [dbo].[ITEM] ([RecRPC])
GO

ALTER TABLE [dbo].[TRANSACTION_LINEITEM] CHECK CONSTRAINT [FK_TRANSACTION_LINEITEM_ITEM]
GO

-- *********************************************************************
USE Master
GO