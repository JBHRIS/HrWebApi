CREATE VIEW [dbo].[chk_OT_night_food]
AS
SELECT     dbo.ROTE.ROTE, 350.0 / 8.0 * dbo.OT.TOT_HOURS AS 應給金額, dbo.DECODE(dbo.OT.OT_FOOD) AS 實際金額, 
                      350.0 / 8.0 * dbo.OT.TOT_HOURS - dbo.DECODE(dbo.OT.OT_FOOD) AS 差異金額, dbo.OT.NOBR, dbo.OT.BDATE, dbo.OT.BTIME, dbo.OT.ETIME, dbo.OT.TOT_HOURS, 
                      dbo.OT.OT_HRS, dbo.OT.REST_HRS, dbo.OT.OT_CAR, dbo.OT.OT_DEPT, dbo.OT.KEY_MAN, dbo.OT.KEY_DATE, dbo.OT.OT_FOOD, dbo.OT.NOTE, dbo.OT.FOOD_PRI, 
                      dbo.OT.FOOD_CNT, dbo.OT.YYMM, dbo.OT.SER, dbo.OT.NOT_W_133, dbo.OT.NOT_W_167, dbo.OT.NOT_W_200, dbo.OT.NOT_H_200, dbo.OT.TOT_W_100, 
                      dbo.OT.TOT_W_133, dbo.OT.TOT_W_167, dbo.OT.TOT_W_200, dbo.OT.TOT_H_200, dbo.OT.NOT_EXP, dbo.OT.TOT_EXP, dbo.OT.REST_EXP, dbo.OT.FST_HOURS, 
                      dbo.OT.SALARY, dbo.OT.NOTMODI, dbo.OT.OTRCD, dbo.OT.NOFOOD, dbo.OT.FIX_AMT, dbo.OT.REC, dbo.OT.CANT_ADJ, dbo.OT.OT_EDATE, dbo.OT.OTNO, 
                      dbo.OT.OT_ROTE, dbo.OT.OT_FOOD1, dbo.OT.OT_FOODH, dbo.OT.OT_FOODH1, dbo.OT.NOP_W_133, dbo.OT.NOP_W_167, dbo.OT.NOP_W_200, dbo.OT.NOP_H_100, 
                      dbo.OT.NOP_H_133, dbo.OT.NOP_H_167, dbo.OT.NOP_H_200, dbo.OT.TOP_W_133, dbo.OT.TOP_W_167, dbo.OT.TOP_W_200, dbo.OT.TOP_H_200, 
                      dbo.OT.NOT_H_133, dbo.OT.NOT_H_167, dbo.OT.HOT_133, dbo.OT.HOT_166, dbo.OT.HOT_200, dbo.OT.WOT_133, dbo.OT.WOT_166, dbo.OT.WOT_200, dbo.OT.SUM, 
                      dbo.OT.SYSCREAT, dbo.OT.OTRATE_CODE, dbo.OT.NOT_W_100, dbo.OT.TOP_W_100, dbo.OT.SYSCREAT1, dbo.OT.NOP_W_100, dbo.OT.SYS_OT, dbo.OT.SERNO, 
                      dbo.OT.DIFF, dbo.OT.EAT, dbo.OT.RES, dbo.OT.NOFOOD1, dbo.ATTEND.NOBR AS Expr1, dbo.ATTEND.ADATE, dbo.ATTEND.ROTE AS Expr2, 
                      dbo.ATTEND.KEY_MAN AS Expr3, dbo.ATTEND.KEY_DATE AS Expr4, dbo.ATTEND.LATE_MINS, dbo.ATTEND.E_MINS, dbo.ATTEND.ABS, dbo.ATTEND.ADJ_CODE, 
                      dbo.ATTEND.CANT_ADJ AS Expr5, dbo.ATTEND.SER AS Expr6, dbo.ATTEND.NIGHT_HRS, dbo.ATTEND.FOODAMT, dbo.ATTEND.FOODSALCD, dbo.ATTEND.FORGET, 
                      dbo.ATTEND.ATT_HRS, dbo.ATTEND.NIGAMT, dbo.ROTE.ROTE AS Expr7, dbo.ROTE.ROTENAME, dbo.ROTE.ON_TIME, dbo.ROTE.OFF_TIME, dbo.ROTE.RES_B_TIME, 
                      dbo.ROTE.RES_E_TIME, dbo.ROTE.WK_HRS, dbo.ROTE.DK_HRS, dbo.ROTE.MO_HRS, dbo.ROTE.OFFTIME2, dbo.ROTE.KEY_MAN AS Expr8, 
                      dbo.ROTE.KEY_DATE AS Expr9, dbo.ROTE.OVERDAY, dbo.ROTE.NIGHT, dbo.ROTE.HOLI_MINS, dbo.ROTE.WR_HRSA, dbo.ROTE.WR_HRSB, dbo.ROTE.FCOLOR, 
                      dbo.ROTE.BCOLOR, dbo.ROTE.OT, dbo.ROTE.RES_B1_TIME, dbo.ROTE.RES_E1_TIME, dbo.ROTE.RES_B2_TIME, dbo.ROTE.RES_E2_TIME, 
                      dbo.ROTE.RES_B3_TIME, dbo.ROTE.RES_E3_TIME, dbo.ROTE.RES_B4_TIME, dbo.ROTE.RES_E4_TIME, dbo.ROTE.YRREST_HRS, dbo.ROTE.RATE2, 
                      dbo.ROTE.EARAWARD, dbo.ROTE.FOODSALCD AS Expr10, dbo.ROTE.FOODAMT AS Expr11, dbo.ROTE.NIGHTSALCD, dbo.ROTE.NIGHTAMT, dbo.ROTE.NIGHTAMT1, 
                      dbo.ROTE.NOTFOOD, dbo.ROTE.FOODAMT1, dbo.ROTE.WK_HRSA, dbo.ROTE.WK_HRSB, dbo.ROTE.ALLLATES, dbo.ROTE.OT_BEGIN, dbo.ROTE.DD, 
                      dbo.ROTE.CALOT, dbo.ROTE.FOODAMTO, dbo.ROTE.OVER_TIME, dbo.ROTE.STR_TIME, dbo.ROTE.SPECSALCD, dbo.ROTE.SPECAMT, dbo.ROTE.SPECAMT1, 
                      dbo.ROTE.SPECAMT2, dbo.ROTE.ALLLATES1, dbo.ROTE.ATT_END, dbo.ROTE.HELF, dbo.ROTE.BEF_NIGHTAMT, dbo.ROTE.AFT_NIGHTAMT, dbo.ROTE.FOODRULE, 
                      dbo.ROTE.NIGHTRULE, dbo.ROTE.SPECRULE
FROM         dbo.OT INNER JOIN
                      dbo.ATTEND ON dbo.OT.NOBR = dbo.ATTEND.NOBR AND dbo.OT.BDATE = dbo.ATTEND.ADATE INNER JOIN
                      dbo.ROTE ON dbo.ATTEND.ROTE = dbo.ROTE.ROTE
WHERE     (dbo.ROTE.OFF_TIME >= '2400') AND (dbo.DECODE(dbo.OT.OT_FOOD) / dbo.OT.TOT_HOURS < 350.0 / 8.0) AND (dbo.OT.BTIME < '1200') AND 
                      (dbo.OT.NOBR NOT LIKE 'F%') AND (dbo.OT.TOT_HOURS > 0) AND (dbo.OT.YYMM >= '201007') AND 
                      (dbo.OT.TOT_HOURS * 350.0 / 8.0 - dbo.DECODE(dbo.OT.OT_FOOD) <> 0)

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
         Begin Table = "OT"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 125
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
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
      Begin ColumnWidths = 154
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
         Width = 150', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'chk_OT_night_food';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'0
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'chk_OT_night_food';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'chk_OT_night_food';

