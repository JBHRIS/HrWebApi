-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE[dbo].[UpateAttendLATE_MINS](@nobr nvarchar(50),@date datetime)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
DECLARE @needAbs decimal, @ALLLATES1 decimal , @absHrs decimal

SET @needAbs =0
  SELECT @needAbs = LH   from  [HPX_ATTENDANCE_CHECK](@nobr,CONVERT(DATETIME,@date,111))

SET @ALLLATES1 = 0
SELECT     @ALLLATES1 =     ROTE.ALLLATES1 
FROM              ATTEND LEFT OUTER JOIN
                            ROTE ON ATTEND.ROTE = ROTE.ROTE
WHERE          (ATTEND.NOBR =@nobr) AND (ATTEND.ADATE = @date)

SET @absHrs = 0
select @absHrs = isNull( SUM(TOL_HOURS),0 ) from  dbo.GetAllAbsByNobr(@nobr, @date, @date)

if(@ALLLATES1 >0  and (@needAbs - @absHrs) <= 0 )
 update [dbo].[ATTEND] set LATE_MINS=0,E_MINS=0 
 WHERE          (ADATE =@date ) AND (ROTE IN
                                (SELECT          ROTE
                                FROM               ROTE
                                  WHERE           (ALLLATES1 > 0)))  AND ( (LATE_MINS > 0) OR (E_MINS > 0))  and nobr =@nobr
								  
END