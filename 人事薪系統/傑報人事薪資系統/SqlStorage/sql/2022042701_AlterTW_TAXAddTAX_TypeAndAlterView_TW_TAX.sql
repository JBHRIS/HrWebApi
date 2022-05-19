Alter Table TW_TAX
ADD TAX_Type nvarchar(50)
GO

update TW_TAX
set TAX_Type = 'Med'
GO

ALTER VIEW [dbo].[VIEW_TW_TAX]
AS
SELECT  AUTO AS 編號, SUBJECT AS 標題, YEARMONTH AS 年月, DATEBEGIN AS 起始日期, DATEEND AS 結束日期, REMARK AS 備註, KEY_DATE AS 登錄日期, 
               KEY_MAN AS 登錄者, ISLOCK AS 鎖檔, RELASEDATE AS 啟用查詢日期, TAX_Type AS 作業種類
FROM     dbo.TW_TAX
GO