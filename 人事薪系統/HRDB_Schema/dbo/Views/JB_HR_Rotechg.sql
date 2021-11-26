CREATE VIEW [dbo].[JB_HR_Rotechg]
AS
SELECT     ADATE AS dAdate, RTRIM(NOBR) AS sNobr, RTRIM(ROTE) AS sRoteCode
FROM         dbo.ROTECHG
