/****** Object:  View [dbo].[View_MealApplyRecord]    Script Date: 2021/4/26 上午 09:03:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_MealApplyRecord]
AS
SELECT  MAR.NOBR AS 員工編號, B.NAME_C AS 員工姓名, MAR.ADATE AS 報餐日期, MT.MEALTYPE_CODE AS 用餐種類代碼, 
               MT.MEALTYPE_NAME AS 用餐種類名稱, MT.BTIME AS 起始時間, MT.ETIME AS 結束時間, MG.MealGroup_DISP AS 用餐群組代碼, 
               MG.MealGroup_Name AS 用餐群組名稱, D.D_NO_DISP AS 部門代碼, D.D_NAME AS 部門名稱, MAR.NOTE AS 備註, MAR.SeroNO AS 序號, 
               MAR.KEY_MAN AS 登錄者, MAR.KEY_DATE AS 登錄日期, MAR.AutoKey
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


