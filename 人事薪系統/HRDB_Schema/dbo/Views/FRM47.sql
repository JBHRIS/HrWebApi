CREATE VIEW [dbo].[FRM47]
AS
SELECT  dbo.OT.NOBR, dbo.OT.BDATE, dbo.OT.BTIME, dbo.OT.ETIME, dbo.OT.TOT_HOURS, dbo.OT.OT_HRS, dbo.OT.REST_HRS, dbo.OT.OT_CAR, 
               dbo.OT.OT_DEPT, dbo.OT.KEY_MAN, dbo.OT.KEY_DATE, dbo.OT.OT_FOOD, dbo.OT.NOTE, dbo.OT.YYMM, dbo.OT.NOT_W_133, dbo.OT.NOT_W_167, 
               dbo.OT.NOT_W_200, dbo.OT.NOT_H_200, dbo.OT.TOT_W_133, dbo.OT.TOT_W_167, dbo.OT.TOT_W_200, dbo.OT.NOT_EXP, dbo.OT.TOT_EXP, 
               dbo.OT.SALARY, dbo.OT.NOTMODI, dbo.OT.OTRCD, dbo.OT.NOFOOD, dbo.OT.OT_ROTE, dbo.OT.OT_FOOD1, dbo.OT.NOP_H_200, dbo.OT.TOP_W_133, 
               dbo.OT.TOP_W_167, dbo.OT.TOP_W_200, dbo.OT.TOP_H_200, dbo.OT.NOT_H_133, dbo.OT.NOT_H_167, dbo.OT.HOT_133, dbo.OT.HOT_166, 
               dbo.OT.HOT_200, dbo.OT.WOT_133, dbo.OT.WOT_166, dbo.OT.WOT_200, dbo.OT.SUM, dbo.OT.SYSCREAT, dbo.OT.OTRATE_CODE, dbo.OT.NOT_W_100, 
               dbo.OT.TOP_W_100, dbo.OT.SYSCREAT1, dbo.OT.NOP_W_100, dbo.OT.SYS_OT, dbo.OT.SERNO, dbo.OT.DIFF, dbo.OT.EAT, dbo.OT.RES, dbo.OT.NOFOOD1, 
               dbo.BASE.NAME_C, ISNULL(dbo.JOBS.JOB_NAME, N'') AS JOB_NAME, dbo.DEPTS.D_NAME AS DEPTS_NAME, dbo.DEPT.D_NAME AS DEPT_NAME, 
               dbo.BASETTS.DEPT, dbo.OT.SYS_OT | dbo.OTRCD.SYS_OT | CASE attend.rote WHEN '00' THEN 1 ELSE 0 END AS isHoli, dbo.BASE.COUNT_MA, 
               dbo.OT.OT_FOODH, dbo.OT.OT_FOODH1, dbo.ATTEND.ROTE AS ATT_ROTE, dbo.HOLI_TYPE(dbo.OT.OTRCD, dbo.OT.SYS_OT, dbo.OTRCD.SYS_OT, 
               dbo.ATTEND.ROTE) AS HOLI_TYPE, dbo.OT_TYPE(dbo.OT.OT_HRS, dbo.OT.REST_HRS) AS OT_TYPE
FROM     dbo.OT INNER JOIN
               dbo.BASE ON dbo.OT.NOBR = dbo.BASE.NOBR INNER JOIN
               dbo.BASETTS ON dbo.OT.NOBR = dbo.BASETTS.NOBR AND dbo.OT.BDATE BETWEEN dbo.BASETTS.ADATE AND 
               dbo.BASETTS.DDATE LEFT OUTER JOIN
               dbo.OTRCD ON dbo.OT.OTRCD = dbo.OTRCD.OTRCD LEFT OUTER JOIN
               dbo.JOBS ON dbo.BASETTS.JOBS = dbo.JOBS.JOBS LEFT OUTER JOIN
               dbo.ATTEND ON dbo.OT.NOBR = dbo.ATTEND.NOBR AND dbo.OT.BDATE = dbo.ATTEND.ADATE LEFT OUTER JOIN
               dbo.DEPTS ON dbo.OT.OT_DEPT = dbo.DEPTS.D_NO LEFT OUTER JOIN
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
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "OT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 140
               Right = 213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 251
               Bottom = 140
               Right = 443
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 144
               Left = 38
               Bottom = 278
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OTRCD"
            Begin Extent = 
               Top = 144
               Left = 262
               Bottom = 278
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBS"
            Begin Extent = 
               Top = 282
               Left = 38
               Bottom = 416
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 282
               Left = 241
               Bottom = 416
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 420
               Left = 38
               Bottom = 554
               Right = 203
            End
            DisplayFlags = 280
            T', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM47';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'opColumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 420
               Left = 241
               Bottom = 554
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM47';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM47';

