
CREATE VIEW [dbo].[人事系統_出勤資料表]
AS
SELECT  dbo.人事系統_員工基本資料表.狀態, dbo.人事系統_員工基本資料表.工號, dbo.人事系統_員工基本資料表.英文姓名, 
               dbo.人事系統_員工基本資料表.出生日期, dbo.人事系統_員工基本資料表.年齡, dbo.人事系統_員工基本資料表.血型, 
               dbo.人事系統_員工基本資料表.姻婚, dbo.人事系統_員工基本資料表.年資, dbo.人事系統_員工基本資料表.異動狀態, 
               dbo.人事系統_員工基本資料表.到職日期, dbo.人事系統_員工基本資料表.部門名稱, dbo.人事系統_員工基本資料表.成本部門代碼, 
               dbo.人事系統_員工基本資料表.成本部門名稱, dbo.人事系統_員工基本資料表.職稱, dbo.人事系統_員工基本資料表.職等名稱, 
               dbo.人事系統_員工基本資料表.職等代碼, dbo.ATTEND.NOBR AS 員工編號, dbo.ATTEND.ADATE AS 出勤日期, dbo.ATTEND.LATE_MINS AS 遲到分鐘, 
               dbo.ATTEND.ABS AS 礦職, dbo.ATTEND.E_MINS AS 早退分鐘, dbo.ATTCARD.TT1 AS 上班時間, dbo.ATTCARD.TT2 AS 下班時間, 
               dbo.人事系統_員工基本資料表.員工姓名, dbo.ROTE.ROTENAME AS 班別名稱, dbo.ROTE.ROTE AS 班別代碼
FROM     dbo.人事系統_員工基本資料表 INNER JOIN
               dbo.ATTEND ON dbo.人事系統_員工基本資料表.工號 = dbo.ATTEND.NOBR INNER JOIN
               dbo.ROTE ON dbo.ATTEND.ROTE = dbo.ROTE.ROTE LEFT OUTER JOIN
               dbo.ATTCARD ON dbo.ATTEND.NOBR = dbo.ATTCARD.NOBR AND dbo.ATTEND.ADATE = dbo.ATTCARD.ADATE
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_出勤資料表';


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
         Begin Table = "人事系統_員工基本資料表"
            Begin Extent = 
               Top = 0
               Left = 1078
               Bottom = 417
               Right = 1358
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 277
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTCARD"
            Begin Extent = 
               Top = 87
               Left = 393
               Bottom = 333
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 0
               Left = 761
               Bottom = 187
               Right = 1030
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_出勤資料表';

