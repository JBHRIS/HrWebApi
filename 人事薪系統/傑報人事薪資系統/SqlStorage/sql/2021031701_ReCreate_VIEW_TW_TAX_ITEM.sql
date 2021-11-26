DROP VIEW [dbo].[VIEW_TW_TAX_ITEM]
GO

/****** Object:  View [dbo].[VIEW_TW_TAX_ITEM]    Script Date: 2021/3/17 �W�� 10:50:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_TW_TAX_ITEM]
AS
SELECT  dbo.TW_TAX_ITEM.AUTO AS �s��, dbo.TW_TAX_ITEM.PID,  dbo.TW_TAX_ITEM.COMP AS ���q, 
               dbo.COMP.COMPNAME AS ���q�W��, dbo.TW_TAX_ITEM.NOBR AS ���u�s��, dbo.TBASE.NAME_C AS ���u�m�W, dbo.TW_TAX_ITEM.YYMM AS �ұo�~��, dbo.TW_TAX_ITEM.SEQ AS ���O, 
               dbo.TW_TAX_ITEM.SAL_CODE AS �ӷ�, dbo.TW_TAX_ITEM.AMT AS ���I�`�B, dbo.TW_TAX_ITEM.D_AMT AS ��ú�|�B, 
               dbo.TW_TAX_ITEM.SUP_AMT AS �ɥR�O�O, dbo.TW_TAX_ITEM.RET_AMT AS �۴��h���, dbo.TW_TAX_ITEM.FORMAT AS �ұo�榡, 
               dbo.TW_TAX_SUBCODE.M_FORSUB AS �ұo���O, dbo.TW_TAX_ITEM.TAXNO AS �|�y�s��, dbo.TW_TAX_ITEM.MEMO AS �Ƶ�, 
               dbo.TW_TAX_ITEM.IS_FILE AS �w�ӳ�, dbo.TW_TAX_ITEM.KEY_MAN AS �n����, dbo.TW_TAX_ITEM.KEY_DATE AS �n�����, 
               dbo.TW_TAX_ITEM.IMPORT AS �פJ
FROM     dbo.TW_TAX_ITEM INNER JOIN
               dbo.COMP ON dbo.TW_TAX_ITEM.COMP = dbo.COMP.COMP INNER JOIN
               dbo.TBASE ON dbo.TW_TAX_ITEM.NOBR = dbo.TBASE.NOBR LEFT OUTER JOIN
               dbo.TW_TAX_SUBCODE ON dbo.TW_TAX_ITEM.SUBCODE = dbo.TW_TAX_SUBCODE.AUTO
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TW_TAX_ITEM"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 196
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBASE"
            Begin Extent = 
               Top = 9
               Left = 685
               Bottom = 196
               Right = 904
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TW_TAX_SUBCODE"
            Begin Extent = 
               Top = 9
               Left = 961
               Bottom = 196
               Right = 1186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TW_TAX_ITEM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_TW_TAX_ITEM'
GO

DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqColumn WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqCondition WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqForeignKey WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqPreCondition WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqSqlQueryField WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqTable WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqUserColumn WHERE SettingID = @QuerySetting
GO
DECLARE @QuerySetting int
SET @QuerySetting = (select ID FROM jqSetting WHERE QuerySetting = 'TW_TAX_ITEM')
DELETE jqSetting WHERE ID = @QuerySetting
GO
