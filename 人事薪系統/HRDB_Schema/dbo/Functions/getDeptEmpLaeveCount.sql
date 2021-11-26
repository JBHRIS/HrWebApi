-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDeptEmpLaeveCount] (@dept nvarchar(50), @adate datetime,@ddate datetime)
RETURNS int
AS
BEGIN
	 
	 
	 declare @value int;
	 select  @value = count(nobr) from basetts
	 where getdate() between adate and ddate AND TTSCODE ='2'AND EMPCD='01' and oudt between @adate and @ddate  and dept =@dept


	-- Return the result of the function
	RETURN @value

END