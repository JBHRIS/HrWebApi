/****** Object:  View [dbo].[View_MealDeduction]    Script Date: 2021/3/12 上午 10:08:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_MealDeduction]
AS
SELECT  TOP (100) PERCENT MD.NOBR AS 員工編號, B.NAME_C AS 員工姓名, MD.ADATE AS 用餐日期, MT.MEALTYPE_CODE AS 用餐種類代碼, 
               MT.MEALTYPE_NAME AS 用餐種類名稱, MT.BTIME AS 起始時間, MT.ETIME AS 結束時間, MD.YYMM AS 計薪年月, MD.AMT AS 扣款金額, 
               CASE MD.Apply WHEN 1 THEN '有' ELSE '無' END AS 報餐, CASE MD.Attend WHEN 1 THEN '有' ELSE '無' END AS 出勤, 
               CASE MD.OT WHEN 1 THEN '有' ELSE '無' END AS 加班, CASE MD.Eat WHEN 1 THEN '有' ELSE '無' END AS 用餐, MG.MealGroup_DISP AS 用餐群組代碼, 
               MG.MealGroup_Name AS 用餐群組名稱, D.D_NO_DISP AS 部門代碼, D.D_NAME AS 部門名稱, MD.NOTE AS 備註, MD.SERO AS 序號, 
               MD.KEY_MAN AS 登錄者, MD.KEY_DATE AS 登錄日期, MD.AutoKey
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


