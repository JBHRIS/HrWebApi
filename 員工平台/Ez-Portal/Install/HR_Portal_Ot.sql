USE [IODATAHR]
GO
/****** 物件:  View [dbo].[HR_Portal_Ot]    指令碼日期: 04/21/2010 15:12:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HR_Portal_Ot]
AS
SELECT     dbo.BASETTS.NOBR, dbo.BASE.NAME_C, dbo.JOB.JOB_NAME, dbo.DEPT.D_NAME, dbo.OT.BDATE, dbo.OT.BTIME, dbo.OT.ETIME, dbo.OT.TOT_HOURS, 
                      dbo.OT.OT_HRS, dbo.OT.REST_HRS, dbo.OTRCD.OTRNAME, dbo.OT.NOTE, dbo.OT.YYMM
FROM         dbo.BASE INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.OT ON dbo.BASE.NOBR = dbo.OT.NOBR LEFT OUTER JOIN
                      dbo.OTRCD ON dbo.OT.OTRCD = dbo.OTRCD.OTRCD LEFT OUTER JOIN
                      dbo.JOB ON dbo.BASETTS.JOB = dbo.JOB.JOB LEFT OUTER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO
WHERE     (CONVERT(char(10), dbo.OT.BDATE, 111) BETWEEN CONVERT(char(10), dbo.BASETTS.ADATE, 111) AND CONVERT(char(10), dbo.BASETTS.DDATE, 111))


