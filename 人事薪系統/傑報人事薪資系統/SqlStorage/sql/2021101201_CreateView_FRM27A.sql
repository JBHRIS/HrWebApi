/****** Object:  View [dbo].[View_FRM27A]    Script Date: 2021/3/25 �U�� 01:30:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_FRM27A]
AS
SELECT  att.NOBR AS ���u�s��, b.NAME_C AS ���u�m�W, att.ADATE AS �X�Ԥ��, r1.ROTE_DISP AS �Z�O, r1.ROTENAME AS �Z�O�W��, 
               r2.ROTE_DISP AS ����Z�O, r2.ROTENAME AS ����Z�O�W��, ac.TT1 AS �W�Z�ɶ�, ac.TT2 AS �U�Z�ɶ�, ABS1.H_NAME AS ���O�W��, 
               ABS1.BTIME AS �а_�ɶ�, ABS1.ETIME AS �Ш��ɶ�, ABS1.TOL_HOURS AS �а��ɼ�, o.BTIME AS �[�_�ɶ�, o.ETIME AS �[���ɶ�, 
               o.REST_HRS AS �ɥ�ɼ�, att.LATE_MINS AS ���, att.E_MINS AS ���h, att.ABS AS �m¾, att.KEY_MAN AS �n����, att.KEY_DATE AS �n�����
FROM     dbo.ATTEND AS att INNER JOIN
               dbo.BASE AS b ON att.NOBR = b.NOBR INNER JOIN
               dbo.ROTE AS r1 ON att.ROTE = r1.ROTE INNER JOIN
               dbo.ROTE AS r2 ON att.ROTE_H = r2.ROTE LEFT OUTER JOIN
               dbo.ATTCARD AS ac ON att.NOBR = ac.NOBR AND att.ADATE = ac.ADATE LEFT OUTER JOIN
                   (SELECT  dbo.ABS.NOBR, dbo.ABS.BDATE, dbo.ABS.BTIME, dbo.ABS.ETIME, h.H_NAME, dbo.ABS.TOL_HOURS
                   FROM     dbo.ABS INNER JOIN
                                  dbo.HCODE AS h ON dbo.ABS.H_CODE = h.H_CODE
                   WHERE   (h.FLAG = '-')) AS ABS1 ON att.NOBR = ABS1.NOBR AND att.ADATE = ABS1.BDATE LEFT OUTER JOIN
               dbo.OT AS o ON att.NOBR = o.NOBR AND att.ADATE = o.BDATE
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
         Begin Table = "att"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 196
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 9
               Left = 333
               Bottom = 196
               Right = 577
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "r1"
            Begin Extent = 
               Top = 9
               Left = 634
               Bottom = 196
               Right = 903
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "r2"
            Begin Extent = 
               Top = 9
               Left = 960
               Bottom = 196
               Right = 1229
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ac"
            Begin Extent = 
               Top = 198
               Left = 57
               Bottom = 385
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ABS1"
            Begin Extent = 
               Top = 198
               Left = 333
               Bottom = 385
               Right = 552
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "o"
            Begin Extent = 
               Top = 198
               Left = 609
               Bottom = 385
               Right = 894
            End
            DisplayFlags = 280
            TopColumn = 0
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FRM27A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FRM27A'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_FRM27A'
GO


