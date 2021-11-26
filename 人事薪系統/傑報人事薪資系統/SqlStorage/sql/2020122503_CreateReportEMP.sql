/****** Object:  View [dbo].[ReportEMP]    Script Date: 2020/9/8 �U�� 02:48:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ReportEMP]
AS
SELECT          dbo.BASE.NOBR AS ���u�s��, dbo.BASE.NAME_C AS ���u�m�W, dbo.BASE.NAME_E AS �^��m�W, 
                            dbo.BASE.NAME_P AS �@�өm�W, dbo.BASE.SEX AS �ʧO, dbo.BASE.BIRDT AS �X�ͤ��, 
                            dbo.BASE.ADDR1 AS �q�T�a�}, dbo.BASE.ADDR2 AS ���y�a�}, dbo.BASE.TEL1 AS �q�T�q��, 
                            dbo.BASE.TEL2 AS ���y�q��, dbo.BASE.EMAIL AS �q�l�l��, dbo.BASE.GSM AS ��ʹq��, 
                            dbo.BASE.IDNO AS �����Ҹ�, dbo.BASE.CONT_MAN AS �s���H1�m�W, dbo.BASE.CONT_TEL AS �s���H1�q��, 
                            dbo.BASE.CONT_GSM AS �s���H1��ʹq��, dbo.BASE.CONT_MAN2 AS �s���H2�m�W, 
                            dbo.BASE.CONT_TEL2 AS �s���H2�q��, dbo.BASE.CONT_GSM2 AS �s���H2��ʹq��, dbo.BASE.BLOOD AS �嫬, 
                            dbo.BASE.PASSWORD AS �K�X, dbo.BASE.POSTCODE1 AS �q�T�l���ϸ�, dbo.BASE.POSTCODE2 AS ���y�l���ϸ�, 
                            dbo.BASE.BANK_CODE AS ��b�Ȧ�, dbo.BASE.ACCOUNT_NO AS ��b�b��, dbo.BASE.MARRY AS �B��, 
                            dbo.BASE.COUNTRY AS ���y, dbo.BASE.COUNT_MA AS �~�y���u, dbo.BASE.ARMY AS �L��, 
                            dbo.BASE.PRO_MAN1 AS �O�ҤH1�m�W, dbo.BASE.PRO_ADDR1 AS �O�ҤH1��}, 
                            dbo.BASE.PRO_ID1 AS �O�ҤH1�����Ҹ�, dbo.BASE.PRO_TEL1 AS �O�ҤH1�q��, 
                            dbo.BASE.PRO_MAN2 AS �O�ҤH2�m�W, dbo.BASE.PRO_ADDR2 AS �O�ҤH2��}, 
                            dbo.BASE.PRO_ID2 AS �O�ҤH2�����Ҹ�, dbo.BASE.PRO_TEL2 AS �O�ҤH2�q��, dbo.BASE.NOBR_B AS ���ФH, 
                            dbo.BASE.PROVINCE AS �X�ͦa, dbo.BASE.TAXCNT AS �߾i�H��, dbo.BASE.TAXNO AS �@�Ӹ��X, 
                            dbo.BASE.PRETAX AS �ұo�|�w�����B, dbo.BASE.CONT_REL1 AS �s���H1���Y, 
                            dbo.BASE.CONT_REL2 AS �s���H2���Y, dbo.BASE.ACCOUNT_MA AS �~�ұb��, dbo.BASE.MATNO AS �~�d�Ҹ�, 
                            dbo.BASE.SUBTEL AS ����, dbo.BASE.BASECD AS �����O, dbo.BASE.NAME_AD AS AD�b��, 
                            dbo.BASE.AdditionNO AS �W�ɳ渹, dbo.BASE.Introductor, dbo.BASETTS.ADATE AS ���ʥͮĤ�, 
                            dbo.BASETTS.TTSCODE AS ���ʪ��A, dbo.BASETTS.DDATE AS ���ʥ��Ĥ�, dbo.BASETTS.INDT AS ���q��¾��, 
                            dbo.BASETTS.CINDT AS ���Ψ�¾��, dbo.BASETTS.OUDT AS ��¾��, dbo.BASETTS.OUTCD AS ��¾��]�N�X, 
                            dbo.OUTCD.OUTNAME AS ��¾��]�W��, dbo.BASETTS.STDT AS ���~���, dbo.BASETTS.STINDT AS ���_���, 
                            dbo.BASETTS.STOUDT AS �������, dbo.BASETTS.COMP AS ���q�O, dbo.BASETTS.CARD AS ��d, 
                            dbo.BASETTS.DI AS ������, dbo.BASETTS.MANG AS �����D��, dbo.BASETTS.WK_YRS AS �~���~��, 
                            dbo.BASETTS.SALTP AS �~�O�N�X, dbo.SALTYCD.SALTYNAME AS �~�O�W��, dbo.BASETTS.CALABS AS ���p��а�, 
                            dbo.BASETTS.FULATT AS ���p��u�@����, dbo.BASETTS.NOTER AS ���P�_��즭�h, 
                            dbo.BASETTS.NOWEL AS ���p��֧Q��, dbo.BASETTS.NORET AS ���p��h����s��, 
                            dbo.BASETTS.NOOT AS �����ͥ[�Z, dbo.BASETTS.NOSPEC AS ���p��S��N��, 
                            dbo.BASETTS.NOCARD AS ���p��ұo�|, dbo.BASETTS.NOEAT AS �i�ӽиɥ�, dbo.BASETTS.MENO AS ���ʳƵ�, 
                            dbo.BASETTS.SALADR AS ��Ƹs�եN�X, dbo.DATAGROUP.GROUPNAME AS ��Ƹs�զW��, 
                            dbo.BASETTS.NOWAGE AS ���o�~, dbo.BASETTS.MANGE AS �i�������H�Ƹ��, 
                            dbo.BASETTS.RETRATE AS ���u�Ұh������v, dbo.BASETTS.RETDATE AS �Ұh�s����, 
                            dbo.BASETTS.RETCHOO AS �h������, dbo.BASETTS.RETDATE1 AS �Ұh�s�����, 
                            dbo.BASETTS.ONLYONTIME AS �u��W�Z�d, dbo.BASETTS.COUNT_PASS AS �i�u�W��d, 
                            dbo.BASETTS.MANG1 AS �i�N�ӽЪ��, dbo.BASETTS.AP_DATE AS �եδ�����, 
                            dbo.BASETTS.TAX_DATE AS �~�d���_�l��, dbo.BASETTS.TAX_EDATE AS �~�d�������, 
                            dbo.BASETTS.NOSPAMT AS ���p��T�`����, dbo.BASETTS.FIXRATE AS �ұo�|�T�w�|�v��ú, 
                            dbo.DEPT.D_NO_DISP AS �s����N�X, dbo.DEPT.D_NAME AS �s����W��, 
                            dbo.DEPTA.D_NO_DISP AS ñ�ֳ����N�X, dbo.DEPTA.D_NAME AS ñ�ֳ����W��, 
                            dbo.DEPTS.D_NO_DISP AS ���������N�X, dbo.DEPTS.D_NAME AS ���������W��, dbo.JOB.JOB_DISP AS ¾�٥N�X, 
                            dbo.JOB.JOB_NAME AS ¾�٦W��, dbo.JOBL.JOBL_DISP AS ¾���N�X, dbo.JOBL.JOB_NAME AS ¾���W��, 
                            dbo.BASETTS.WORKCD AS �u�@�a�N�X, dbo.WORKCD.WORK_ADDR AS �u�@�a�W��, 
                            dbo.JOBS.JOBS_DISP AS ¾���N�X, dbo.JOBS.JOB_NAME AS ¾���W��, dbo.JOBO.JOBO AS ¾�ťN�X, 
                            dbo.JOBO.JOB_NAME AS ¾�ŦW��, dbo.TTSCD.TTSCD_DISP AS ���ʭ�]�N�X, 
                            dbo.TTSCD.TTSNAME AS ���ʭ�]�W��, dbo.ROTET.ROTET_DISP AS ���Z�O�N�X, 
                            dbo.ROTET.ROTETNAME AS ���Z�O�W��, dbo.HOLICD.HOLI_CODE_DISP AS ��ƾ�N�X, 
                            dbo.HOLICD.HOLI_NAME AS ��ƾ�W��, dbo.BASETTS.EMPCD AS ���O�N�X, dbo.EMPCD.EMPDESCR AS ���O�W��, 
                            dbo.BASETTS.CALOT AS �[�Z��v�N�X, dbo.OTRATECD.OTRATE_NAME AS �[�Z��v�W��
FROM              dbo.BASE INNER JOIN
                            dbo.BASETTS ON dbo.BASE.NOBR = dbo.BASETTS.NOBR LEFT OUTER JOIN
                            dbo.DEPT ON dbo.BASETTS.DEPT = dbo.DEPT.D_NO LEFT OUTER JOIN
                            dbo.DEPTA ON dbo.BASETTS.DEPTM = dbo.DEPTA.D_NO LEFT OUTER JOIN
                            dbo.DEPTS ON dbo.BASETTS.DEPTS = dbo.DEPTS.D_NO LEFT OUTER JOIN
                            dbo.JOB ON dbo.BASETTS.JOB = dbo.JOB.JOB LEFT OUTER JOIN
                            dbo.JOBO ON dbo.BASETTS.JOBO = dbo.JOB.JOB LEFT OUTER JOIN
                            dbo.JOBL ON dbo.BASETTS.JOBL = dbo.JOBL.JOBL LEFT OUTER JOIN
                            dbo.JOBS ON dbo.BASETTS.JOBS = dbo.JOBS.JOBS LEFT OUTER JOIN
                            dbo.WORKCD ON dbo.BASETTS.WORKCD = dbo.WORKCD.WORK_CODE LEFT OUTER JOIN
                            dbo.TTSCD ON dbo.BASETTS.TTSCD = dbo.TTSCD.TTSCD LEFT OUTER JOIN
                            dbo.ROTET ON dbo.BASETTS.ROTET = dbo.ROTET.ROTET LEFT OUTER JOIN
                            dbo.EMPCD ON dbo.BASETTS.EMPCD = dbo.EMPCD.EMPCD LEFT OUTER JOIN
                            dbo.OUTCD ON dbo.BASETTS.OUTCD = dbo.OUTCD.OUTCD LEFT OUTER JOIN
                            dbo.HOLICD ON dbo.BASETTS.HOLI_CODE = dbo.HOLICD.HOLI_CODE LEFT OUTER JOIN
                            dbo.OTRATECD ON dbo.BASETTS.CALOT = dbo.OTRATECD.OTRATE_CODE LEFT OUTER JOIN
                            dbo.DATAGROUP ON dbo.BASETTS.SALADR = dbo.DATAGROUP.DATAGROUP LEFT OUTER JOIN
                            dbo.SALTYCD ON dbo.BASETTS.SALTP = dbo.SALTYCD.SALTYCD
WHERE          (dbo.today() BETWEEN dbo.BASETTS.ADATE AND dbo.BASETTS.DDATE)


GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[14] 2[27] 3) )"
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
         Top = -125
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASETTS"
            Begin Extent = 
               Top = 6
               Left = 268
               Bottom = 136
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPT"
            Begin Extent = 
               Top = 6
               Left = 492
               Bottom = 136
               Right = 659
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTA"
            Begin Extent = 
               Top = 6
               Left = 697
               Bottom = 136
               Right = 864
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DEPTS"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOB"
            Begin Extent = 
               Top = 138
               Left = 241
               Bottom = 268
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBO"
            Begin Extent = 
               Top = 269
               Left = 38
               Bottom = 399
               Right = 203
            End
            DisplayFlags = 280
            TopCo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'lumn = 0
         End
         Begin Table = "JOBL"
            Begin Extent = 
               Top = 138
               Left = 444
               Bottom = 268
               Right = 609
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JOBS"
            Begin Extent = 
               Top = 138
               Left = 647
               Bottom = 268
               Right = 812
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WORKCD"
            Begin Extent = 
               Top = 138
               Left = 850
               Bottom = 268
               Right = 1015
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TTSCD"
            Begin Extent = 
               Top = 269
               Left = 241
               Bottom = 399
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ROTET"
            Begin Extent = 
               Top = 269
               Left = 444
               Bottom = 399
               Right = 626
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EMPCD"
            Begin Extent = 
               Top = 269
               Left = 664
               Bottom = 399
               Right = 829
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "HOLICD"
            Begin Extent = 
               Top = 269
               Left = 867
               Bottom = 399
               Right = 1054
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OTRATECD"
            Begin Extent = 
               Top = 401
               Left = 38
               Bottom = 531
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DATAGROUP"
            Begin Extent = 
               Top = 401
               Left = 281
               Bottom = 531
               Right = 450
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SALTYCD"
            Begin Extent = 
               Top = 401
               Left = 488
               Bottom = 531
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CostType"
            Begin Extent = 
               Top = 401
               Left = 691
               Bottom = 531
               Right = 868
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OUTCD"
            Begin Extent = 
               Top = 533
               Left = 38
               Bottom = 663
               Right = 203
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
      Begin ColumnWidths = 9
         Width = 284
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
         S' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane3', @value=N'ortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=3 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReportEMP'
GO


