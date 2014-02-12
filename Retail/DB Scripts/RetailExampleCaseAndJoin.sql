--select * from sale_pricing


SELECT
	--*
	I.RecRPC,
	--I.SellPrice,
	--sp.SalePrice,
	CASE WHEN SP.SalePrice IS NULL THEN I.SellPrice ELSE SP.SalePrice END [Price]
FROM
	item I
	LEFT JOIN sale_pricing sp on i.recrpc = sp.RecRPC