USE [IODATAHR]
GO
/****** 物件:  View [dbo].[HR_Portal_Attend]    指令碼日期: 04/21/2010 15:11:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[HR_Portal_Attend]
AS
SELECT     dbo.BASE.NOBR, dbo.BASE.NAME_C, dbo.ATTEND.ADATE, dbo.ATTEND.ROTE, dbo.ROTE.ROTENAME, dbo.BASETTS.DEPT, dbo.BASETTS.JOB, 
                      dbo.JOB.JOB_NAME, dbo.DEPT.D_NAME
FROM         dbo.BASE INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.ATTEND ON dbo.BASETTS.NOBR = dbo.ATTEND.NOBR LEFT OUTER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO LEFT OUTER JOIN
                      dbo.JOB ON dbo.BASETTS.JOB = dbo.JOB.JOB LEFT OUTER JOIN
                      dbo.ROTE ON dbo.ATTEND.ROTE = dbo.ROTE.ROTE
WHERE     (CONVERT(char(10), GETDATE(), 111) BETWEEN CONVERT(char(10), dbo.BASETTS.ADATE, 111) AND CONVERT(char(10), dbo.BASETTS.DDATE, 111))

