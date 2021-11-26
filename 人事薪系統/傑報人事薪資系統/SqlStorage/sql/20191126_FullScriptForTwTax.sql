
/****** Object:  Table [dbo].[TW_TAX]    Script Date: 2017/12/18 下午 04:09:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TW_TAX](
	[AUTO] [int] IDENTITY(1,1) NOT NULL,
	[Subject] [nvarchar](100) NOT NULL,
	[YearMonth] [nvarchar](50) NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[Remark] [nvarchar](1000) NOT NULL,
	[Key_Date] [datetime] NOT NULL,
	[Key_Man] [nvarchar](50) NOT NULL,
	[IsLock] [bit] NOT NULL,
	[RelaseDate] [datetime] NULL,
 CONSTRAINT [PK_YearTaxSetting] PRIMARY KEY CLUSTERED 
(
	[AUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TW_TAX_ITEM]    Script Date: 2017/12/18 下午 04:09:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TW_TAX_ITEM](
	[AUTO] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[YYMM] [nvarchar](50) NOT NULL,
	[SEQ] [nvarchar](50) NOT NULL,
	[SAL_CODE] [nvarchar](50) NOT NULL,
	[AMT] [decimal](16, 2) NOT NULL,
	[D_AMT] [decimal](16, 2) NOT NULL,
	[TR_TYPE] [nvarchar](50) NOT NULL,
	[FORMAT] [nvarchar](50) NOT NULL,
	[MEMO] [nvarchar](500) NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[INA_ID] [nvarchar](50) NOT NULL,
	[TAXNO] [nvarchar](50) NOT NULL,
	[SUBCODE] [int] NOT NULL,
	[FORSUB] [nvarchar](50) NOT NULL,
	[COMP] [nvarchar](50) NOT NULL,
	[SUP_AMT] [decimal](16, 2) NOT NULL,
	[IMPORT] [bit] NOT NULL,
	[RET_AMT] [decimal](16, 2) NOT NULL,
	[IS_FILE] [bit] NOT NULL,
 CONSTRAINT [PK_TW_TAX_ITEM] PRIMARY KEY CLUSTERED 
(
	[AUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TW_TAX_SUBCODE]    Script Date: 2017/12/18 下午 04:09:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TW_TAX_SUBCODE](
	[AUTO] [int] IDENTITY(1,1) NOT NULL,
	[M_FORMAT] [nvarchar](50) NOT NULL,
	[M_FORSUB] [nvarchar](50) NOT NULL,
	[M_SUB_NAME] [nvarchar](50) NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TW_TAX_SUBCODE] PRIMARY KEY CLUSTERED 
(
	[AUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[TW_TAX_SUMMARY]    Script Date: 2017/12/18 下午 04:09:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TW_TAX_SUMMARY](
	[AUTO] [int] IDENTITY(1,1) NOT NULL,
	[PID] [int] NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[AMT] [decimal](16, 2) NOT NULL,
	[D_AMT] [decimal](16, 2) NOT NULL,
	[FORMAT] [nvarchar](50) NOT NULL,
	[MEMO] [nvarchar](500) NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[TAXNO] [nvarchar](50) NOT NULL,
	[SUBCODE] [int] NOT NULL,
	[FORSUB] [nvarchar](50) NOT NULL,
	[COMP] [nvarchar](50) NOT NULL,
	[SUP_AMT] [decimal](16, 2) NOT NULL,
	[IMPORT] [bit] NOT NULL,
	[RET_AMT] [decimal](16, 2) NOT NULL,
	[IS_FILE] [bit] NOT NULL,
	[POST2] [nvarchar](50) NOT NULL,
	[ADDR2] [nvarchar](50) NOT NULL,
	[NAME_C] [nvarchar](50) NOT NULL,
	[ID] [nvarchar](50) NOT NULL,
	[SERIES] [nvarchar](50) NOT NULL,
	[IDCODE] [nvarchar](50) NOT NULL,
	[ID1] [nvarchar](50) NOT NULL,
	[F0103] [nvarchar](50) NOT NULL,
	[F0407] [nvarchar](50) NOT NULL,
	[ERROR] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_TW_TAX_SUMMARY] PRIMARY KEY CLUSTERED 
(
	[AUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_AMT]  DEFAULT ((0)) FOR [AMT]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_D_AMT]  DEFAULT ((0)) FOR [D_AMT]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_TR_TYPE]  DEFAULT ('') FOR [TR_TYPE]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_FORMAT]  DEFAULT ('') FOR [FORMAT]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_Table_1_MENO]  DEFAULT ('') FOR [MEMO]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_INA_ID]  DEFAULT ('') FOR [INA_ID]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_TAXNO]  DEFAULT ('') FOR [TAXNO]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_SUBCODE]  DEFAULT ('') FOR [SUBCODE]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_FORSUB]  DEFAULT ('') FOR [FORSUB]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_COMP]  DEFAULT ('') FOR [COMP]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_RET_AMT]  DEFAULT ((0)) FOR [RET_AMT]
GO

ALTER TABLE [dbo].[TW_TAX_ITEM] ADD  CONSTRAINT [DF_TW_TAX_ITEM_IS_SELF]  DEFAULT ((0)) FOR [IS_FILE]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_AMT]  DEFAULT ((0)) FOR [AMT]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_D_AMT]  DEFAULT ((0)) FOR [D_AMT]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_FORMAT]  DEFAULT ('') FOR [FORMAT]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_MEMO]  DEFAULT ('') FOR [MEMO]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_TAXNO]  DEFAULT ('') FOR [TAXNO]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_SUBCODE]  DEFAULT ('') FOR [SUBCODE]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_FORSUB]  DEFAULT ('') FOR [FORSUB]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_COMP]  DEFAULT ('') FOR [COMP]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_RET_AMT]  DEFAULT ((0)) FOR [RET_AMT]
GO

ALTER TABLE [dbo].[TW_TAX_SUMMARY] ADD  CONSTRAINT [DF_TW_TAX_SUMMARY_IS_FILE]  DEFAULT ((0)) FOR [IS_FILE]
GO


-- `dbo.TW_TAX_SUBCODE`
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9B ', N'98 ', N'非自行出版之稿費、版稅、樂譜、', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9B ', N'99 ', N'自行出版之稿費、版稅、作曲、編', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'90 ', N'其他                          ', N'楊康平  ', '20120111 09:15:12:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'94 ', N'未具律師資格，辦理訴訟代理人業', N'許名瑤  ', '20170522 17:09:28:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'95 ', N'未具建築師資格，辦理建築規劃設', N'許名瑤  ', '20170522 17:09:53:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'96 ', N'未具地政士資格，辦理土地登記等', N'許名瑤  ', '20170522 17:10:21:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'97 ', N'受大陸地區人民委託辦理繼承、公', N'許名瑤  ', '20170522 17:10:41:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'91 ', N'商標代理人                    ', N'許名瑤  ', '20170522 17:11:23:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'92 ', N'程式設計師                    ', N'許名瑤  ', '20170522 17:11:50:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'9A ', N'93 ', N'專利代理人                    ', N'許名瑤  ', '20170522 17:12:18:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'80 ', N'汽車駕駛訓練補習班            ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'81 ', N'文理、升學、語文、法商職業補習', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'82 ', N'縫紉、美容、美髮、音樂、舞蹈技', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'83 ', N'私立托兒所                    ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'84 ', N'私立幼稚園                    ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'85 ', N'托育中心                      ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'86 ', N'安親班                        ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'87 ', N'私立養護、療養院所            ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'88 ', N'私立護理機構及依老人福利機構設', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8A ', N'職工福利金                    ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8B ', N'違約金                        ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8C ', N'佃農因終止375租約取得之補償費 ', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8D ', N'個人遷讓非自有房屋、土地所取得', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8E ', N'多層次傳銷參加人直接進貨取得之', N' 許名瑤 ', '20071212 00:00:00:000')
INSERT dbo.TW_TAX_SUBCODE (M_FORMAT, M_FORSUB, M_SUB_NAME, KEY_MAN, KEY_DATE) VALUES (N'92 ', N'8Z ', N'其他                          ', N' 許名瑤 ', '20071212 00:00:00:000')


BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
GO

BEGIN TRANSACTION
GO
ALTER TABLE dbo.TBASE ADD
	SALADR nvarchar(50) NULL
GO
ALTER TABLE dbo.TBASE SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
GO

BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
GO

BEGIN TRANSACTION
GO
ALTER TABLE dbo.TBASE ADD
	TAXNO nvarchar(50) NOT NULL CONSTRAINT DF_TBASE_TAXNO DEFAULT ''
GO
ALTER TABLE dbo.TBASE SET (LOCK_ESCALATION = TABLE)
GO

COMMIT
GO


/****** Object:  View [dbo].[View_TW_TAX]    Script Date: 2018/1/4 上午 09:42:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_TW_TAX]
AS
SELECT          AUTO AS 編號, Subject AS 標題, YearMonth AS 年月, DateBegin AS 起始日期, DateEnd AS 結束日期, 
                            Remark AS 備註, Key_Date AS 登錄日期, Key_Man AS 登錄者, IsLock AS 鎖檔, 
                            RelaseDate AS 啟用查詢日期
FROM              dbo.TW_TAX
GO

/****** Object:  View [dbo].[View_TW_TAX_ITEM]    Script Date: 2018/1/4 上午 09:42:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_TW_TAX_ITEM]
AS
SELECT          dbo.TW_TAX_ITEM.AUTO AS 編號, dbo.TW_TAX_ITEM.PID, dbo.TW_TAX_ITEM.NOBR AS 員工編號, 
                            dbo.TW_TAX_ITEM.YYMM AS 所得年月, dbo.TW_TAX_ITEM.SEQ AS 期別, dbo.TW_TAX_ITEM.SAL_CODE AS 來源, 
                            dbo.TW_TAX_ITEM.AMT AS 給付總額, dbo.TW_TAX_ITEM.D_AMT AS 扣繳稅額, 
                            dbo.TW_TAX_ITEM.FORMAT AS 所得格式, dbo.TW_TAX_ITEM.MEMO AS 備註, 
                            dbo.TW_TAX_ITEM.KEY_MAN AS 登錄者, dbo.TW_TAX_ITEM.KEY_DATE AS 登錄日期, 
                            dbo.TW_TAX_ITEM.TAXNO AS 稅籍編號, dbo.TW_TAX_ITEM.IMPORT AS 匯入, dbo.TW_TAX_ITEM.COMP AS 公司, 
                            dbo.COMP.COMPNAME AS 公司名稱, dbo.BASE.NAME_C AS 員工姓名, 
                            dbo.TW_TAX_ITEM.RET_AMT AS 自提退休金, dbo.TW_TAX_ITEM.IS_FILE AS 已申報, 
                            dbo.TW_TAX_SUBCODE.M_FORMAT AS 所得註記
FROM              dbo.TW_TAX_ITEM INNER JOIN
                            dbo.COMP ON dbo.TW_TAX_ITEM.COMP = dbo.COMP.COMP INNER JOIN
                            dbo.BASE ON dbo.TW_TAX_ITEM.NOBR = dbo.BASE.NOBR LEFT OUTER JOIN
                            dbo.TW_TAX_SUBCODE ON dbo.TW_TAX_ITEM.SUBCODE = dbo.TW_TAX_SUBCODE.AUTO
GO

/****** Object:  View [dbo].[View_TW_TAX_SUMMARY]    Script Date: 2018/1/4 上午 09:42:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_TW_TAX_SUMMARY]
AS
SELECT          dbo.TW_TAX_SUMMARY.AUTO AS 編號, dbo.TW_TAX_SUMMARY.NOBR AS 員工編號, 
                            dbo.TW_TAX_SUMMARY.AMT AS 給付總額, dbo.TW_TAX_SUMMARY.D_AMT AS 扣繳稅額, 
                            dbo.TW_TAX_SUMMARY.FORMAT AS 所得格式, dbo.TW_TAX_SUMMARY.MEMO AS 備註, 
                            dbo.TW_TAX_SUMMARY.KEY_MAN AS 登錄者, dbo.TW_TAX_SUMMARY.KEY_DATE AS 登錄日期, 
                            dbo.TW_TAX_SUMMARY.TAXNO AS 稅籍編號, dbo.TW_TAX_SUMMARY.COMP AS 公司別代碼, 
                            dbo.TW_TAX_SUMMARY.IMPORT AS 匯入, dbo.TW_TAX_SUMMARY.RET_AMT AS 勞退自提, 
                            dbo.TW_TAX_SUMMARY.IS_FILE AS 已申報, dbo.TW_TAX_SUMMARY.POST2 AS 郵遞區號, 
                            dbo.TW_TAX_SUMMARY.ADDR2 AS 戶籍地址, dbo.TW_TAX_SUMMARY.NAME_C AS 員工姓名, 
                            dbo.TW_TAX_SUMMARY.ID AS 身分證號, dbo.TW_TAX_SUMMARY.SERIES AS 流水號, 
                            dbo.TW_TAX_SUMMARY.IDCODE AS 證號別, dbo.TW_TAX_SUMMARY.ID1 AS 公司統編, 
                            dbo.TW_TAX_SUMMARY.F0103 AS 機關別, dbo.TW_TAX_SUMMARY.F0407 AS 媒體代號, 
                            dbo.TW_TAX_SUMMARY.ERROR AS 錯誤註記, dbo.COMP.COMPNAME AS 公司名稱, 
                            dbo.TW_TAX_SUBCODE.M_FORSUB AS 所得註記, dbo.TW_TAX_SUMMARY.PID
FROM              dbo.TW_TAX_SUMMARY INNER JOIN
                            dbo.COMP ON dbo.TW_TAX_SUMMARY.COMP = dbo.COMP.COMP LEFT OUTER JOIN
                            dbo.TW_TAX_SUBCODE ON dbo.TW_TAX_SUMMARY.SUBCODE = dbo.TW_TAX_SUBCODE.AUTO
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
         Begin Table = "TW_TAX"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[35] 4[26] 2[20] 3) )"
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
         Begin Table = "COMP"
            Begin Extent = 
               Top = 6
               Left = 241
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BASE"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 667
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TW_TAX_ITEM"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
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
      Begin ColumnWidths = 13
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX_ITEM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX_ITEM'
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
         Begin Table = "TW_TAX_SUMMARY"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "COMP"
            Begin Extent = 
               Top = 229
               Left = 443
               Bottom = 359
               Right = 618
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TW_TAX_SUBCODE"
            Begin Extent = 
               Top = 82
               Left = 950
               Bottom = 212
               Right = 1121
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
      Begin ColumnWidths = 10
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX_SUMMARY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_TW_TAX_SUMMARY'
GO


