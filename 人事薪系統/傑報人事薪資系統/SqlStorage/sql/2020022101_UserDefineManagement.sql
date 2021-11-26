SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Alter Table COMP Add [UserDefineGroupID] [uniqueidentifier]
GO

CREATE TABLE [dbo].[UserDefineGroup](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[UserDefineGroupID] [uniqueidentifier] NOT NULL,
	[UserDefineGroupName] [nvarchar](50) NULL,
	[Note] [nvarchar](500) NULL,
	[Key_Man] [nvarchar](50) NULL,
	[Key_Date] [datetime] NULL,
	[ColumnCnt] [int] NOT NULL,
	[RowCnt] [int] NOT NULL,
	[ItemsWidth] [int] NOT NULL,
	[ItemsHeight] [int] NOT NULL,
 CONSTRAINT [PK_UserDeFineGroup] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserDefineLayout](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[UserDefineGroupID] [uniqueidentifier] NOT NULL,
	[ControlID] [uniqueidentifier] NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[LayoutColumn] [int] NOT NULL,
	[LayoutRow] [int] NOT NULL,
	[ColumnSpan] [int] NOT NULL,
	[RowSpan] [int] NOT NULL,
	[Anchor] [nvarchar](50) NULL,
	[Dock] [nvarchar](50) NULL,
    [Tag] [nvarchar](MAX) NULL,
	[Visible] [bit] NOT NULL,
	[Key_Man] [nvarchar](50) NULL,
	[Key_Date] [datetime] NULL,
 CONSTRAINT [PK_UserDefineLayout] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserDefineValue](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[NOBR] [nvarchar](50) NOT NULL,
	[ControlID] [uniqueidentifier] NOT NULL,
	[SourceID] [uniqueidentifier] NULL,
	[ValueType] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](50) NULL,
	[Key_Man] [nvarchar](50) NULL,
	[Key_Date] [datetime] NULL,
 CONSTRAINT [PK_UserDefineValue] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[UserDefineSource](
	[AK] [int] IDENTITY(1,1) NOT NULL,
	[SourceID] [uniqueidentifier] NOT NULL,
	[SourceName] [nvarchar](50) NOT NULL,
	[SourceType] [nvarchar](50) NOT NULL,
	[ValueMember] [nvarchar](50) NULL,
	[DisplayMember] [nvarchar](100) NULL,
	[SourceScript] [nvarchar](MAX) NULL,
 CONSTRAINT [PK_UserDefineSource] PRIMARY KEY CLUSTERED 
(
	[AK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[jqSetting] ( [QuerySetting], [QueryName], [SourceType], [ConnectString], [Memo], [CreateMan], [CreateDate], [Sort], [PageSize], [CustomerWhere]) VALUES ( N'UserDefineMgt', '自定義欄位管理', N'SQL', N'UserDefineGroup', N'', N'', GETDATE(), 1, 1000, N'')
INSERT [dbo].[jqSetting] ( [QuerySetting], [QueryName], [SourceType], [ConnectString], [Memo], [CreateMan], [CreateDate], [Sort], [PageSize], [CustomerWhere]) VALUES ( N'UserDefineGroupForComp', '公司自定義欄位管理', N'SQL', N'COMP', N'', N'', GETDATE(), 1, 1000, N'')
GO

DECLARE @UserDefineGroupID int,@UserDefineGroupForCompID int
SET @UserDefineGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineMgt')
SET @UserDefineGroupForCompID =  (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineGroupForComp')
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@UserDefineGroupID, N'UserDefineGroup', N'UserDefineGroup', N'', N'', GETDATE())
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@UserDefineGroupForCompID, N'COMP', N'COMP', N'', N'', GETDATE())
INSERT [dbo].[jqTable] ( [SettingID], [TableName], [DisplayName], [Memo], [CreateMan], [CreateDate]) VALUES (@UserDefineGroupForCompID, N'UserDefineGroup', N'UserDefineGroup', N'', N'', GETDATE())
GO

DECLARE @UserDefineGroupID int,@UserDefineGroupForCompID int
SET @UserDefineGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineMgt')
SET @UserDefineGroupForCompID =  (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineGroupForComp')
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 1, N'UserDefineGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 2, N'UserDefineGroup', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 1, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 3, N'UserDefineGroup', N'UserDefineGroupName', N'群組名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 4, N'UserDefineGroup', N'Note', N'備註', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 5, N'UserDefineGroup', N'Key_Man', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 6, N'UserDefineGroup', N'Key_Date', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 7, N'UserDefineGroup', N'ColumnCnt', N'資料行數', 1, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 8, N'UserDefineGroup', N'RowCnt', N'資料列數', 1, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 9, N'UserDefineGroup', N'ItemsWidth', N'元件寬', 1, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupID, 10, N'UserDefineGroup', N'ItemsHeight', N'元件高', 1, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 1, N'COMP', N'COMP', N'公司代碼', 1, N'nvarchar', 1, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 2, N'COMP', N'COMPNAME', N'公司名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 4, N'COMP', N'CHAIRMAN', N'CHAIRMAN', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 5, N'COMP', N'COMPID', N'COMPID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 6, N'COMP', N'TEL', N'TEL', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 7, N'COMP', N'FAX', N'FAX', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 8, N'COMP', N'ADDR', N'ADDR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 9, N'COMP', N'HOUSEID', N'HOUSEID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 10, N'COMP', N'KEY_MAN', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 11, N'COMP', N'KEY_DATE', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 12, N'COMP', N'F0103', N'F0103', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 13, N'COMP', N'F0407', N'F0407', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 14, N'COMP', N'WORKCD', N'WORKCD', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 15, N'COMP', N'TAXID', N'TAXID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 16, N'COMP', N'ACCOUNT', N'ACCOUNT', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 17, N'COMP', N'ACCR', N'ACCR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 18, N'COMP', N'DEFA', N'DEFA', 0, N'bit', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 19, N'COMP', N'INSCOMP', N'INSCOMP', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 20, N'COMP', N'SORT', N'SORT', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 21, N'COMP', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 1, N'UserDefineGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 2, N'UserDefineGroup', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 1, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 3, N'UserDefineGroup', N'UserDefineGroupName', N'群組名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 4, N'UserDefineGroup', N'Note', N'Note', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 5, N'UserDefineGroup', N'Key_Man', N'Key_Man', 0, N'nvarchar', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 6, N'UserDefineGroup', N'Key_Date', N'Key_Date', 0, N'datetime', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 7, N'UserDefineGroup', N'ColumnCnt', N'資料行數', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 8, N'UserDefineGroup', N'RowCnt', N'資料列數', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 9, N'UserDefineGroup', N'ItemsWidth', N'元件寬', 0, N'int', 0, N'', N'', N'', GETDATE())
INSERT [dbo].[jqColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, 10, N'UserDefineGroup', N'ItemsHeight', N'元件高', 0, N'int', 0, N'', N'', N'', GETDATE())
GO

DECLARE @UserDefineGroupID int,@UserDefineGroupForCompID int
SET @UserDefineGroupID = (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineMgt')
SET @UserDefineGroupForCompID = (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineGroupForComp')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 1, N'UserDefineGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 2, N'UserDefineGroup', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 1, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 3, N'UserDefineGroup', N'UserDefineGroupName', N'群組名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 4, N'UserDefineGroup', N'Note', N'備註', 1, N'ntext', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 5, N'UserDefineGroup', N'Key_Man', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 6, N'UserDefineGroup', N'Key_Date', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 7, N'UserDefineGroup', N'ColumnCnt', N'資料行數', 1, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 8, N'UserDefineGroup', N'RowCnt', N'資料列數', 1, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 9, N'UserDefineGroup', N'ItemsWidth', N'元件寬', 1, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupID, 10, N'UserDefineGroup', N'ItemsHeight', N'元件高', 1, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 2, N'COMP', N'COMP', N'公司代碼', 1, N'nvarchar', 1, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 3, N'COMP', N'COMPNAME', N'公司名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 4, N'COMP', N'CHAIRMAN', N'CHAIRMAN', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 5, N'COMP', N'COMPID', N'COMPID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 6, N'COMP', N'TEL', N'TEL', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 7, N'COMP', N'FAX', N'FAX', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 8, N'COMP', N'ADDR', N'ADDR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 9, N'COMP', N'HOUSEID', N'HOUSEID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 10, N'COMP', N'KEY_MAN', N'登錄者', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 11, N'COMP', N'KEY_DATE', N'登錄日期', 1, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 12, N'COMP', N'F0103', N'F0103', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 13, N'COMP', N'F0407', N'F0407', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 14, N'COMP', N'WORKCD', N'WORKCD', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 15, N'COMP', N'TAXID', N'TAXID', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 16, N'COMP', N'ACCOUNT', N'ACCOUNT', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 17, N'COMP', N'ACCR', N'ACCR', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 18, N'COMP', N'DEFA', N'DEFA', 0, N'bit', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 19, N'COMP', N'INSCOMP', N'INSCOMP', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 20, N'COMP', N'SORT', N'SORT', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 21, N'COMP', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 1, N'UserDefineGroup', N'UserDefineGroupName', N'群組名稱', 1, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 2, N'UserDefineGroup', N'AK', N'AK', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 3, N'UserDefineGroup', N'UserDefineGroupID', N'UserDefineGroupID', 0, N'uniqueidentifier', 1, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 4, N'UserDefineGroup', N'Note', N'Note', 0, N'ntext', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 5, N'UserDefineGroup', N'KeyMan', N'KeyMan', 0, N'nvarchar', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 6, N'UserDefineGroup', N'KeyDate', N'KeyDate', 0, N'datetime', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 7, N'UserDefineGroup', N'ColumnCnt', N'資料行數', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 8, N'UserDefineGroup', N'RowCnt', N'資料列數', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 9, N'UserDefineGroup', N'ItemsWidth', N'元件寬', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
INSERT [dbo].[jqUserColumn] ( [SettingID], [Sort], [TableName], [ColumnName], [DisplayName], [Display], [DataType], [PrimaryKey], [Format], [Memo], [CreateMan], [CreateDate], [System], [UserId], [GroupIndex], [OrderByIndex], [TopSummaryOption], [TopSummaryFormatString], [BottomSummaryOption], [BottomSummaryFormatString]) VALUES (@UserDefineGroupForCompID, 10, N'UserDefineGroup', N'ItemsHeight', N'元件高', 0, N'int', 0, N'', N'', N'', GETDATE(), N'', N'', 0, 0, N'', N'', N'', N'')
GO
 
DECLARE @UserDefineGroupForCompID int, @ParentID1 int,@ParentID2 int
SET @UserDefineGroupForCompID = (select ID FROM jqSetting WHERE QuerySetting = 'UserDefineGroupForComp')
SET @ParentID1 = (Select ID FROM jqColumn WHERE TableName = 'UserDefineGroup' AND ColumnName = 'UserDefineGroupID' AND SettingID = @UserDefineGroupForCompID)
SET @ParentID2 = (Select ID FROM jqColumn WHERE TableName = 'COMP' AND ColumnName ='UserDefineGroupID' AND SettingID = @UserDefineGroupForCompID)
INSERT [dbo].[jqForeignKey] ([SettingID], [ParentID], [ParentTable], [ParentColumn], [ChildID], [ChildTable], [ChildColumn], [CreateMan], [CreateDate]) VALUES ( @UserDefineGroupForCompID, @ParentID1, N'UserDefineGroup', N'UserDefineGroupID', @ParentID2, N'COMP', N'UserDefineGroupID', N'', GETDATE())
GO
