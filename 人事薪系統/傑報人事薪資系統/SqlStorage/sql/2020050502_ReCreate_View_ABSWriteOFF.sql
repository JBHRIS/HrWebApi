drop view [dbo].[View_AbsWriteOff]
GO

/****** Object:  View [dbo].[View_AbsWriteOff]    Script Date: 2020/5/5 �U�� 03:39:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_AbsWriteOff]
AS
SELECT  TOP (100) PERCENT ABS.�ݩ�, ABS.���u�s��, dbo.BASE.NAME_C AS ���u�m�W, ABS.�p�~�~��, dbo.ROTE.ROTE_DISP AS �Z�O, 
               dbo.ROTE.ROTENAME AS �Z�O�W��, dbo.HCODE.H_CODE AS ���O�N�X, dbo.HCODE.H_CODE_DISP AS ���O, dbo.HCODE.H_NAME AS ���O�W��, 
               ABS.�а����, ABS.�а��_, ABS.�а���, ABS.�а��ɼ�, dbo.HCODE.UNIT AS ���, ABS.�s��, ABS.�n����, ABS.�n����, ABS.���ڪ��B
FROM     (SELECT  ABS_2.�ݩ�, ABS_2.NOBR AS ���u�s��, ABS_2.YYMM AS �p�~�~��, ABS_2.H_CODE AS ���O�N�X, ABS_2.BDATE AS �а����, 
                               ABS_2.BTIME AS �а��_, ABS_2.ETIME AS �а���, ABS_2.TOL_HOURS AS �а��ɼ�, ABS_2.Guid AS �s��, ABS_2.KEY_MAN AS �n����, 
                               ABS_2.KEY_DATE AS �n����, CAST(CASE WHEN SUM(SALABS.���ڪ��B) > 0 THEN '��' ELSE NULL END AS NVARCHAR(50)) 
                               AS ���ڪ��B
               FROM      (SELECT  '�а�' AS �ݩ�, BDATE, NOBR, YYMM, BTIME, ETIME, TOL_HOURS, Guid, H_CODE, KEY_MAN, KEY_DATE
                               FROM      dbo.ABS AS ABS_1
                               UNION
                               SELECT  '�P��' AS �ݩ�, BDATE, NOBR, YYMM, BTIME, ETIME, TOL_HOURS, GUID, H_CODE, KEY_MAN, KEY_DATE
                               FROM     dbo.ABSC) AS ABS_2 LEFT OUTER JOIN
                                   (SELECT  SALABS_1.NOBR, SALABS_1.ADATE, dbo.SALCODE.SAL_CODE, dbo.SALCODE.SAL_NAME AS ���~���, 
                                                  SALCODE_1.SAL_NAME AS ���ڬ��, dbo.DECODE(SALABS_1.AMT) AS ���ڪ��B
                                   FROM     dbo.SALABS AS SALABS_1 INNER JOIN
                                                  dbo.SALCODE ON SALABS_1.SAL_CODE = dbo.SALCODE.SAL_CODE INNER JOIN
                                                  dbo.SALCODE AS SALCODE_1 ON SALABS_1.MLSSALCODE = SALCODE_1.SAL_CODE) AS SALABS ON 
                               SALABS.NOBR = ABS_2.NOBR AND SALABS.ADATE = ABS_2.BDATE
               GROUP BY ABS_2.�ݩ�, ABS_2.NOBR, ABS_2.YYMM, ABS_2.BDATE, ABS_2.BTIME, ABS_2.ETIME, ABS_2.H_CODE, ABS_2.TOL_HOURS, ABS_2.Guid, 
                               ABS_2.KEY_MAN, ABS_2.KEY_DATE) AS ABS INNER JOIN
               dbo.HCODE ON ABS.���O�N�X = dbo.HCODE.H_CODE INNER JOIN
               dbo.ATTEND ON ABS.���u�s�� = dbo.ATTEND.NOBR AND ABS.�а���� = dbo.ATTEND.ADATE INNER JOIN
               dbo.ROTE ON dbo.ATTEND.ROTE = dbo.ROTE.ROTE INNER JOIN
               dbo.BASE ON ABS.���u�s�� = dbo.BASE.NOBR
WHERE   (dbo.HCODE.FLAG = '-') AND (dbo.HCODE.MANG = '0')
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
         Begin Table = "ABS"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HCODE"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 196
               Right = 562
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ATTEND"
            Begin Extent = 
               Top = 9
               Left = 619
               Bottom = 196
               Right = 838
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTE"
            Begin Extent = 
               Top = 9
               Left = 895
               Bottom = 196
               Right = 1164
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 198
               Left = 57
               Bottom = 385
               Right = 301
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
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_AbsWriteOff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_AbsWriteOff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_AbsWriteOff'
GO


