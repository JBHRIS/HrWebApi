/****** Object:  Table [dbo].[MenuGroup]    Script Date: 2019/12/6 上午 10:02:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuGroup](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[MenuGroupID] [uniqueidentifier] NOT NULL,
	[MenuGroupName] [nvarchar](50) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[Key_Man] [nvarchar](50) NULL,
	[Key_Date] [datetime] NULL,
 CONSTRAINT [PK_MenuGroup] PRIMARY KEY CLUSTERED 
(
	[MenuGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

alter table COMP ADD MenuGroupID uniqueidentifier
GO

/****** Object:  Table [dbo].[MenuStripStructure]    Script Date: 2019/12/11 下午 05:09:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuStripStructure](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[MenuStripID] [uniqueidentifier] NOT NULL,
	[MenuStripName] [nvarchar](50) NOT NULL,
	[MenuStripText] [nvarchar](50) NOT NULL,
	[ParentID] [uniqueidentifier] NULL,
	[ItemIndex] [int] NOT NULL,
	[CommonItem] [BIT] NOT NULL,
	[ShortcutKeys] [nvarchar](50) NULL,
	[Visible][BIT] NOT NULL,
	[AssemblyName] [nvarchar](50) NULL,
	[Key_Man] [nvarchar](50) NULL,
	[Key_Date] [datetime] NULL,
	[MenuGroupID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_MenuStripStructure] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT [dbo].[jqSetting] ( [QuerySetting], [QueryName], [SourceType], [ConnectString], [Memo], [CreateMan], [CreateDate], [Sort], [PageSize], [CustomerWhere]) VALUES ( N'MenuMgt', N'選單管理', N'SQL', N'MenuGroup', N'', N'', GETDATE(), 1, 1000, N'')
INSERT [dbo].[jqSetting] ( [QuerySetting], [QueryName], [SourceType], [ConnectString], [Memo], [CreateMan], [CreateDate], [Sort], [PageSize], [CustomerWhere]) VALUES ( N'MenuGroupForComp', N'公司選單管理', N'SQL', N'COMP', N'', N'',GETDATE(), 1, 1000, N'')
GO

DECLARE @MenuGroupID int,@MenuGroupForCompID int
SET @MenuGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'MenuMgt')
SET @MenuGroupForCompID =  (select ID FROM jqSetting WHERE QuerySetting = 'MenuGroupForComp')
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@MenuGroupID, N'MenuGroup', N'MenuGroup', N'', N'', GETDATE())
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@MenuGroupForCompID, N'COMP', N'COMP', N'', N'', GETDATE())
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@MenuGroupForCompID, N'MenuGroup', N'MenuGroup', N'', N'', GETDATE())
GO

DECLARE @MenuGroupID int,@MenuGroupForCompID int
SET @MenuGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'MenuMgt')
SET @MenuGroupForCompID =  (select ID FROM jqSetting WHERE QuerySetting = 'MenuGroupForComp')
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 1, N'MenuGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 2, N'MenuGroup', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 1, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 3, N'MenuGroup', N'MenuGroupName', N'群組名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 4, N'MenuGroup', N'Note', N'備註', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 5, N'MenuGroup', N'Key_Man', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupID, 6, N'MenuGroup', N'Key_Date', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 1, N'COMP', N'COMP', N'公司代碼', 1, N'nvarchar', 1, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 2, N'COMP', N'COMPNAME', N'公司名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 4, N'COMP', N'CHAIRMAN', N'CHAIRMAN', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 5, N'COMP', N'COMPID', N'COMPID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 6, N'COMP', N'TEL', N'TEL', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 7, N'COMP', N'FAX', N'FAX', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 8, N'COMP', N'ADDR', N'ADDR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 9, N'COMP', N'HOUSEID', N'HOUSEID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 10, N'COMP', N'KEY_MAN', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 11, N'COMP', N'KEY_DATE', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 12, N'COMP', N'F0103', N'F0103', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 13, N'COMP', N'F0407', N'F0407', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 14, N'COMP', N'WORKCD', N'WORKCD', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 15, N'COMP', N'TAXID', N'TAXID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 16, N'COMP', N'ACCOUNT', N'ACCOUNT', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 17, N'COMP', N'ACCR', N'ACCR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 18, N'COMP', N'DEFA', N'DEFA', 0, N'bit', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 19, N'COMP', N'INSCOMP', N'INSCOMP', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 20, N'COMP', N'SORT', N'SORT', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 21, N'COMP', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 0, N'MenuGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 0, N'MenuGroup', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 3, N'MenuGroup', N'MenuGroupName', N'選單群組', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 0, N'MenuGroup', N'Note', N'Note', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 0, N'MenuGroup', N'Key_Man', N'Key_Man', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, 0, N'MenuGroup', N'Key_Date', N'Key_Date', 0, N'datetime', 0, N'', N'', N'', GETDATE())
GO

DECLARE @MenuGroupID int,@MenuGroupForCompID int
SET @MenuGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'MenuMgt')
SET @MenuGroupForCompID = (select ID FROM jqSetting WHERE QuerySetting = 'MenuGroupForComp')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 1, N'MenuGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 2, N'MenuGroup', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 3, N'MenuGroup', N'MenuGroupName', N'選單群組', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 4, N'MenuGroup', N'Note', N'備註', 1, N'ntext', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 5, N'MenuGroup', N'Key_Man', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupID, 6, N'MenuGroup', N'Key_Date', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 2, N'COMP', N'COMP', N'公司代碼', 1, N'nvarchar', 1, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 3, N'COMP', N'COMPNAME', N'公司名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 4, N'COMP', N'CHAIRMAN', N'CHAIRMAN', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 5, N'COMP', N'COMPID', N'COMPID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 6, N'COMP', N'TEL', N'TEL', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 7, N'COMP', N'FAX', N'FAX', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 8, N'COMP', N'ADDR', N'ADDR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 9, N'COMP', N'HOUSEID', N'HOUSEID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 10, N'COMP', N'KEY_MAN', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 11, N'COMP', N'KEY_DATE', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 12, N'COMP', N'F0103', N'F0103', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 13, N'COMP', N'F0407', N'F0407', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 14, N'COMP', N'WORKCD', N'WORKCD', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 15, N'COMP', N'TAXID', N'TAXID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 16, N'COMP', N'ACCOUNT', N'ACCOUNT', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 17, N'COMP', N'ACCR', N'ACCR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 18, N'COMP', N'DEFA', N'DEFA', 0, N'bit', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 19, N'COMP', N'INSCOMP', N'INSCOMP', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 20, N'COMP', N'SORT', N'SORT', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 21, N'COMP', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 1, N'MenuGroup', N'MenuGroupName', N'選單群組', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 0, N'MenuGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 0, N'MenuGroup', N'MenuGroupID', N'MenuGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 0, N'MenuGroup', N'Note', N'Note', 0, N'ntext', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 0, N'MenuGroup', N'KeyMan', N'KeyMan', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@MenuGroupForCompID, 0, N'MenuGroup', N'KeyDate', N'KeyDate', 0, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
GO
 
DECLARE @MenuGroupForCompID int, @ParentID1 int,@ParentID2 int
SET @MenuGroupForCompID = (select ID FROM jqSetting WHERE QuerySetting = 'MenuGroupForComp')
SET @ParentID1 = (Select ID FROM jqColumn WHERE TableName = 'MenuGroup' AND ColumnName = 'MenuGroupID' AND SettingID = @MenuGroupForCompID)
SET @ParentID2 = (Select ID FROM jqColumn WHERE TableName = 'COMP' AND ColumnName ='MenuGroupID' AND SettingID = @MenuGroupForCompID)
INSERT [dbo].[jqForeignKey] ([SettingID], [ParentID], [ParentTable], [ParentColumn], [ChildID], [ChildTable], [ChildColumn], [CreateMan], [CreateDate]) VALUES ( @MenuGroupForCompID, @ParentID1, N'MenuGroup', N'MenuGroupID', @ParentID2, N'COMP', N'MenuGroupID', N'', GETDATE())
GO