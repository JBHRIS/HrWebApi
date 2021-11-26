/****** Object:  View [dbo].[View_MealApplyRecord]    Script Date: 2021/4/26 �W�� 09:03:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_MealApplyRecord]
AS
SELECT  MAR.NOBR AS ���u�s��, B.NAME_C AS ���u�m�W, MAR.ADATE AS ���\���, MT.MEALTYPE_CODE AS ���\�����N�X, 
               MT.MEALTYPE_NAME AS ���\�����W��, MT.BTIME AS �_�l�ɶ�, MT.ETIME AS �����ɶ�, MG.MealGroup_DISP AS ���\�s�եN�X, 
               MG.MealGroup_Name AS ���\�s�զW��, D.D_NO_DISP AS �����N�X, D.D_NAME AS �����W��, MAR.NOTE AS �Ƶ�, MAR.SeroNO AS �Ǹ�, 
               MAR.KEY_MAN AS �n����, MAR.KEY_DATE AS �n�����, MAR.AutoKey
FROM     dbo.MealApplyRecord AS MAR INNER JOIN
               dbo.BASE AS B ON MAR.NOBR = B.NOBR INNER JOIN
               dbo.BASETTS AS BT ON MAR.NOBR = BT.NOBR INNER JOIN
               dbo.MealType AS MT ON MAR.MealType = MT.MEALTYPE_CODE AND MAR.MealGroup = MT.MEALGROUP INNER JOIN
               dbo.DEPT AS D ON BT.DEPT = D.D_NO LEFT OUTER JOIN
                   (SELECT  UDF.CODE, UDF.VALUE
                   FROM     dbo.USERDEFINEVALUE AS UDF INNER JOIN
                                  dbo.USERDEFINESOURCE AS UDS ON UDF.SOURCEID = UDS.SOURCEID
                   WHERE   (UDS.SOURCENAME = 'MealGroup')) AS UD ON UD.CODE = MAR.NOBR LEFT OUTER JOIN
               dbo.MealGroup AS MG ON UD.VALUE = MG.MealGroup_Code
WHERE   (BT.ADATE <= GETDATE()) AND (BT.DDATE >= GETDATE())
GO


