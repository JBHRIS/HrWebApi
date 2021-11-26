
CREATE VIEW [dbo].[ReportExplab]
AS
SELECT  TOP (100) PERCENT dbo.EXPLAB.YYMM AS 計薪年月, dbo.ReportEMP.員工編號, dbo.ReportEMP.員工姓名, dbo.ReportEMP.編制部門代碼, 
               dbo.ReportEMP.編制部門名稱, dbo.v_insur_type.NAME AS 保險種類, dbo.DECODE(dbo.EXPLAB.EXP) AS 個人負擔勞保費,
                   (SELECT  SUM(dbo.DECODE(EXP)) AS Expr1
                   FROM     dbo.EXPLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (YYMM = dbo.EXPLAB.YYMM) AND (INSUR_TYPE = '2')) AS 個人負擔健保費, dbo.ReportEMP.扶養人數, 
               dbo.ReportEMP.公司到職日,
                   (SELECT  COUNT(FA_IDNO) AS Expr1
                   FROM     dbo.INSLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (dbo.EXPLAB.ADATE BETWEEN IN_DATE AND OUT_DATE) AND (FA_IDNO <> '')) AS 眷屬人數,
                   (SELECT  SUM(dbo.DECODE(EXP)) AS Expr1
                   FROM     dbo.EXPLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (YYMM = dbo.EXPLAB.YYMM) AND (INSUR_TYPE = '4')) AS 個人負擔勞退,
                   (SELECT  SUM(dbo.DECODE(COMP)) AS Expr1
                   FROM     dbo.EXPLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (YYMM = dbo.EXPLAB.YYMM) AND (INSUR_TYPE = '1')) AS 公司負擔勞保,
                   (SELECT  SUM(dbo.DECODE(COMP)) AS Expr1
                   FROM     dbo.EXPLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (YYMM = dbo.EXPLAB.YYMM) AND (INSUR_TYPE = '1')) AS 公司負擔健保,
                   (SELECT  SUM(dbo.DECODE(COMP)) AS Expr1
                   FROM     dbo.EXPLAB AS a
                   WHERE   (NOBR = dbo.EXPLAB.NOBR) AND (YYMM = dbo.EXPLAB.YYMM) AND (INSUR_TYPE = '4')) AS 公司負擔勞退
FROM     dbo.EXPLAB INNER JOIN
               dbo.ReportEMP ON dbo.EXPLAB.NOBR = dbo.ReportEMP.員工編號 INNER JOIN
               dbo.SALCODE ON dbo.EXPLAB.SAL_CODE = dbo.SALCODE.SAL_CODE INNER JOIN
               dbo.v_insur_type ON dbo.EXPLAB.INSUR_TYPE = dbo.v_insur_type.CODE
WHERE   (dbo.v_insur_type.CODE IN (N'1')) AND (dbo.EXPLAB.FA_IDNO = '')
ORDER BY 計薪年月 DESC, dbo.ReportEMP.員工編號, dbo.v_insur_type.CODE
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportExplab';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'= 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportExplab';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[20] 4[33] 2[41] 3) )"
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
         Begin Table = "EXPLAB"
            Begin Extent = 
               Top = 15
               Left = 112
               Bottom = 145
               Right = 330
            End
            DisplayFlags = 280
            TopColumn = 10
         End
         Begin Table = "ReportEMP"
            Begin Extent = 
               Top = 8
               Left = 594
               Bottom = 138
               Right = 791
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALCODE"
            Begin Extent = 
               Top = 114
               Left = 833
               Bottom = 235
               Right = 1013
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "v_insur_type"
            Begin Extent = 
               Top = 75
               Left = 295
               Bottom = 188
               Right = 460
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
      Begin ColumnWidths = 12
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2070
         Alias = 1490
         Table = 1200
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'ReportExplab';

