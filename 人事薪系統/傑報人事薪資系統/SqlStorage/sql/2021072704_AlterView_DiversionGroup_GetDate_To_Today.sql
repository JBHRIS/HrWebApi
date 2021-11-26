/****** Object:  View [dbo].[View_DiversionGroup]    Script Date: 2021/7/27 下午 05:27:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_DiversionGroup]
AS
SELECT      dg.EmployeeId AS 員工編號, b.NAME_C AS 員工姓名, dg.BeginDate AS 生效日期, dg.EndDate AS 失效日期, mt.NAME AS 分流班別名稱, 
                   wk.WORK_ADDR AS 工作地, d.D_NO_DISP AS 部門代碼, d.D_NAME AS 部門名稱, bs.SALADR AS 資料群組, dg.KeyDate AS 登錄日期, 
                   dg.KeyMan AS 登錄者, dg.AutoKey AS AK, dg.Guid AS 編號
FROM         dbo.DiversionGroup AS dg INNER JOIN
                   dbo.BASE AS b ON dg.EmployeeId = b.NOBR INNER JOIN
                   dbo.BASETTS AS bs ON b.NOBR = bs.NOBR AND CONVERT(nvarchar(50), GETDATE(), 111) BETWEEN bs.ADATE AND bs.DDATE INNER JOIN
                   dbo.DEPT AS d ON bs.DEPT = d.D_NO INNER JOIN
                   dbo.MTCODE AS mt ON dg.DiversionGroupType = mt.CODE AND mt.CATEGORY = 'DiversionGroupType' LEFT OUTER JOIN
                   dbo.WORKCD AS wk ON dg.WorkLocation = wk.WORK_CODE
GO


