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

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[17] 2[23] 3) )"
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
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 123
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ABS"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 123
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 123
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 123
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 243
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOB"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 243
               Right = 408
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
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'HR_Portal_Abs';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'HR_Portal_Abs';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'HR_Portal_Abs';

