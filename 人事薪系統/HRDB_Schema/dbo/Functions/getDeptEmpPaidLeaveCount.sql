-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDeptEmpPaidLeaveCount](@dept nvarchar(50),@adate datetime,@ddate datetime)
RETURNS int
AS
BEGIN
	declare @value int;
	 select  @value = count(nobr) from basetts
	  where getdate() between adate and ddate and STINDT between @adate and @ddate  and dept =@dept  AND EMPCD='01' 


	-- Return the result of the function
	RETURN @value

END