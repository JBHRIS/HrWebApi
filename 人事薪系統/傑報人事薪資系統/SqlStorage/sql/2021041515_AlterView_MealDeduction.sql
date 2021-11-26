/****** Object:  View [dbo].[View_MealDeduction]    Script Date: 2021/3/12 �W�� 10:08:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_MealDeduction]
AS
SELECT  TOP (100) PERCENT MD.NOBR AS ���u�s��, B.NAME_C AS ���u�m�W, MD.ADATE AS ���\���, MT.MEALTYPE_CODE AS ���\�����N�X, 
               MT.MEALTYPE_NAME AS ���\�����W��, MT.BTIME AS �_�l�ɶ�, MT.ETIME AS �����ɶ�, MD.YYMM AS �p�~�~��, MD.AMT AS ���ڪ��B, 
               CASE MD.Apply WHEN 1 THEN '��' ELSE '�L' END AS ���\, CASE MD.Attend WHEN 1 THEN '��' ELSE '�L' END AS �X��, 
               CASE MD.OT WHEN 1 THEN '��' ELSE '�L' END AS �[�Z, CASE MD.Eat WHEN 1 THEN '��' ELSE '�L' END AS ���\, MG.MealGroup_DISP AS ���\�s�եN�X, 
               MG.MealGroup_Name AS ���\�s�զW��, D.D_NO_DISP AS �����N�X, D.D_NAME AS �����W��, MD.NOTE AS �Ƶ�, MD.SERO AS �Ǹ�, 
               MD.KEY_MAN AS �n����, MD.KEY_DATE AS �n�����, MD.AutoKey
FROM     dbo.MealDeduction AS MD INNER JOIN
               dbo.BASE AS B ON MD.NOBR = B.NOBR INNER JOIN
               dbo.BASETTS AS BT ON MD.NOBR = BT.NOBR INNER JOIN
               dbo.MealType AS MT ON MD.MealType = MT.MEALTYPE_CODE AND MD.MealGroup = MT.MEALGROUP INNER JOIN
               dbo.DEPT AS D ON BT.DEPT = D.D_NO LEFT OUTER JOIN
                   (SELECT  UDF.CODE, UDF.VALUE
                   FROM     dbo.USERDEFINEVALUE AS UDF INNER JOIN
                                  dbo.USERDEFINESOURCE AS UDS ON UDF.SOURCEID = UDS.SOURCEID
                   WHERE   (UDS.SOURCENAME = 'MealGroup')) AS UD ON UD.CODE = MD.NOBR LEFT OUTER JOIN
               dbo.MealGroup AS MG ON UD.VALUE = MG.MealGroup_Code
WHERE   (BT.ADATE <= GETDATE()) AND (BT.DDATE >= GETDATE())
GO


