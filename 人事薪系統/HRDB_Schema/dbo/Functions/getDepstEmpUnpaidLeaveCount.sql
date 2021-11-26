-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDepstEmpUnpaidLeaveCount] (@depts nvarchar(50), @adate datetime,@ddate datetime)
RETURNS int
AS
BEGIN
	 
	 
	 declare @value int;
	 select  @value = count(nobr) from basetts
	 where getdate() between adate and ddate and STDT between @adate and @ddate  and depts =@depts  AND EMPCD='01' 


	-- Return the result of the function
	RETURN @value

END