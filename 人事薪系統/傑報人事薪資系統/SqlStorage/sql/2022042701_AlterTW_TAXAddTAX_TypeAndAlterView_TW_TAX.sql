Alter Table TW_TAX
ADD TAX_Type nvarchar(50)
GO

update TW_TAX
set TAX_Type = 'Med'
GO

ALTER VIEW [dbo].[VIEW_TW_TAX]
AS
SELECT  AUTO AS �s��, SUBJECT AS ���D, YEARMONTH AS �~��, DATEBEGIN AS �_�l���, DATEEND AS �������, REMARK AS �Ƶ�, KEY_DATE AS �n�����, 
               KEY_MAN AS �n����, ISLOCK AS ����, RELASEDATE AS �ҥάd�ߤ��, TAX_Type AS �@�~����
FROM     dbo.TW_TAX
GO