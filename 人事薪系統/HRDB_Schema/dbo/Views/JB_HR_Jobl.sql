CREATE VIEW [dbo].[JB_HR_Jobl]
AS
SELECT     RTRIM(JOBL) AS sJobCode, RTRIM(JOB_NAME) AS sJobName
FROM         dbo.JOBL
