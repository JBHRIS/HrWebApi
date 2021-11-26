/****** Object:  View [dbo].[View_MealApplyRecord]    Script Date: 2020/7/16 上午 10:53:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_MealApplyRecord]
AS
SELECT  MAR.NOBR AS 員工編號, B.NAME_C AS 員工姓名, MAR.ADATE AS 報餐日期, MT.MEALTYPE_CODE AS 用餐種類代碼, 
               MT.MEALTYPE_NAME AS 用餐種類名稱, MT.BTIME AS 起始時間, MT.ETIME AS 結束時間, MG.MealGroup_DISP AS 用餐群組代碼, 
               MG.MealGroup_Name AS 用餐群組名稱, D.D_NO_DISP AS 部門代碼, D.D_NAME AS 部門名稱, MAR.NOTE AS 備註, MAR.SeroNO AS 序號, 
               MAR.KEY_MAN AS 登錄者, MAR.KEY_DATE AS 登錄日期, MAR.AutoKey
FROM     dbo.MealApplyRecord AS MAR INNER JOIN
               dbo.BASE AS B ON MAR.NOBR = B.NOBR INNER JOIN
               dbo.BASETTS AS BT ON MAR.NOBR = BT.NOBR INNER JOIN
               dbo.MealType AS MT ON MAR.MEALTYPE = MT.MEALTYPE_CODE INNER JOIN
               dbo.DEPT AS D ON BT.DEPT = D.D_NO LEFT OUTER JOIN
                   (SELECT  UDF.NOBR, UDF.VALUE
                   FROM     dbo.USERDEFINEVALUE AS UDF INNER JOIN
                                  dbo.USERDEFINESOURCE AS UDS ON UDF.SOURCEID = UDS.SOURCEID
                   WHERE   (UDS.SOURCENAME = 'MealGroup')) AS UD ON UD.NOBR = MAR.NOBR LEFT OUTER JOIN
               dbo.MealGroup AS MG ON UD.VALUE = MG.MealGroup_Code
WHERE   (BT.ADATE <= GETDATE()) AND (BT.DDATE >= GETDATE())
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
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
         Begin Table = "MAR"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 310
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 9
               Left = 367
               Bottom = 196
               Right = 611
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BT"
            Begin Extent = 
               Top = 9
               Left = 668
               Bottom = 196
               Right = 908
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MT"
            Begin Extent = 
               Top = 9
               Left = 965
               Bottom = 196
               Right = 1221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "D"
            Begin Extent = 
               Top = 198
               Left = 57
               Bottom = 385
               Right = 278
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UD"
            Begin Extent = 
               Top = 198
               Left = 335
               Bottom = 335
               Right = 554
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MG"
            Begin Extent = 
               Top = 198
               Left = 611
               Bottom = 385
               Right = 870
            End
            DisplayFlags = 280
            TopColumn = 0
         E' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealApplyRecord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealApplyRecord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealApplyRecord'
GO


