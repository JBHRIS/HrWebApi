-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDeptEmpInCompCount](@dept nvarchar(50),@adate datetime,@ddate datetime)
RETURNS int
AS
BEGIN
	declare @value int;
	 select  @value = count(nobr) from basetts
	 where getdate() between adate and ddate and INDT between @adate and @ddate  and dept =@dept  AND EMPCD='01' 


	-- Return the result of the function
	RETURN @value

END