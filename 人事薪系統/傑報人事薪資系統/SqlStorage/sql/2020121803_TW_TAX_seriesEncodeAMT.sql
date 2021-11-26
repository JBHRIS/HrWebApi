IF EXISTS (SELECT 1 FROM TW_TAX_ITEM WHERE AMT = 0.00 or D_AMT = 0.00 or RET_AMT = 0.00 or SUP_AMT = 0.00)
BEGIN
    update TW_TAX_ITEM
	set AMT = dbo.Encode(AMT), D_AMT = dbo.Encode(D_AMT), RET_AMT = dbo.Encode(RET_AMT), SUP_AMT = dbo.Encode(SUP_AMT)
END
GO

IF EXISTS (SELECT 1 FROM TW_TAX_SUMMARY WHERE AMT = 0.00 or D_AMT = 0.00 or RET_AMT = 0.00 or SUP_AMT = 0.00)
BEGIN
    update TW_TAX_SUMMARY
	set AMT = dbo.Encode(AMT), D_AMT = dbo.Encode(D_AMT), RET_AMT = dbo.Encode(RET_AMT), SUP_AMT = dbo.Encode(SUP_AMT)
END
GO