CREATE VIEW [dbo].[FRM28]
AS
SELECT     dbo.ABS.NOBR, dbo.ABS.BDATE, dbo.ABS.EDATE, dbo.ABS.BTIME, dbo.ABS.ETIME, dbo.ABS.H_CODE, dbo.ABS.TOL_HOURS, dbo.ABS.KEY_MAN, 
                      dbo.ABS.KEY_DATE, dbo.ABS.YYMM, dbo.ABS.NOTEDIT, dbo.ABS.NOTE, dbo.ABS.SYSCREATE, dbo.ABS.TOL_DAY, dbo.ABS.A_NAME, dbo.ABS.SERNO, 
                      dbo.BASE.NAME_C, dbo.HCODE.H_NAME, dbo.HCODE.UNIT, dbo.UNIT.NAME AS UNITNAME, dbo.DEPTS.D_NO AS DS_NO, dbo.DEPTS.D_NAME AS DS_NAME, 
                      dbo.DEPT.D_NO, dbo.DEPT.D_NAME, dbo.COMP.COMP, dbo.COMP.COMPNAME, dbo.BASETTS.EMPCD
FROM         dbo.HCODE INNER JOIN
                      dbo.ABS INNER JOIN
                      dbo.BASE ON dbo.ABS.NOBR = dbo.BASE.NOBR ON dbo.HCODE.H_CODE = dbo.ABS.H_CODE INNER JOIN
                      dbo.COMP INNER JOIN
                      dbo.BASETTS ON dbo.COMP.COMP = dbo.BASETTS.COMP ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.UNIT ON dbo.HCODE.UNIT = dbo.UNIT.CODE INNER JOIN
                      dbo.DEPTS ON dbo.BASETTS.DEPTS = dbo.DEPTS.D_NO INNER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO
WHERE     (CONVERT(datetime, CONVERT(NVARCHAR, dbo.ABS.BDATE, 102)) BETWEEN CONVERT(datetime, CONVERT(NVARCHAR, dbo.BASETTS.ADATE, 102)) AND 
                      CONVERT(datetime, CONVERT(NVARCHAR, dbo.BASETTS.DDATE, 102)))

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[60] 4[4] 2[17] 3) )"
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
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 187
               Left = 284
               Bottom = 306
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ABS"
            Begin Extent = 
               Top = 131
               Left = 9
               Bottom = 250
               Right = 175
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 8
               Left = 191
               Bottom = 127
               Right = 357
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 110
               Left = 568
               Bottom = 229
               Right = 734
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 9
               Left = 377
               Bottom = 128
               Right = 543
            End
            DisplayFlags = 280
            TopColumn = 27
         End
         Begin Table = "UNIT"
            Begin Extent = 
               Top = 257
               Left = 517
               Bottom = 376
               Right = 683
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 0
               Left = 588
               Bottom = 119
               Right = 754
            End
            DisplayFlags = 280
            TopCo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM28';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 86
               Left = 649
               Bottom = 205
               Right = 815
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
      Begin ColumnWidths = 27
         Width = 284
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM28';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM28';

