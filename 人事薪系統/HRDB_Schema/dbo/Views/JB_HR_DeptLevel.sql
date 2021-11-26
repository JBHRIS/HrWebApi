CREATE VIEW [dbo].[JB_HR_DeptLevel]
AS
SELECT     ID AS sDeptLevelCode, RTRIM(NAME) AS sName, SORTING AS iSorting
FROM         dbo.DEPTLEVEL
