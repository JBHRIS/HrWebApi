CREATE VIEW [dbo].[FRM29]
AS
SELECT     dbo.OT.NOBR, dbo.OT.BDATE, dbo.OT.BTIME, dbo.OT.ETIME, dbo.OT.TOT_HOURS, dbo.OT.OT_HRS, dbo.OT.REST_HRS, dbo.OT.OT_CAR, dbo.OT.OT_DEPT, 
                      dbo.OT.KEY_MAN, dbo.OT.KEY_DATE, dbo.OT.OT_FOOD, dbo.OT.NOTE, dbo.OT.FOOD_PRI, dbo.OT.FOOD_CNT, dbo.OT.YYMM, dbo.OT.SER, dbo.OT.NOT_W_133, 
                      dbo.OT.NOT_W_167, dbo.OT.NOT_W_200, dbo.OT.NOT_H_200, dbo.OT.TOT_W_100, dbo.OT.TOT_W_133, dbo.OT.TOT_W_167, dbo.OT.TOT_W_200, 
                      dbo.OT.TOT_H_200, dbo.OT.NOT_EXP, dbo.OT.TOT_EXP, dbo.OT.REST_EXP, dbo.OT.FST_HOURS, dbo.OT.SALARY, dbo.OT.NOTMODI, dbo.OT.OTRCD, 
                      dbo.OT.NOFOOD, dbo.OT.FIX_AMT, dbo.OT.REC, dbo.OT.CANT_ADJ, dbo.OT.OT_EDATE, dbo.OT.OTNO, dbo.OT.OT_ROTE, dbo.OT.OT_FOOD1, dbo.OT.OT_FOODH, 
                      dbo.OT.OT_FOODH1, dbo.OT.NOP_W_133, dbo.OT.NOP_W_167, dbo.OT.NOP_W_200, dbo.OT.NOP_H_100, dbo.OT.NOP_H_133, dbo.OT.NOP_H_167, 
                      dbo.OT.NOP_H_200, dbo.OT.TOP_W_133, dbo.OT.TOP_W_167, dbo.OT.TOP_W_200, dbo.OT.TOP_H_200, dbo.OT.NOT_H_133, dbo.OT.NOT_H_167, dbo.OT.HOT_133, 
                      dbo.OT.HOT_166, dbo.OT.HOT_200, dbo.OT.WOT_133, dbo.OT.WOT_166, dbo.OT.WOT_200, dbo.OT.SUM, dbo.OT.SYSCREAT, dbo.OT.OTRATE_CODE, 
                      dbo.OT.NOT_W_100, dbo.OT.TOP_W_100, dbo.OT.SYSCREAT1, dbo.OT.NOP_W_100, dbo.OT.SYS_OT, dbo.OT.SERNO, dbo.OT.DIFF, dbo.OT.EAT, dbo.OT.RES, 
                      dbo.BASE.NAME_C, dbo.DEPT.D_NO, dbo.DEPT.D_NAME, dbo.DEPTS.D_NO AS DS_NO, dbo.DEPTS.D_NAME AS DS_NAME, dbo.ROTE.ROTENAME, 
                      dbo.BASETTS.ROTET, dbo.OTRCD.OTRNAME, DEPTS_1.D_NAME AS OT_DEPTNAME, dbo.OT.NOFOOD1, 
                      dbo.OT.SYS_OT | dbo.OTRCD.SYS_OT | CASE attend.rote WHEN '00' THEN 1 ELSE 0 END AS isHoli, dbo.BASETTS.JOBS, dbo.JOBS.JOB_NAME AS Jobs_Name, 
                      dbo.BASE.COUNT_MA
FROM         dbo.OT INNER JOIN
                      dbo.BASE ON dbo.OT.NOBR = dbo.BASE.NOBR INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO INNER JOIN
                      dbo.DEPTS ON dbo.BASETTS.DEPTS = dbo.DEPTS.D_NO LEFT OUTER JOIN
                      dbo.ROTE ON dbo.OT.OT_ROTE = dbo.ROTE.ROTE LEFT OUTER JOIN
                      dbo.DEPTS AS DEPTS_1 ON dbo.OT.OT_DEPT = DEPTS_1.D_NO LEFT OUTER JOIN
                      dbo.OTRCD ON dbo.OT.OTRCD = dbo.OTRCD.OTRCD LEFT OUTER JOIN
                      dbo.ATTEND ON dbo.OT.NOBR = dbo.ATTEND.NOBR AND dbo.OT.BDATE = dbo.ATTEND.ADATE LEFT OUTER JOIN
                      dbo.JOBS ON dbo.BASETTS.JOBS = dbo.JOBS.JOBS
WHERE     (CONVERT(datetime, CONVERT(NVARCHAR, dbo.OT.BDATE, 102)) BETWEEN CONVERT(datetime, CONVERT(NVARCHAR, dbo.BASETTS.ADATE, 102)) AND 
                      CONVERT(datetime, CONVERT(NVARCHAR, dbo.BASETTS.DDATE, 102)))

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[67] 4[4] 2[13] 3) )"
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
         Begin Table = "OT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 7
               Left = 245
               Bottom = 126
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 16
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 240
               Left = 668
               Bottom = 359
               Right = 834
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 47
               Left = 744
               Bottom = 166
               Right = 910
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 141
               Left = 431
               Bottom = 260
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS_1"
            Begin Extent = 
               Top = 233
               Left = 61
               Bottom = 352
               Right = 227
            End
            DisplayFlags = 280
            TopCo', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM29';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'lumn = 0
         End
         Begin Table = "OTRCD"
            Begin Extent = 
               Top = 248
               Left = 248
               Bottom = 367
               Right = 414
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
      Begin ColumnWidths = 84
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM29';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FRM29';

