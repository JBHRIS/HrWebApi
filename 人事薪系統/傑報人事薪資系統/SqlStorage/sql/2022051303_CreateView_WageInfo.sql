/****** Object:  View [dbo].[View_WageInfo]    Script Date: 2022/5/13 上午 09:46:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_WageInfo]
AS
SELECT          A.YYMM AS 計薪年月, A.SEQ AS 期別, C.MENO AS 說明, A.NOBR AS 員工編號, B.NAME_C AS 員工姓名, 
                            B.COUNT_MA AS 外籍, A.TAXRATE AS 稅率, A.FILE_YYMM AS 提前申報年月, D.TAX_DATE AS 居留證起日, 
                            D.TAX_EDATE AS 居留證迄日, E.TotalAmt AS 實發薪資, E.TotalPayAmt AS 應發薪資, E.TaxableAmt AS 應稅薪資, 
                            E.NonTaxableAmt AS 免稅薪資, E.TaxAmt AS 所得稅
FROM              dbo.WAGE AS A INNER JOIN
                            dbo.BASE AS B ON A.NOBR = B.NOBR LEFT OUTER JOIN
                            dbo.LOCK_WAGE AS C ON A.YYMM = C.YYMM AND A.SEQ = C.SEQ AND A.SALADR = C.SALADR INNER JOIN
                            dbo.BASETTS AS D ON B.NOBR = D.NOBR AND A.DATE_E BETWEEN D.ADATE AND D.DDATE INNER JOIN
                            dbo.View_WageDetailSummary AS E ON A.NOBR = E.EmployeeId AND A.YYMM = E.YYMM AND A.SEQ = E.SEQ

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
         Begin Table = "A"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 136
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "C"
            Begin Extent = 
               Top = 6
               Left = 501
               Bottom = 136
               Right = 666
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 6
               Left = 704
               Bottom = 136
               Right = 875
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_WageInfo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_WageInfo'
GO


