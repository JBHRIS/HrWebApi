CREATE VIEW [dbo].[View_DiversionGroup]
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
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_DiversionGroup';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'      Output = 720
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_DiversionGroup';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[17] 3) )"
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
         Begin Table = "dg"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 334
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 9
               Left = 391
               Bottom = 196
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "bs"
            Begin Extent = 
               Top = 9
               Left = 710
               Bottom = 196
               Right = 956
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 9
               Left = 1013
               Bottom = 196
               Right = 1234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mt"
            Begin Extent = 
               Top = 198
               Left = 57
               Bottom = 385
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "wk"
            Begin Extent = 
               Top = 198
               Left = 333
               Bottom = 385
               Right = 553
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
   ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'View_DiversionGroup';

