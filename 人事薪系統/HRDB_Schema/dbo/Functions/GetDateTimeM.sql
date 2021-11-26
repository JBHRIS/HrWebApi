
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[GetDateTimeM](@time nvarchar(50))

RETURNS  int
AS
BEGIN
	declare @d1 int
	set @d1=left(@time,2)*60 +right(@time,2)
	return @d1

END