DROP View [dbo].[View_MealDeduction]
GO

/****** Object:  View [dbo].[View_MealDeduction]    Script Date: 2020/11/10 �U�� 02:06:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_MealDeduction]
AS
SELECT  TOP (100) PERCENT MD.NOBR AS ���u�s��, B.NAME_C AS ���u�m�W, MD.ADATE AS ���\���, MT.MEALTYPE_CODE AS ���\�����N�X, 
               MT.MEALTYPE_NAME AS ���\�����W��, MT.BTIME AS �_�l�ɶ�, MT.ETIME AS �����ɶ�, MD.YYMM AS �p�~�~��, MD.AMT AS ���ڪ��B, 
               CASE MD.Apply WHEN 1 THEN '��' ELSE '�L' END AS ���\, CASE MD.Attend WHEN 1 THEN '��' ELSE '�L' END AS �X��, 
               CASE MD.OT WHEN 1 THEN '��' ELSE '�L' END AS �[�Z, CASE MD.Eat WHEN 1 THEN '��' ELSE '�L' END AS ���\, MG.MealGroup_DISP AS ���\�s�եN�X, 
               MG.MealGroup_Name AS ���\�s�զW��, D.D_NO_DISP AS �����N�X, D.D_NAME AS �����W��, MD.NOTE AS �Ƶ�, MD.SERO AS �Ǹ�, 
               MD.KEY_MAN AS �n����, MD.KEY_DATE AS �n�����, MD.AutoKey
FROM     dbo.MealDeduction AS MD INNER JOIN
               dbo.BASE AS B ON MD.NOBR = B.NOBR INNER JOIN
               dbo.BASETTS AS BT ON MD.NOBR = BT.NOBR INNER JOIN
               dbo.MealType AS MT ON MD.MealType = MT.MEALTYPE_CODE AND MD.MealGroup = MT.MEALGROUP INNER JOIN
               dbo.DEPT AS D ON BT.DEPT = D.D_NO LEFT OUTER JOIN
                   (SELECT  UDF.NOBR, UDF.VALUE
                   FROM     dbo.USERDEFINEVALUE AS UDF INNER JOIN
                                  dbo.USERDEFINESOURCE AS UDS ON UDF.SOURCEID = UDS.SOURCEID
                   WHERE   (UDS.SOURCENAME = 'MealGroup')) AS UD ON UD.NOBR = MD.NOBR LEFT OUTER JOIN
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
         Begin Table = "MD"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "B"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 196
               Right = 577
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BT"
            Begin Extent = 
               Top = 9
               Left = 634
               Bottom = 196
               Right = 874
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MT"
            Begin Extent = 
               Top = 9
               Left = 931
               Bottom = 196
               Right = 1187
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
         En' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealDeduction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
         Width = 1000
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealDeduction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_MealDeduction'
GO


