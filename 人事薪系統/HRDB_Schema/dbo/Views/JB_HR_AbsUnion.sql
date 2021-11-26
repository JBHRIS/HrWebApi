CREATE VIEW dbo.JB_HR_AbsUnion
AS
SELECT     RTRIM(ABS_1.NOBR) AS sNobr, ABS_1.BDATE AS dDateB, ABS_1.EDATE AS dDateE, RTRIM(ABS_1.BTIME) AS sTimeB, RTRIM(ABS_1.ETIME) AS sTimeE, 
                      ABS_1.TOL_HOURS AS iUse, RTRIM(ABS_1.YYMM) AS sYYMM, RTRIM(ABS_1.H_CODE) AS sHoliCode, RTRIM(HCODE.H_NAME) AS sHoliName, RTRIM(HCODE.UNIT) 
                      AS sUint, HCODE.MIN_NUM AS iMin, HCODE.IN_HOLI AS bInHoli, RTRIM(HCODE.YEAR_REST) AS sYearRest, HCODE.MAX_NUM AS iMax, HCODE.CHE AS bChe, 
                      RTRIM(HCODE.DCODE) AS sDcode, RTRIM(HCODE.SEX) AS sSex, HCODE.DISCONTENT AS bDiscontent, HCODE.DISPLAYFORM AS bDisplayform, 
                      HCODE.ABSUNIT AS iInterval, rtrim(a_name) AS sName,isnull( serno,'') AS sSerno
FROM         HCODE INNER JOIN
                      ABS AS ABS_1 ON HCODE.H_CODE = ABS_1.H_CODE
UNION
SELECT     RTRIM(ABS.NOBR) AS sNobr, ABS.BDATE AS dDateB, ABS.EDATE AS dDateE, RTRIM(ABS.BTIME) AS sTimeB, RTRIM(ABS.ETIME) AS sTimeE, 
                      ABS.TOL_HOURS AS iUse, RTRIM(ABS.YYMM) AS sYYMM, RTRIM(ABS.H_CODE) AS sHoliCode, RTRIM(HCODE_1.H_NAME) AS sHoliName, RTRIM(HCODE_1.UNIT) 
                      AS sUint, HCODE_1.MIN_NUM AS iMin, HCODE_1.IN_HOLI AS bInHoli, RTRIM(HCODE_1.YEAR_REST) AS sYearRest, HCODE_1.MAX_NUM AS iMax, 
                      HCODE_1.CHE AS bChe, RTRIM(HCODE_1.DCODE) AS sDcode, RTRIM(HCODE_1.SEX) AS sSex, HCODE_1.DISCONTENT AS bDiscontent, 
                      HCODE_1.DISPLAYFORM AS bDisplayform, HCODE_1.ABSUNIT AS iInterval, '' AS sName, isnull(serno,'') AS sSerno
FROM         HCODE AS HCODE_1 INNER JOIN
                      ABS1 AS ABS ON HCODE_1.H_CODE = ABS.H_CODE

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
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 23
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_AbsUnion';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_AbsUnion';

