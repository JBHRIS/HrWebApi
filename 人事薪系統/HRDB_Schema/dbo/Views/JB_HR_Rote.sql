CREATE VIEW dbo.JB_HR_Rote
AS
SELECT     GETDATE() AS dAdate, RTRIM(ROTE_DISP) + '_' + RTRIM(ROTENAME) + '(' + RTRIM(ON_TIME) + '-' + RTRIM(OFF_TIME) + ')' AS sName, RTRIM(ROTE) AS sRoteCode, 
                      RTRIM(ROTENAME) AS sRoteName, RTRIM(ON_TIME) AS sOnTime, RTRIM(OFF_TIME) AS sOffTime, WK_HRS AS iWkHrs, DK_HRS AS iDkHrs, MO_HRS AS iMoHrs, 
                      RTRIM(OFFTIME2) AS sOffTime2, ALLLATES AS iAlllates, RTRIM(OT_BEGIN) AS sOtBegin, ALLLATES1 AS iAlllates1, RTRIM(RES_B1_TIME) AS sResBTime, 
                      RTRIM(RES_E1_TIME) AS sResETime, RTRIM(RES_B_TIME) AS sResB1Time, RTRIM(RES_E_TIME) AS sResE1Time, RTRIM(RES_B2_TIME) AS sResB2Time, 
                      RTRIM(RES_E2_TIME) AS sResE2Time, RTRIM(RES_B3_TIME) AS sResB3Time, RTRIM(RES_E3_TIME) AS sResE3Time, RTRIM(RES_B4_TIME) AS sResB4Time, 
                      RTRIM(RES_E4_TIME) AS sResE4Time, RTRIM(ATT_END) AS sAttEnd, YRREST_HRS AS iYrrestHrs, ISNULL(SORT, 0) AS iSort, ISNULL(HOLIDAY_ADDMIN, 0) 
                      AS iHoliDayAddMin
FROM         dbo.ROTE

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[8] 2[21] 3) )"
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
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
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
      Begin ColumnWidths = 28
         Width = 284
         Width = 1500
         Width = 2310
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_Rote';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_Rote';

