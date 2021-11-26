CREATE VIEW dbo.JB_HR_Base
AS
SELECT     TOP (100) PERCENT RTRIM(dbo.BASE.NOBR) AS sNobr, RTRIM(dbo.BASE.NAME_C) AS sNameC, RTRIM(dbo.BASE.NOBR) + ',' + RTRIM(dbo.BASE.NAME_C) 
                      AS sName, RTRIM(dbo.BASE.NAME_E) AS sNameE, RTRIM(dbo.BASE.SEX) AS sSex, RTRIM(dbo.BASE.EMAIL) AS sEmail, RTRIM(dbo.BASE.PASSWORD) 
                      AS sPassWord, dbo.BASE.COUNT_MA AS bCountMa, RTRIM(dbo.BASETTS.TTSCODE) AS sTtsCode, dbo.BASETTS.ADATE AS dAdate, dbo.BASETTS.DDATE AS dDdate, 
                      dbo.BASETTS.INDT AS dInDate, ISNULL(dbo.BASETTS.OUDT, CONVERT(DATETIME, '1900/1/1')) AS dOuDate, RTRIM(dbo.BASETTS.DEPT) AS sDeptCode, 
                      RTRIM(dbo.BASETTS.DEPTS) AS sDeptsCode, RTRIM(dbo.BASETTS.DEPTM) AS sDeptmCode, RTRIM(dbo.BASETTS.JOB) AS sJobCode, RTRIM(dbo.BASETTS.JOBL) 
                      AS sJoblCode, RTRIM(dbo.BASETTS.JOBS) AS sJobsCode, RTRIM(dbo.BASETTS.DI) AS sDI, dbo.BASETTS.MANG AS bMang, RTRIM(dbo.BASETTS.ROTET) AS sRotet, 
                      RTRIM(dbo.BASETTS.EMPCD) AS sEmpcd, dbo.BASETTS.CALABS AS bCalAbs, RTRIM(dbo.BASETTS.CALOT) AS sCalOt, RTRIM(dbo.BASETTS.HOLI_CODE) 
                      AS sHoliCode, dbo.BASETTS.NOTER AS bNoTer, dbo.BASETTS.ONLYONTIME AS bOnlyOnTime, RTRIM(dbo.BASETTS.CARD) AS sCard, RTRIM(dbo.BASETTS.SALADR) 
                      AS sSaladr, dbo.BASETTS.MANG1 AS bMang1, RTRIM(dbo.BASETTS.COMP) AS sComp, RTRIM(dbo.BASE.GSM) AS sGsm, RTRIM(dbo.BASE.SUBTEL) AS sSubTel, 
                      dbo.BASE.BIRDT AS dBirdt, RTRIM(dbo.BASE.IDNO) AS sIdno, RTRIM(dbo.BASETTS.WORKCD) AS sWrokcd, RTRIM(dbo.BASETTS.CARCD) AS sCarcd
FROM         dbo.BASE INNER JOIN
                      dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR
WHERE     (CONVERT(NVARCHAR, GETDATE(), 112) BETWEEN CONVERT(NVARCHAR, dbo.BASETTS.ADATE, 112) AND CONVERT(NVARCHAR, dbo.BASETTS.DDATE, 112))

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
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 196
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 234
               Bottom = 121
               Right = 392
            End
            DisplayFlags = 280
            TopColumn = 56
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 30
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_Base';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'JB_HR_Base';

