
-- =============================================
-- Author:		<Stanley>
-- Create date: <2013/05/31>
-- Description:	<判斷員工所屬的公司資料群組, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetCompGroupByNobr](@Nobr nvarchar(50) ,@date Datetime) 
RETURNS nvarchar(50)
AS
BEGIN
	declare @saladr nvarchar(50)
	select top 1  @saladr=SALADR from BASETTS where nobr=@nobr and @date<=DDATE order by ADATE
	declare @comp nvarchar(50)
	select @comp=COMP from DATAGROUP where DATAGROUP=@saladr
	return @comp
END

