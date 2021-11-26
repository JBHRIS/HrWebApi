CREATE VIEW [dbo].[JB_HR_Depts]
AS
SELECT     RTRIM(D_NO) AS sDeptCode, RTRIM(D_NAME) AS sDeptName, ADATE AS dAdate, DDATE AS dDdate
FROM         dbo.DEPTS
