
CREATE VIEW [dbo].[人事系統_請假資料表]
AS
SELECT  dbo.人事系統_員工基本資料表.工號, dbo.人事系統_員工基本資料表.員工姓名, dbo.人事系統_員工基本資料表.英文姓名, 
               dbo.人事系統_員工基本資料表.身分證號, dbo.人事系統_員工基本資料表.年齡, dbo.人事系統_員工基本資料表.年齡分類, 
               dbo.人事系統_員工基本資料表.性別, dbo.人事系統_員工基本資料表.血型, dbo.人事系統_員工基本資料表.直間接, 
               dbo.人事系統_員工基本資料表.年資, dbo.人事系統_員工基本資料表.部門代碼, dbo.人事系統_員工基本資料表.成本部門代碼, 
               dbo.人事系統_員工基本資料表.職稱代碼, dbo.人事系統_員工基本資料表.職稱, dbo.人事系統_員工基本資料表.職等代碼, 
               dbo.人事系統_員工基本資料表.職等名稱, dbo.人事系統_員工基本資料表.班別, dbo.人事系統_員工基本資料表.員別員稱, 
               dbo.ABS.BDATE AS 請假日期, dbo.ABS.H_CODE AS 假別代號, dbo.ABS.TOL_HOURS AS 請假時數, dbo.ABS.BTIME AS 開始時間, 
               dbo.ABS.ETIME AS 結束時間, dbo.ABS.YYMM AS 計薪年月, dbo.ABS.NOTE AS 備註, dbo.HCODE.H_NAME AS 假別名稱, 
               dbo.HCODE.YEAR_REST AS 年補休特性, dbo.HCODE.UNIT AS 假別單位, dbo.人事系統_員工基本資料表.部門名稱, 
               dbo.人事系統_員工基本資料表.職類名稱
FROM     dbo.ABS INNER JOIN
               dbo.人事系統_員工基本資料表 ON dbo.ABS.NOBR = dbo.人事系統_員工基本資料表.工號 INNER JOIN
               dbo.HCODE ON dbo.ABS.H_CODE = dbo.HCODE.H_CODE
GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_請假資料表';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[45] 2[3] 3) )"
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
         Begin Table = "ABS"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 18
         End
         Begin Table = "人事系統_員工基本資料表"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 282
               Right = 569
            End
            DisplayFlags = 280
            TopColumn = 59
         End
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 9
               Left = 609
               Bottom = 196
               Right = 838
            End
            DisplayFlags = 280
            TopColumn = 1
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'人事系統_請假資料表';

