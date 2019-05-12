CREATE PROCEDURE usp_InsertInvoice
(
	@CustomerId int,
	@InvoiceDate datetime, 
	@BillingAddress nvarchar(70),
	@BillingCity nvarchar(40),
	@BillingState nvarchar(40),
	@BillingCountry nvarchar(40),
	@BillingPostalCode nvarchar(10),
	@Total numeric(10,2) 
)
AS
BEGIN
	INSERT INTO Invoice( 
		CustomerId, 
		InvoiceDate, 
		BillingAddress, 
		BillingCity, 
		BillingState, 
		BillingCountry, 
		BillingPostalCode, 
		Total
	)
	VALUES (@CustomerId, 
		@InvoiceDate, 
		@BillingAddress, 
		@BillingCity, 
		@BillingState, 
		@BillingCountry, 
		@BillingPostalCode, 
		@Total
	)

	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE usp_InsertInvoiceLine
(
	@InvoiceId int, 
	@TrackId int, 
	@UnitPrice numeric(10,2), 
	@Quantity int
)
AS
BEGIN
	INSERT INTO InvoiceLine(
		InvoiceId, 
		TrackId, 
		UnitPrice, 
		Quantity
	)
	VALUES(
		@InvoiceId, 
		@TrackId, 
		@UnitPrice, 
		@Quantity
	)

END
GO

