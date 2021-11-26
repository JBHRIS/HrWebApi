CREATE VIEW [dbo].[JB_HR_TtsCode]
AS
SELECT     RTRIM(CODE) AS sTtsCode, RTRIM(NAME) AS sTtsName
FROM         dbo.TTSCODE
