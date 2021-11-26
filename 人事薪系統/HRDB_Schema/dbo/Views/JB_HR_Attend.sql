CREATE VIEW [dbo].[JB_HR_Attend]
AS
SELECT     RTRIM(NOBR) AS sNobr, ADATE AS dAdate, RTRIM(ROTE) AS sRoteCode, LATE_MINS AS iLateMins, E_MINS AS iEMins, ABS AS bAbs, 
                      FORGET AS iForget
FROM         dbo.ATTEND
