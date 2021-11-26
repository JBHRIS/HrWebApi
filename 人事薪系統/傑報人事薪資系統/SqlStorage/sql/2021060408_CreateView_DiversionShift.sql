/****** Object:  View [dbo].[View_DiversionShift]    Script Date: 2021/6/9 �U�� 04:47:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_DiversionShift]
AS
SELECT  ds.DiversionGroup AS ���y�էO, mt.NAME AS �էO�W��, ds.AttendDate AS �X�Ԥ��, dt.DiversionAttendType AS ���y�W�Z���O, 
               dt.DiversionAttendTypeName AS ���O�W��, ds.KeyDate AS �n�����, ds.KeyMan AS �n����, dt.CheckWFH_Attend AS �ˮ֩~�a�X��, 
               dt.CheckWorkLog AS �ˮ֤u�@��x, dt.CheckWebCard AS �ˮֽu�W���d, dt.CheckTemperoturyReport AS �ˮַūצ^��, ds.AutoKey AS AK, 
               ds.Guid AS �s��
FROM     dbo.DiversionShift AS ds INNER JOIN
               dbo.MTCODE AS mt ON ds.DiversionGroup = mt.CODE AND mt.CATEGORY = 'DiversionGroupType' INNER JOIN
               dbo.DiversionAttendType AS dt ON ds.DiversionAttendType = dt.DiversionAttendType
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
         Begin Table = "ds"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 339
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "mt"
            Begin Extent = 
               Top = 9
               Left = 396
               Bottom = 196
               Right = 615
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "dt"
            Begin Extent = 
               Top = 9
               Left = 672
               Bottom = 196
               Right = 1006
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiversionShift'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_DiversionShift'
GO


