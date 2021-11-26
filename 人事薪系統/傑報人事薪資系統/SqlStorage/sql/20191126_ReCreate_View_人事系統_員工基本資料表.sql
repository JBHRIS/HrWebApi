Drop view [dbo].[�H�ƨt��_���u�򥻸�ƪ�]
GO

/****** Object:  View [dbo].[�H�ƨt��_���u�򥻸�ƪ�]    Script Date: 2019/11/26 �W�� 11:00:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[�H�ƨt��_���u�򥻸�ƪ�]
AS
SELECT  TOP (100) 
               PERCENT (CASE b.ttscode WHEN '1' THEN '�b¾' WHEN '4' THEN '�b¾' WHEN '6' THEN '�b¾' WHEN '3' THEN '�d¾���~' WHEN '5' THEN '����' WHEN '2' THEN
                '��¾' END) AS ���A, a.NOBR AS �u��, a.NAME_C AS ���u�m�W, a.NAME_E AS �^��m�W, a.IDNO AS �����Ҹ�, a.BIRDT AS �X�ͤ��, DATEDIFF(d, 
               a.BIRDT, GETDATE()) / 365 AS �~��, a.SEX AS �ʧO, a.BLOOD AS �嫬, a.MARRY AS �ñB, a.TAXNO AS �@�Ӹ��X, a.MATNO AS �~�d�Ҹ�, 
               a.BASECD AS �����O, a.COUNTRY AS ���y, a.GSM AS ��ʹq��, a.TEL1 AS as�q�T�q��, a.POSTCODE1 AS �q�T�l���ϸ�, a.ADDR1 AS �q�T�a�}, 
               a.TEL2 AS ���y�q��, a.POSTCODE2 AS ���y�l���ϸ�, a.ADDR2 AS ���y�a�}, b.DI AS ������, b.TTSCODE AS ���ʪ��A, b.INDT AS ��¾���, 
               dbo.GetTotalYears(a.NOBR, GETDATE()) AS �~��, b.OUDT AS ��¾���, b.STDT AS ���~���, b.STINDT AS ���_���, b.AP_DATE AS �եδ�����, 
               b.DEPT AS �����N�X, c.D_NAME AS �����W��, b.DEPTS AS ���������N�X, d.D_NAME AS ���������W��, b.JOB AS ¾�٥N�X, e.JOB_NAME AS ¾��, 
               b.JOBL AS ¾���N�X, f.JOB_NAME AS ¾���W��, b.ROTET AS �Z�O, b.TAX_DATE AS �~�d�Ұ_�l��, b.TAX_EDATE AS �~�d�Ҩ����, 
               a.BANKNO AS ��b�渹, a.ACCOUNT_NO AS ��b�b��, a.TAXCNT AS �߾i�H��, b.MENO AS �Ƶ�, dbo.COMP.COMPNAME AS ���q�W��, 
               b.JOBS AS ¾���N�X, dbo.JOBS.JOB_NAME AS ¾���W��, b.EMPCD AS ���O�N�X, dbo.EMPCD.EMPDESCR AS ���O����, ISNULL(b.OUTCD, N'') 
               AS ��¾��]�N�X, ISNULL(dbo.OUTCD.OUTNAME, N'') AS ��¾��], b.TTSCD AS ���ʭ�]�N�X, dbo.TTSCD.TTSNAME AS ���ʭ�], 
               dbo.WORKCD.WORK_ADDR AS �u�@�a, b.ADATE AS ���ʥͮĤ�, b.DDATE AS ���ʥ��Ĥ�
FROM     dbo.BASE AS a INNER JOIN
               dbo.BASETTS AS b LEFT OUTER JOIN
               dbo.DEPT AS c ON b.DEPT = c.D_NO LEFT OUTER JOIN
               dbo.DEPTS AS d ON b.DEPTS = d.D_NO LEFT OUTER JOIN
               dbo.JOB AS e ON b.JOB = e.JOB LEFT OUTER JOIN
               dbo.JOBL AS f ON b.JOBL = f.JOBL ON a.NOBR = b.NOBR LEFT OUTER JOIN
               dbo.WORKCD ON b.WORKCD = dbo.WORKCD.WORK_CODE LEFT OUTER JOIN
               dbo.TTSCD ON b.TTSCD = dbo.TTSCD.TTSCD LEFT OUTER JOIN
               dbo.OUTCD ON b.OUTCD = dbo.OUTCD.OUTCD LEFT OUTER JOIN
               dbo.EMPCD ON b.EMPCD = dbo.EMPCD.EMPCD LEFT OUTER JOIN
               dbo.COMP ON b.COMP = dbo.COMP.COMP LEFT OUTER JOIN
               dbo.JOBS ON b.JOBS = dbo.JOBS.JOBS
WHERE   (dbo.Today() BETWEEN b.ADATE AND b.DDATE)
ORDER BY ��¾��� DESC
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[36] 4[27] 2[21] 3) )"
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
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 446
               Bottom = 125
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 650
               Bottom = 125
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "f"
            Begin Extent = 
               Top = 126
               Left = 242
               Bottom = 245
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WORKCD"
            Begin Extent = 
               Top = 246
               Left = 650
               Bottom = 365
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'�H�ƨt��_���u�򥻸�ƪ�'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
         Begin Table = "TTSCD"
            Begin Extent = 
               Top = 126
               Left = 446
               Bottom = 245
               Right = 612
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OUTCD"
            Begin Extent = 
               Top = 126
               Left = 650
               Bottom = 245
               Right = 816
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EMPCD"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 246
               Left = 242
               Bottom = 365
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBS"
            Begin Extent = 
               Top = 246
               Left = 446
               Bottom = 365
               Right = 612
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
      Begin ColumnWidths = 54
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'�H�ƨt��_���u�򥻸�ƪ�'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'�H�ƨt��_���u�򥻸�ƪ�'
GO


