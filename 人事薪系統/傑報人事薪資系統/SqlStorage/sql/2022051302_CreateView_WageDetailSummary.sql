/****** Object:  View [dbo].[View_WageDetailSummary]    Script Date: 2022/5/13 ¤W¤È 09:44:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_WageDetailSummary]
AS
WITH WageDetailSummaryData(EmployeeId, Amt, SalaryType, IsTaxable, Salcode, YYMM, SEQ) AS (SELECT          NOBR, 
                                                                                                                                                                                                                                                      CASE WHEN flag
                                                                                                                                                                                                                                                       != '-' THEN dbo.decode(AMT)
                                                                                                                                                                                                                                                       ELSE dbo.decode(AMT)
                                                                                                                                                                                                                                                       * - 1 END AS AMT,
                                                                                                                                                                                                                                                       TYPE, TAX, 
                                                                                                                                                                                                                                                      SAL_CODE, 
                                                                                                                                                                                                                                                      YYMM, 
                                                                                                                                                                                                                                                      SEQ
                                                                                                                                                                                                                          FROM               dbo.WagedSal)
    SELECT          NOBR AS EmployeeId, YYMM, SEQ, ISNULL
                                     ((SELECT          SUM(Amt) AS Expr1
                                         FROM              WageDetailSummaryData AS a
                                         WHERE          (dbo.WAGE.NOBR = EmployeeId) AND (dbo.WAGE.YYMM = YYMM) AND (dbo.WAGE.SEQ = SEQ)), 
                                 0) AS TotalAmt, ISNULL
                                     ((SELECT          SUM(Amt) AS Expr1
                                         FROM              WageDetailSummaryData AS a
                                         WHERE          (dbo.WAGE.NOBR = EmployeeId) AND (dbo.WAGE.YYMM = YYMM) AND (dbo.WAGE.SEQ = SEQ) 
                                                                     AND (SalaryType <> '3')), 0) AS TotalPayAmt, ISNULL
                                     ((SELECT          SUM(Amt) AS Expr1
                                         FROM              WageDetailSummaryData AS a
                                         WHERE          (dbo.WAGE.NOBR = EmployeeId) AND (dbo.WAGE.YYMM = YYMM) AND (dbo.WAGE.SEQ = SEQ) 
                                                                     AND (IsTaxable = 1)), 0) AS TaxableAmt, ISNULL
                                     ((SELECT          SUM(Amt) AS Expr1
                                         FROM              WageDetailSummaryData AS a
                                         WHERE          (dbo.WAGE.NOBR = EmployeeId) AND (dbo.WAGE.YYMM = YYMM) AND (dbo.WAGE.SEQ = SEQ) 
                                                                     AND (IsTaxable = 0) AND (SalaryType <> '3')), 0) AS NonTaxableAmt, ISNULL
                                     ((SELECT          SUM(Amt) AS Expr1
                                         FROM              WageDetailSummaryData AS a
                                         WHERE          (dbo.WAGE.NOBR = EmployeeId) AND (dbo.WAGE.YYMM = YYMM) AND (dbo.WAGE.SEQ = SEQ) 
                                                                     AND EXISTS
                                                                         (SELECT          1 AS Expr1
                                                                           FROM               dbo.U_SYS9 AS x
                                                                           WHERE           (TAXSALCODE = a.Salcode))), 0) AS TaxAmt
     FROM               dbo.WAGE

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[29] 4[4] 2[49] 3) )"
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
         Begin Table = "WAGE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 212
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_WageDetailSummary'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_WageDetailSummary'
GO


