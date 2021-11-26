
CREATE VIEW [dbo].[人事系統_員工異動資料表]
AS
SELECT     TOP (100) PERCENT b.ADATE, 
                      (CASE b.ttscode WHEN '1' THEN '在職' WHEN '4' THEN '在職' WHEN '6' THEN '在職' WHEN '3' THEN '留職停薪' WHEN '5' THEN '離職' WHEN '2' THEN '離職' END) 
                      AS 狀態, a.NOBR AS 工號, a.NAME_C AS 員工姓名, a.NAME_E AS 英文姓名, 
					  dbo.DEPT.D_NO_DISP AS 異動後部門代碼, --  b.DEPT AS 異動後部門代碼,
					  dbo.DEPT.D_NAME    AS 異動後部門, 
                      DEPT_1.D_NO_DISP AS 原部門代碼, --dbo.BASETTS.DEPT AS 原部門代碼,
					  DEPT_1.D_NAME    AS 原部門,
					  b.DEPTS AS 異動後成本部門代碼, dbo.DEPTS.D_NAME AS 異動後成本部門, 
                      dbo.BASETTS.DEPTS AS 原成本部門代碼, DEPTS_1.D_NAME AS 原成本部門, b.JOB AS 異動後職稱代碼, dbo.JOB.JOB_NAME AS 異動後職稱, 
                      dbo.BASETTS.JOB AS 原職稱代碼, JOB_1.JOB_NAME AS 原職稱, b.JOBL AS 異動後職等, dbo.BASETTS.JOBL AS 原職等, b.DI AS 異動後直間接, 
                      dbo.BASETTS.DI AS 原直間接, b.TTSCD AS 異動原因代碼, dbo.TTSCD.TTSNAME AS 異動原因
FROM         dbo.BASE AS a INNER JOIN
                      dbo.BASETTS AS b ON a.NOBR = b.NOBR INNER JOIN
                      dbo.BASETTS ON b.NOBR = dbo.BASETTS.NOBR INNER JOIN
                      dbo.TTSCD ON b.TTSCD = dbo.TTSCD.TTSCD INNER JOIN
                      dbo.JOB ON b.JOB = dbo.JOB.JOB INNER JOIN
                      dbo.JOB AS JOB_1 ON dbo.BASETTS.JOB = JOB_1.JOB LEFT OUTER JOIN
                      dbo.DEPTS AS DEPTS_1 ON dbo.BASETTS.DEPTS = DEPTS_1.D_NO LEFT OUTER JOIN
                      dbo.DEPTS ON b.DEPTS = dbo.DEPTS.D_NO LEFT OUTER JOIN
                      dbo.DEPT ON b.DEPT = dbo.DEPT.D_NO LEFT OUTER JOIN
                      dbo.DEPT AS DEPT_1 ON dbo.BASETTS.DEPT = DEPT_1.D_NO
WHERE     (b.TTSCODE = '6') AND (DATEADD(day, - 1, b.ADATE) BETWEEN dbo.BASETTS.ADATE AND dbo.BASETTS.DDATE)

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[13] 4[63] 2[4] 3) )"
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
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 242
               Bottom = 125
               Right = 408
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
            TopColumn = 0
         End
         Begin Table = "TTSCD"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 125
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOB"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOB_1"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 245
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS_1"
            Begin Extent = 
               Top = 126
               Left = 446
               Bottom = 245
               Right = 612
            End
            DisplayFlags = 280
            TopColumn =', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_員工異動資料表';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 126
               Left = 650
               Bottom = 245
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPT_1"
            Begin Extent = 
               Top = 246
               Left = 242
               Bottom = 365
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
      Begin ColumnWidths = 24
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
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 3300
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_員工異動資料表';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_員工異動資料表';

