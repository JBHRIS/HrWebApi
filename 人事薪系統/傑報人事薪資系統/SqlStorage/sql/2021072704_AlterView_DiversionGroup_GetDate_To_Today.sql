/****** Object:  View [dbo].[View_DiversionGroup]    Script Date: 2021/7/27 �U�� 05:27:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[View_DiversionGroup]
AS
SELECT      dg.EmployeeId AS ���u�s��, b.NAME_C AS ���u�m�W, dg.BeginDate AS �ͮĤ��, dg.EndDate AS ���Ĥ��, mt.NAME AS ���y�Z�O�W��, 
                   wk.WORK_ADDR AS �u�@�a, d.D_NO_DISP AS �����N�X, d.D_NAME AS �����W��, bs.SALADR AS ��Ƹs��, dg.KeyDate AS �n�����, 
                   dg.KeyMan AS �n����, dg.AutoKey AS AK, dg.Guid AS �s��
FROM         dbo.DiversionGroup AS dg INNER JOIN
                   dbo.BASE AS b ON dg.EmployeeId = b.NOBR INNER JOIN
                   dbo.BASETTS AS bs ON b.NOBR = bs.NOBR AND CONVERT(nvarchar(50), GETDATE(), 111) BETWEEN bs.ADATE AND bs.DDATE INNER JOIN
                   dbo.DEPT AS d ON bs.DEPT = d.D_NO INNER JOIN
                   dbo.MTCODE AS mt ON dg.DiversionGroupType = mt.CODE AND mt.CATEGORY = 'DiversionGroupType' LEFT OUTER JOIN
                   dbo.WORKCD AS wk ON dg.WorkLocation = wk.WORK_CODE
GO


