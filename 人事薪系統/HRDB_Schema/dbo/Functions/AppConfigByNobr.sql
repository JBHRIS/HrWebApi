
-- =============================================
-- Author:		<Stanley>
-- Create date: <2013/05/01>
-- Description:	<讀取指定工號所屬的相關設定, ,>
-- =============================================
CREATE FUNCTION [dbo].[AppConfigByNobr](@Nobr nvarchar(50),@Category nvarchar(50),@Parameter nvarchar,@DefaultValue nvarchar(50))
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @COMP NVARCHAR(50)
	SELECT @COMP=dbo.GetCompGroupByNobr(@Nobr,getdate())
	DECLARE @VALUE NVARCHAR(50)
	SELECT @VALUE=Value FROM AppConfig WHERE Category=@Category and Code=@Parameter and Comp=@COMP
	IF(@VALUE IS NULL) SET @VALUE=@DefaultValue
	return @VALUE
END

