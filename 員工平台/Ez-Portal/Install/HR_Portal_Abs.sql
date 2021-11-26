USE [IODATAHR]
GO
/****** 物件:  View [dbo].[HR_Portal_Abs]    指令碼日期: 04/21/2010 15:11:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HR_Portal_Abs]
AS
SELECT     dbo.BASETTS.NOBR, dbo.BASE.NAME_C, dbo.ABS.BDATE, dbo.ABS.BTIME, dbo.ABS.ETIME, dbo.ABS.H_CODE, dbo.HCODE.H_NAME, dbo.HCODE.UNIT, 
                      dbo.ABS.TOL_HOURS, dbo.ABS.YYMM, dbo.ABS.NOTE, dbo.ABS.TOL_DAY, dbo.HCODE.YEAR_REST, dbo.DEPT.D_NAME, dbo.JOB.JOB_NAME
FROM         dbo.ABS INNER JOIN
                      dbo.BASE ON dbo.ABS.NOBR = dbo.BASE.NOBR INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.HCODE ON dbo.ABS.H_CODE = dbo.HCODE.H_CODE LEFT OUTER JOIN
                      dbo.JOB ON dbo.BASETTS.JOB = dbo.JOB.JOB LEFT OUTER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO
WHERE     (CONVERT(char(10), dbo.ABS.BDATE, 111) BETWEEN CONVERT(char(10), dbo.BASETTS.ADATE, 111) AND CONVERT(char(10), dbo.BASETTS.DDATE, 111)) AND 
                      (dbo.HCODE.YEAR_REST NOT IN ('1', '3', '5'))


