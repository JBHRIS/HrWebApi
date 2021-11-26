/****** Object:  View [dbo].[FRM47]    Script Date: 2021/6/25 ¤W¤È 10:26:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[FRM47]
AS
SELECT  dbo.OT.NOBR, dbo.OT.BDATE, dbo.OT.BTIME, dbo.OT.ETIME, dbo.OT.TOT_HOURS, dbo.OT.OT_HRS, dbo.OT.REST_HRS, dbo.OT.OT_CAR, 
               dbo.OT.OT_DEPT, dbo.OT.KEY_MAN, dbo.OT.KEY_DATE, dbo.OT.OT_FOOD, dbo.OT.NOTE, dbo.OT.YYMM, dbo.OT.NOT_W_133, dbo.OT.NOT_W_167, 
               dbo.OT.NOT_W_200, dbo.OT.NOT_H_200, dbo.OT.TOT_W_133, dbo.OT.TOT_W_167, dbo.OT.TOT_W_200, dbo.OT.NOT_EXP, dbo.OT.TOT_EXP, 
               dbo.OT.SALARY, dbo.OT.NOTMODI, dbo.OT.OTRCD, dbo.OT.NOFOOD, dbo.OT.OT_ROTE, dbo.OT.OT_FOOD1, dbo.OT.NOP_H_200, dbo.OT.TOP_W_133, 
               dbo.OT.TOP_W_167, dbo.OT.TOP_W_200, dbo.OT.TOP_H_200, dbo.OT.NOT_H_133, dbo.OT.NOT_H_167, dbo.OT.HOT_133, dbo.OT.HOT_166, 
               dbo.OT.HOT_200, dbo.OT.WOT_133, dbo.OT.WOT_166, dbo.OT.WOT_200, dbo.OT.SUM, dbo.OT.SYSCREAT, dbo.OT.OTRATE_CODE, dbo.OT.NOT_W_100, 
               dbo.OT.TOP_W_100, dbo.OT.SYSCREAT1, dbo.OT.NOP_W_100, dbo.OT.SYS_OT, dbo.OT.SERNO, dbo.OT.DIFF, dbo.OT.EAT, dbo.OT.RES, dbo.OT.NOFOOD1, 
               dbo.BASE.NAME_C, ISNULL(dbo.JOBS.JOB_NAME, N'') AS JOB_NAME, dbo.DEPTS.D_NAME AS DEPTS_NAME, dbo.DEPT.D_NAME AS DEPT_NAME, 
               dbo.BASETTS.DEPT, dbo.OT.SYS_OT | dbo.OTRCD.SYS_OT | CASE attend.rote WHEN '00' THEN 1 ELSE 0 END AS isHoli, dbo.BASE.COUNT_MA, 
               dbo.OT.OT_FOODH, dbo.OT.OT_FOODH1, dbo.ATTEND.ROTE AS ATT_ROTE, dbo.HOLI_TYPE(dbo.OT.OTRCD, dbo.OT.SYS_OT, dbo.OTRCD.SYS_OT, 
               dbo.ATTEND.ROTE) AS HOLI_TYPE, dbo.OT_TYPE(dbo.OT.OT_HRS, dbo.OT.REST_HRS) AS OT_TYPE
FROM     dbo.OT INNER JOIN
               dbo.BASE ON dbo.OT.NOBR = dbo.BASE.NOBR INNER JOIN
               dbo.BASETTS ON dbo.OT.NOBR = dbo.BASETTS.NOBR AND dbo.OT.BDATE BETWEEN dbo.BASETTS.ADATE AND 
               dbo.BASETTS.DDATE LEFT OUTER JOIN
               dbo.OTRCD ON dbo.OT.OTRCD = dbo.OTRCD.OTRCD LEFT OUTER JOIN
               dbo.JOBS ON dbo.BASETTS.JOBS = dbo.JOBS.JOBS LEFT OUTER JOIN
               dbo.ATTEND ON dbo.OT.NOBR = dbo.ATTEND.NOBR AND dbo.OT.BDATE = dbo.ATTEND.ADATE LEFT OUTER JOIN
               dbo.DEPTS ON dbo.OT.OT_DEPT = dbo.DEPTS.D_NO LEFT OUTER JOIN
               dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO
GO


