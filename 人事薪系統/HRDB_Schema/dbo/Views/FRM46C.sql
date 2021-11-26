CREATE VIEW [dbo].[FRM46C]
AS
SELECT     dbo.WAGEDD.NOBR, dbo.WAGEDD.YYMM, dbo.WAGEDD.SEQ, dbo.WAGEDD.SAL_CODE, dbo.WAGEDD.AMT, dbo.WAGEDD.ACNO, dbo.WAGEDD.KEY_MAN, 
                      dbo.WAGEDD.KEY_DATE, dbo.BASE.NAME_C, dbo.SALCODE.SAL_NAME, dbo.DEPT.D_NAME, dbo.DEPT.D_NO
FROM         dbo.WAGEDD INNER JOIN
                      dbo.BASE ON dbo.WAGEDD.NOBR = dbo.BASE.NOBR INNER JOIN
                      dbo.SALCODE ON dbo.WAGEDD.SAL_CODE = dbo.SALCODE.SAL_CODE INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR AND GETDATE() BETWEEN dbo.BASETTS.ADATE AND dbo.BASETTS.DDATE INNER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO

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
         Begin Table = "WAGEDD"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 54
               Left = 349
               Bottom = 173
               Right = 515
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALCODE"
            Begin Extent = 
               Top = 152
               Left = 61
               Bottom = 271
               Right = 227
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 51
               Left = 716
               Bottom = 170
               Right = 882
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 58
               Left = 1081
               Bottom = 177
               Right = 1247
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
      Begin ColumnWidths = 10
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Al', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46C';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'ias = 900
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46C';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM46C';

