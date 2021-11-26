CREATE VIEW [dbo].[FRM2B]
AS
SELECT     dbo.ABS1.NOBR, dbo.ABS1.BDATE, dbo.ABS1.EDATE, dbo.ABS1.BTIME, dbo.ABS1.ETIME, dbo.ABS1.H_CODE, dbo.ABS1.TOL_HOURS, dbo.ABS1.KEY_MAN, 
                      dbo.ABS1.KEY_DATE, dbo.ABS1.YYMM, dbo.ABS1.NOTE, dbo.ABS1.SERNO, dbo.BASE.NAME_C, dbo.HCODE.H_NAME, dbo.HCODE.UNIT, 
                      dbo.UNIT.NAME AS UNITNAME, dbo.DEPTS.D_NO AS DS_NO, dbo.DEPTS.D_NAME AS DS_NAME, dbo.DEPT.D_NO, dbo.DEPT.D_NAME, dbo.COMP.COMP, 
                      dbo.COMP.COMPNAME, dbo.BASETTS.EMPCD, dbo.ABS1.BDATE2, dbo.ABS1.EDATE2, dbo.ABS1.BTIME2, dbo.ABS1.ETIME2, dbo.ABS1.BTIME3, dbo.ABS1.ETIME3, 
                      dbo.ABS1.GO_TYPE, dbo.ABS1.ABORD, dbo.ABS1.[CFM_MAN ], dbo.ABS1.DEPT, dbo.ABS1.TARGET, dbo.ABS1.REASON, dbo.ABS1.CUST, dbo.ABS1.NOT_DISP, 
                      dbo.ABS1.ONETOMANY, dbo.ABS1.SEQ
FROM         dbo.HCODE INNER JOIN
                      dbo.ABS1 INNER JOIN
                      dbo.BASE ON dbo.ABS1.NOBR = dbo.BASE.NOBR ON dbo.HCODE.H_CODE = dbo.ABS1.H_CODE INNER JOIN
                      dbo.COMP INNER JOIN
                      dbo.BASETTS ON dbo.COMP.COMP = dbo.BASETTS.COMP ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.UNIT ON dbo.HCODE.UNIT = dbo.UNIT.CODE INNER JOIN
                      dbo.DEPTS ON dbo.BASETTS.DEPTS = dbo.DEPTS.D_NO INNER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO
WHERE     (CONVERT(NVARCHAR, dbo.ABS1.BDATE, 102) BETWEEN CONVERT(NVARCHAR, dbo.BASETTS.ADATE, 102) AND CONVERT(NVARCHAR, dbo.BASETTS.DDATE, 102))

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ABS1"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 125
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 24
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 125
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 854
               Bottom = 125
               Right = 1020
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UNIT"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 245
               Right = 408
            End
            DisplayFlags = 280
            TopCol', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM2B';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'umn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 126
               Left = 446
               Bottom = 245
               Right = 612
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
      Begin ColumnWidths = 9
         Width = 284
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM2B';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM2B';

