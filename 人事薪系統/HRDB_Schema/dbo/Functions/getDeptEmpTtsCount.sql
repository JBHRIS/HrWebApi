-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[getDeptEmpTtsCount](@dept nvarchar(50),@adate datetime,@ddate datetime,@ttsdate datetime)
RETURNS int
AS
BEGIN
	declare @value int;
	
	 SELECT    @value = count(BASETTS.NOBR) 
FROM             BASETTS INNER JOIN
                          BASE ON BASETTS.NOBR = BASE.NOBR
WHERE         (BASE.NOBR IN
                              (SELECT         NOBR
                                FROM              BASETTS AS BASETTS_1
                                WHERE          (TTSCODE IN ('1', '4', '6')) AND (ADATE <= @ddate) AND 
                                                           (DDATE >= @adate) AND (DEPT = @dept)
                                GROUP BY   NOBR)) AND TTSCODE NOT IN('1','4','5','2','3') AND @ttsdate BETWEEN BASETTS.ADATE AND BASETTS.DDATE AND (BASETTS.DEPT <> @dept)   AND EMPCD='01' 

	-- Return the result of the function
	RETURN @value

END