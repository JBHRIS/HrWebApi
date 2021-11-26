USE [ezFlow_CHPT]
GO
/****** Object:  Table [dbo].[WorkAgentPower]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkAgentPower](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[WorkAgent_auto] [int] NULL,
	[FlowTree_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_WorkAgentPower] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkAgent]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkAgent](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Role_idSource] [nvarchar](100) NULL,
	[Emp_idSource] [nvarchar](50) NULL,
	[Role_idTarget] [nvarchar](100) NULL,
	[Emp_idTarget] [nvarchar](50) NULL,
 CONSTRAINT [PK_WorkAgent] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormUploadFile]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormUploadFile](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sKey] [nvarchar](50) NOT NULL,
	[sUpName] [nvarchar](200) NOT NULL,
	[sServerName] [nvarchar](200) NOT NULL,
	[sDescription] [nvarchar](2000) NULL,
	[sType] [nvarchar](200) NOT NULL,
	[iSize] [int] NOT NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormUploadFile] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormSignM]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormSignM](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NULL,
	[idProcess] [int] NOT NULL,
	[sKey] [nvarchar](50) NULL,
	[sNobr] [nvarchar](50) NULL,
	[sName] [nvarchar](50) NOT NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NOT NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sNote] [nvarchar](2000) NULL,
	[bSign] [bit] NOT NULL,
	[sSign] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormSignM] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormSendMailLog]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormSendMailLog](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sCategory] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NOT NULL,
	[sMail] [nvarchar](50) NOT NULL,
	[sSubject] [nvarchar](50) NOT NULL,
	[sContent] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormSendMailLog] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormSendMail]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormSendMail](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sCategory] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NOT NULL,
	[sMail] [nvarchar](50) NOT NULL,
	[sContent] [nvarchar](50) NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormSendMail] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormDataGroup]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormDataGroup](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sDataGroup] [nvarchar](50) NOT NULL,
	[bMsgManage] [bit] NULL,
	[bFormDisplay] [bit] NULL,
 CONSTRAINT [PK_wfFormDataGroup] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[wfFormDataGroup] ON
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (13, N'Ot', N'AA01LTIT', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (14, N'Ot', N'AA01TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (15, N'Ot', N'AA05TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (16, N'Ot', N'AA06TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (17, N'Ot', N'AA08TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (18, N'ShiftShort', N'AA01LTIT', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (19, N'ShiftShort', N'AA01TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (20, N'ShiftShort', N'AA05TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (21, N'ShiftShort', N'AA06TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (22, N'ShiftShort', N'AA08TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (23, N'ShiftShort', N'AA04TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (24, N'ShiftLong', N'AA01LTIT', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (25, N'ShiftLong', N'AA01TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (26, N'ShiftLong', N'AA05TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (27, N'ShiftLong', N'AA06TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (28, N'ShiftLong', N'AA08TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (29, N'ShiftLong', N'AA04TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (30, N'Batch', N'AA01LTIT', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (31, N'Batch', N'AA01TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (32, N'Batch', N'AA05TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (33, N'Batch', N'AA06TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (34, N'Batch', N'AA08TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (39, N'Ot1', N'AA01LTD', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (40, N'Ot1', N'AA01LTI', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (41, N'Ot1', N'AA01LTIT', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (42, N'Ot1', N'AA01LZD', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (43, N'Ot1', N'AA01LZI', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (44, N'Ot1', N'AA01TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (45, N'Ot1', N'AA05TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (46, N'Ot1', N'AA06TP', NULL, 0)
INSERT [dbo].[wfFormDataGroup] ([iAutoKey], [sFormCode], [sDataGroup], [bMsgManage], [bFormDisplay]) VALUES (47, N'Ot1', N'AA08TP', NULL, 0)
SET IDENTITY_INSERT [dbo].[wfFormDataGroup] OFF
/****** Object:  Table [dbo].[wfFormCode]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormCode](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sCategory] [nvarchar](50) NOT NULL,
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](200) NOT NULL,
	[sContent] [nvarchar](2000) NULL,
	[iOrder] [int] NOT NULL,
	[bDisplay] [bit] NOT NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormCode] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[wfFormCode] ON
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (1, N'State', N'0', N'未送出', NULL, 10, 0, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (2, N'State', N'1', N'進行中', NULL, 2, 1, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (3, N'State', N'2', N'駁回', NULL, 3, 1, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (4, N'State', N'3', N'完成', NULL, 4, 1, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (5, N'State', N'4', N'刪除', NULL, 5, 0, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (6, N'State', N'5', N'服務開始', NULL, 6, 0, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (7, N'State', N'6', N'服務結束', NULL, 7, 0, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (8, N'State', N'7', N'抽單', NULL, 8, 0, N'JJ', NULL)
INSERT [dbo].[wfFormCode] ([iAutoKey], [sCategory], [sCode], [sName], [sContent], [iOrder], [bDisplay], [sKeyMan], [dKeyDate]) VALUES (10, N'State', N'9', N'其它', NULL, 9, 0, N'JJ', NULL)
SET IDENTITY_INSERT [dbo].[wfFormCode] OFF
/****** Object:  Table [dbo].[wfFormAppCode]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormAppCode](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sCategory] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sKey] [nvarchar](50) NOT NULL,
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](200) NULL,
	[sContent] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfFormAppCode] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfFormApp]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfFormApp](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[iCateOrder] [int] NOT NULL,
	[bDelay] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[dDateTimeA] [datetime] NULL,
	[dDateTimeD] [datetime] NULL,
	[sLevel] [nvarchar](50) NULL,
	[sLimitTime] [nvarchar](50) NULL,
	[sYear] [nvarchar](50) NULL,
	[sDecode] [nvarchar](50) NULL,
	[bAuth] [bit] NOT NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NULL,
	[sConditions1] [nvarchar](50) NULL,
	[sConditions2] [nvarchar](50) NULL,
	[sConditions3] [nvarchar](50) NULL,
	[sConditions4] [nvarchar](50) NULL,
	[sConditions5] [nvarchar](50) NULL,
	[sConditions6] [nvarchar](50) NULL,
 CONSTRAINT [PK_wfFormApp] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfForm]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfForm](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sFormName] [nvarchar](50) NULL,
	[sFlowTree] [nvarchar](50) NULL,
	[sStdNote] [nvarchar](2000) NULL,
	[sCheckNote] [nvarchar](2000) NULL,
	[sViewNote] [nvarchar](2000) NULL,
	[sEtcNote] [nvarchar](2000) NULL,
	[iDelay] [int] NOT NULL,
	[iAppCount] [int] NOT NULL,
	[bNote] [bit] NOT NULL,
	[bSignNote] [bit] NOT NULL,
	[bSignState] [bit] NOT NULL,
	[bUploadFile] [bit] NOT NULL,
	[bAttend] [bit] NOT NULL,
	[bAgentApp] [bit] NOT NULL,
	[b1] [bit] NULL,
	[b2] [bit] NULL,
	[b3] [bit] NULL,
	[b4] [bit] NULL,
	[b5] [bit] NULL,
	[s1] [nvarchar](200) NULL,
	[s2] [nvarchar](200) NULL,
	[s3] [nvarchar](200) NULL,
	[s4] [nvarchar](200) NULL,
	[s5] [nvarchar](200) NULL,
	[sKeyMan] [nvarchar](200) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfForm] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[wfForm] ON
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (3, N'Abs', N'請假申請單', N'15', N'※ <span style="font-family: ; color: #404040; mso-hansi-font-family: verdana; mso-bidi-font-family: ''times new roman''; mso-ascii-font-family: verdana; mso-font-kerning: 1.0pt; mso-ansi-language: en-us; mso-fareast-language: zh-tw; mso-bidi-language: ar-sa">請將婚假、喪假、產假、公假、病假等證明文件</span><span lang="EN-US" style="font-family: ; color: #404040; mso-bidi-font-family: ''times new roman''; mso-font-kerning: 1.0pt; mso-ansi-language: en-us; mso-fareast-language: zh-tw; mso-bidi-language: ar-sa; mso-fareast-font-family: 新細明體">Scan</span><span style="font-family: ; color: #404040; mso-hansi-font-family: verdana; mso-bidi-font-family: ''times new roman''; mso-ascii-font-family: verdana; mso-font-kerning: 1.0pt; mso-ansi-language: en-us; mso-fareast-language: zh-tw; mso-bidi-language: ar-sa">並夾檔或繳交至人資單位。</span><br />
<br />
※ 間接人員全年特休假、事假(含家庭照顧假)、病假(含生理假)、無薪假經與當年度特別休假抵充後，超過之天數於年終獎金中扣除。<font color="#000000"><span lang="EN-US" times="" new="" roman?;="" mso-bidi-font-family:="" 細明體?="" style=''font: 7pt "times new roman" "times new roman"; mso-hansi-font-family: ; mso-list: ignore''>&nbsp;<br />
</span></font><font color="#000000"><span lang="EN-US" style="mso-hansi-font-family: ''times new roman''; mso-bidi-font-family: 細明體; mso-list: ignore">&nbsp;&nbsp;&nbsp;</span></font><font color="#000000"><span lang="EN-US" style="line-height: normal; font-variant: normal; font-style: normal; font-family: ; font-size: 7pt; mso-hansi-font-family: ''times new roman''; mso-bidi-font-family: 細明體; mso-list: ignore">&nbsp;&nbsp;</span></font>', NULL, NULL, NULL, 0, 10, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppAbs', N'1', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (4, N'Ot', N'加班申請單', N'16', N'<span style="color: #ff0000; font-size: 14pt">※申請加班不需選擇加班班別。</span>', NULL, NULL, NULL, 0, 20, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppOt', N'2', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (14, N'Card', N'忘刷單', N'60', N'<span style="color: #ff0000; font-size: 14pt">※忘刷單一經送出立即生效不需審核，但會mail通知直屬主管。</span>', N'', NULL, NULL, 0, 5, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppCard', N'4', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (15, N'Abs1', N'公出申請單', N'62', NULL, NULL, NULL, NULL, 0, 5, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppAbs', N'5', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (16, N'Absc', N'銷假單', N'17', N'<span style="color: #ff0000; font-size: 14pt">※銷假單一經送出立即生效不需審核，但會mail通知簽核主管。</span>', NULL, NULL, NULL, 0, 5, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppAbsc', N'3', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (17, N'ShiftShort', N'換班單(單天)', N'66', N'<p><span style="color: #ff0000">※ 本單適用</span></p>
<p><span style="color: #ff0000">1.單日換班。</span><span style="color: #333333">例：1/2原班別早班換成中班。</span></p>
<p><span style="color: #ff0000">2.二日班別互換。</span><span style="color: #333333">例：1/1原班別假日，1/2原班別早班；換班後變成1/1班別早班，1/2班別假日。</span></p>
<p></p>', NULL, NULL, NULL, 0, 5, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppShiftShort', N'7', NULL, NULL)
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (18, N'ShiftLong', N'調班單(長期)', N'67', N'<span style="color: #ff0000">※ 本調班單為長期調班。</span>例：從1/2起開始調為中班。<br />
<br />
<span style="color: #ff0000">※ 請勿同一人同時申請多筆調班資料。</span><br />', NULL, NULL, NULL, 0, 2, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppShiftLong', N'8', N'F6816', CAST(0x00009DE200AD79A0 AS DateTime))
INSERT [dbo].[wfForm] ([iAutoKey], [sFormCode], [sFormName], [sFlowTree], [sStdNote], [sCheckNote], [sViewNote], [sEtcNote], [iDelay], [iAppCount], [bNote], [bSignNote], [bSignState], [bUploadFile], [bAttend], [bAgentApp], [b1], [b2], [b3], [b4], [b5], [s1], [s2], [s3], [s4], [s5], [sKeyMan], [dKeyDate]) VALUES (19, N'Ot1', N'預估加班申請單', N'73', N'<span style="color: #ff0000; font-size: 14pt">※申請加班不需選擇加班班別。</span>', NULL, NULL, NULL, 0, 20, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, NULL, N'wfFormSignM', N'wfFormApp', N'wfAppOt1', N'2', NULL, NULL)
SET IDENTITY_INSERT [dbo].[wfForm] OFF
/****** Object:  Table [dbo].[wfDynamic]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfDynamic](
	[idProcess] [int] NOT NULL,
	[idFlowNode] [nvarchar](50) NOT NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_wfDynamic] PRIMARY KEY CLUSTERED 
(
	[idProcess] ASC,
	[idFlowNode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppShiftShort]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppShiftShort](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sNobrA] [nvarchar](50) NOT NULL,
	[sNameA] [nvarchar](50) NULL,
	[sDeptA] [nvarchar](50) NULL,
	[sDeptNameA] [nvarchar](50) NULL,
	[sJobA] [nvarchar](50) NULL,
	[sJobNameA] [nvarchar](50) NULL,
	[sJoblA] [nvarchar](50) NULL,
	[sJoblNameA] [nvarchar](50) NULL,
	[sEmpcdA] [nvarchar](50) NULL,
	[sEmpcdNameA] [nvarchar](50) NULL,
	[sRoleA] [nvarchar](100) NULL,
	[sDIA] [nvarchar](50) NULL,
	[sRoteA] [nvarchar](50) NULL,
	[sRoteNameA] [nvarchar](50) NULL,
	[dDateA] [datetime] NOT NULL,
	[sNobrB] [nvarchar](50) NOT NULL,
	[sNameB] [nvarchar](50) NULL,
	[sDeptB] [nvarchar](50) NULL,
	[sDeptNameB] [nvarchar](50) NULL,
	[sJobB] [nvarchar](50) NULL,
	[sJobNameB] [nvarchar](50) NULL,
	[sJoblB] [nvarchar](50) NULL,
	[sJoblNameB] [nvarchar](50) NULL,
	[sEmpcdB] [nvarchar](50) NULL,
	[sEmpcdNameB] [nvarchar](50) NULL,
	[sRoleB] [nvarchar](100) NULL,
	[sDIB] [nvarchar](50) NULL,
	[sRoteB] [nvarchar](50) NULL,
	[sRoteNameB] [nvarchar](50) NULL,
	[dDateB] [datetime] NOT NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppShiftShort] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppShiftLong]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppShiftLong](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[sRotetCode] [nvarchar](50) NOT NULL,
	[sRotetName] [nvarchar](50) NULL,
	[sHoliCode] [nvarchar](50) NOT NULL,
	[sHoliName] [nvarchar](50) NULL,
	[sOtRateCode] [nvarchar](50) NOT NULL,
	[sOtRateName] [nvarchar](50) NULL,
	[dDate] [datetime] NULL,
	[sRotetCodeA] [nvarchar](50) NOT NULL,
	[sRotetNameA] [nvarchar](50) NULL,
	[sHoliCodeA] [nvarchar](50) NOT NULL,
	[sHoliNameA] [nvarchar](50) NULL,
	[sOtRateCodeA] [nvarchar](50) NOT NULL,
	[sOtRateNameA] [nvarchar](50) NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppShiftLong] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppOt1]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppOt1](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[dDateTimeB] [datetime] NOT NULL,
	[dDateTimeE] [datetime] NOT NULL,
	[dDateB] [datetime] NOT NULL,
	[dDateE] [datetime] NOT NULL,
	[sTimeB] [nvarchar](50) NOT NULL,
	[sTimeE] [nvarchar](50) NOT NULL,
	[sOtcatCode] [nvarchar](50) NULL,
	[sOtcatName] [nvarchar](50) NULL,
	[sOtrcdCode] [nvarchar](50) NULL,
	[sOtrcdName] [nvarchar](50) NULL,
	[sRoteCode] [nvarchar](50) NULL,
	[sRoteName] [nvarchar](50) NULL,
	[sOtDeptCode] [nvarchar](50) NULL,
	[sOtDeptName] [nvarchar](50) NULL,
	[iTotalHour] [decimal](16, 2) NOT NULL,
	[bExceptionHour] [bit] NOT NULL,
	[iExceptionHour] [decimal](16, 2) NOT NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[sSalYYMM] [nvarchar](50) NOT NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppOt1] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppOt]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppOt](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[dDateTimeB] [datetime] NOT NULL,
	[dDateTimeE] [datetime] NOT NULL,
	[dDateB] [datetime] NOT NULL,
	[dDateE] [datetime] NOT NULL,
	[sTimeB] [nvarchar](50) NOT NULL,
	[sTimeE] [nvarchar](50) NOT NULL,
	[sOtcatCode] [nvarchar](50) NULL,
	[sOtcatName] [nvarchar](50) NULL,
	[sOtrcdCode] [nvarchar](50) NULL,
	[sOtrcdName] [nvarchar](50) NULL,
	[sRoteCode] [nvarchar](50) NULL,
	[sRoteName] [nvarchar](50) NULL,
	[sOtDeptCode] [nvarchar](50) NULL,
	[sOtDeptName] [nvarchar](50) NULL,
	[iTotalHour] [decimal](16, 2) NOT NULL,
	[bExceptionHour] [bit] NOT NULL,
	[iExceptionHour] [decimal](16, 2) NOT NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[sSalYYMM] [nvarchar](50) NOT NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppOt] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppCard]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppCard](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[dDateTime] [datetime] NOT NULL,
	[dDate] [datetime] NOT NULL,
	[sTime] [nvarchar](50) NOT NULL,
	[sReasonCode] [nvarchar](50) NOT NULL,
	[sReasonName] [nvarchar](50) NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sCode1] [nvarchar](50) NULL,
	[sName1] [nvarchar](50) NULL,
	[sCode2] [nvarchar](50) NULL,
	[sName2] [nvarchar](50) NULL,
	[sCode3] [nvarchar](50) NULL,
	[sName3] [nvarchar](50) NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppCard] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppAgent]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppAgent](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sAgentNobr] [nvarchar](50) NOT NULL,
	[sAgentName] [nvarchar](50) NULL,
	[sAgentMail] [nvarchar](200) NULL,
	[sNote] [nvarchar](2000) NULL,
	[sKeyMan] [nvarchar](50) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppAgent] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppAbsc]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppAbsc](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[dDateTime] [datetime] NOT NULL,
	[dDate] [datetime] NOT NULL,
	[sTime] [nvarchar](50) NOT NULL,
	[sHcode] [nvarchar](50) NOT NULL,
	[sHname] [nvarchar](50) NOT NULL,
	[sYYMM] [nvarchar](50) NOT NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[bAuth] [bit] NOT NULL,
	[sCode1] [nvarchar](50) NULL,
	[sName1] [nvarchar](50) NULL,
	[sCode2] [nvarchar](50) NULL,
	[sName2] [nvarchar](50) NULL,
	[sCode3] [nvarchar](50) NULL,
	[sName3] [nvarchar](50) NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppAbsc] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[wfAppAbs]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wfAppAbs](
	[iAutoKey] [int] IDENTITY(1,1) NOT NULL,
	[sFormCode] [nvarchar](50) NOT NULL,
	[sProcessID] [nvarchar](50) NOT NULL,
	[idProcess] [int] NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sDept] [nvarchar](50) NULL,
	[sDeptName] [nvarchar](50) NULL,
	[sJob] [nvarchar](50) NULL,
	[sJobName] [nvarchar](50) NULL,
	[sJobl] [nvarchar](50) NULL,
	[sJoblName] [nvarchar](50) NULL,
	[sEmpcd] [nvarchar](50) NULL,
	[sEmpcdName] [nvarchar](50) NULL,
	[sRole] [nvarchar](100) NULL,
	[sDI] [nvarchar](50) NULL,
	[sRote] [nvarchar](50) NULL,
	[dDateTimeB] [datetime] NOT NULL,
	[dDateTimeE] [datetime] NOT NULL,
	[dDateB] [datetime] NOT NULL,
	[dDateE] [datetime] NOT NULL,
	[sTimeB] [nvarchar](50) NOT NULL,
	[sTimeE] [nvarchar](50) NOT NULL,
	[sHcode] [nvarchar](50) NOT NULL,
	[sHname] [nvarchar](50) NOT NULL,
	[iDay] [decimal](16, 2) NOT NULL,
	[iHour] [decimal](16, 2) NOT NULL,
	[iTotalDay] [decimal](16, 2) NOT NULL,
	[iTotalHour] [decimal](16, 2) NOT NULL,
	[bExceptionHour] [bit] NOT NULL,
	[iExceptionHour] [decimal](16, 2) NOT NULL,
	[sReserve1] [nvarchar](2000) NULL,
	[sReserve2] [nvarchar](2000) NULL,
	[sReserve3] [nvarchar](2000) NULL,
	[sReserve4] [nvarchar](2000) NULL,
	[sSalYYMM] [nvarchar](50) NOT NULL,
	[bSign] [bit] NOT NULL,
	[sState] [nvarchar](50) NOT NULL,
	[sAgentNobr] [nvarchar](50) NULL,
	[sAgentName] [nvarchar](50) NULL,
	[sAgentNote] [nvarchar](2000) NULL,
	[bAuth] [bit] NOT NULL,
	[sNote] [nvarchar](2000) NULL,
	[dKeyDate] [datetime] NULL,
 CONSTRAINT [PK_wfAppAbs] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tempPos]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tempPos](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[PosLevel_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_tempPos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tempDept]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tempDept](
	[id] [nvarchar](50) NOT NULL,
	[idParent] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[DeptLevel_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_tempDept] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tempBase]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tempBase](
	[id] [nvarchar](50) NOT NULL,
	[pw] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
	[dept] [nvarchar](50) NULL,
	[depts] [nvarchar](50) NULL,
	[job] [nvarchar](50) NULL,
	[jobl] [nvarchar](50) NULL,
	[jobs] [nvarchar](50) NULL,
	[mang] [bit] NULL,
 CONSTRAINT [PK_tempBase] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysVar]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysVar](
	[urlRoot] [nvarchar](50) NOT NULL,
	[mailServer] [nvarchar](50) NULL,
	[mailID] [nvarchar](50) NULL,
	[mailPW] [nvarchar](50) NULL,
	[senderMail] [nvarchar](50) NULL,
	[senderName] [nvarchar](50) NULL,
	[maxKey] [int] NULL,
	[webSrvURL] [nvarchar](100) NULL,
	[sysClose] [bit] NULL,
 CONSTRAINT [PK_SysVar] PRIMARY KEY CLUSTERED 
(
	[urlRoot] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SysVar] ([urlRoot], [mailServer], [mailID], [mailPW], [senderMail], [senderName], [maxKey], [webSrvURL], [sysClose]) VALUES (N'http://192.168.0.202/ezFlow', N'192.168.0.80', N'hr@holystone.com.tw', N'12345', N'hr@holystone.com.tw', N'流程信差服務', 1, N'http://localhost/ezFlow/ezEngine/Service.asmx', 0)
/****** Object:  Table [dbo].[SysPlan]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysPlan](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[monitor_Check] [int] NULL,
	[maxCount_Check] [int] NULL,
	[isAutoFix_Check] [bit] NULL,
	[isMail_Check] [bit] NULL,
	[mail1_Check] [nvarchar](50) NULL,
	[mail2_Check] [nvarchar](50) NULL,
	[mail3_Check] [nvarchar](50) NULL,
	[monitor_Error] [int] NULL,
	[maxCount_Error] [int] NULL,
	[isAutoFix_Error] [bit] NULL,
	[mail1_Error] [nvarchar](50) NULL,
	[mail2_Error] [nvarchar](50) NULL,
	[mail3_Error] [nvarchar](50) NULL,
 CONSTRAINT [PK_SysPlan] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SysAdmin]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SysAdmin](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Emp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_SysAdmin] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SysAdmin] ON
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (1, N'10200007')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (2, N'10201015')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (6, N'10100955')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (7, N'10100543')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (8, N'10100094')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (9, N'10100029')
INSERT [dbo].[SysAdmin] ([auto], [Emp_id]) VALUES (10, N'10201398')
SET IDENTITY_INSERT [dbo].[SysAdmin] OFF
/****** Object:  Table [dbo].[SubWork]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubWork](
	[iAutoKey] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[sNobr] [nvarchar](50) NOT NULL,
	[sSubDept] [nvarchar](50) NOT NULL,
	[sSubJob] [nvarchar](50) NOT NULL,
	[bSubMang] [bit] NOT NULL,
	[dAdate] [datetime] NOT NULL,
	[dDdate] [datetime] NOT NULL,
	[iFlowAuth] [int] NOT NULL,
	[bReplace] [bit] NOT NULL,
	[sKeyMan] [nvarchar](50) NOT NULL,
	[dKeyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SubWork] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SendMailParm]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendMailParm](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[triggerTimer] [int] NULL,
	[mailSpantime] [int] NULL,
	[mailMaxCount] [int] NULL,
	[autofix] [bit] NULL,
	[mailMang] [bit] NULL,
	[mailCustom] [bit] NULL,
	[customEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_SendMailParm] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SendMailLog]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SendMailLog](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Emp_id] [nvarchar](50) NULL,
	[counter] [int] NULL,
	[adate] [datetime] NULL,
 CONSTRAINT [PK_SendMailLog] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[auto] [int] IDENTITY(1,1) NOT NULL,
	[id] [nvarchar](100) NULL,
	[idParent] [nvarchar](100) NULL,
	[Dept_id] [nvarchar](50) NULL,
	[Pos_id] [nvarchar](50) NULL,
	[dateB] [datetime] NULL,
	[dateE] [datetime] NULL,
	[Emp_id] [nvarchar](50) NULL,
	[mgDefault] [bit] NULL,
	[deptMg] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RobotLog]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RobotLog](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[srvType] [nvarchar](50) NULL,
	[ProcessFlow_id] [int] NULL,
	[ProcessNode_auto] [int] NULL,
	[ProcessCheck_auto] [int] NULL,
	[counter] [int] NULL,
	[note] [nvarchar](50) NULL,
	[adate] [datetime] NULL,
	[isClose] [bit] NULL,
 CONSTRAINT [PK_RobotLog] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessNode]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessNode](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessNode_idPrior] [int] NULL,
	[ProcessFlow_id] [int] NULL,
	[FlowNode_id] [nvarchar](50) NULL,
	[adate] [datetime] NULL,
	[isFinish] [bit] NULL,
	[isMulti] [bit] NULL,
 CONSTRAINT [PK_ProcessNode] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessMultiFlow]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessMultiFlow](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[ProcessNode_auto] [int] NULL,
	[SubProcessFlow_id] [int] NULL,
	[SubFlowTree_id] [nvarchar](50) NULL,
	[SubInitRole_id] [nvarchar](100) NULL,
	[SubInitEmp_id] [nvarchar](50) NULL,
	[SubDynamicRole_id] [nvarchar](100) NULL,
	[SubDynamicEmp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProcessMultiFlow] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessFlowShare]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessFlowShare](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
	[isStarter] [bit] NULL,
 CONSTRAINT [PK_ProcessFlowShare] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessFlow]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessFlow](
	[id] [int] NOT NULL,
	[ProcessNode_auto] [int] NULL,
	[FlowTree_id] [nvarchar](50) NULL,
	[adate] [datetime] NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
	[isFinish] [bit] NULL,
	[isError] [bit] NULL,
	[isCancel] [bit] NULL,
	[isMultiFlow] [bit] NULL,
 CONSTRAINT [PK_ProcessFlow] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessException]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessException](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[ProcessNode_auto] [int] NULL,
	[ProcessCheck_auto] [int] NULL,
	[errorType] [nvarchar](50) NULL,
	[errorMsg] [nvarchar](255) NULL,
	[adate] [datetime] NULL,
	[isOK] [bit] NULL,
 CONSTRAINT [PK_ProcessException] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessCheck]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessCheck](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessNode_auto] [int] NULL,
	[Role_idDefault] [nvarchar](100) NULL,
	[Emp_idDefault] [nvarchar](50) NULL,
	[Role_idAgent] [nvarchar](100) NULL,
	[Emp_idAgent] [nvarchar](50) NULL,
	[Role_idReal] [nvarchar](100) NULL,
	[Emp_idReal] [nvarchar](50) NULL,
	[adate] [datetime] NULL,
 CONSTRAINT [PK_ProcessCheck] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessApView]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessApView](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
	[tag1] [nvarchar](50) NULL,
	[tag2] [nvarchar](50) NULL,
	[tag3] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProcessApView] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcessApParm]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessApParm](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[ProcessNode_auto] [int] NULL,
	[ProcessCheck_auto] [int] NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProcessApParm] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosLevel]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosLevel](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[sorting] [int] NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[PosLevel] ([id], [name], [sorting]) VALUES (N'0', N'職員0', -1000)
/****** Object:  Table [dbo].[Pos]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pos](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[PosLevel_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgImport]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgImport](
	[iAutoKey] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[bSyncLoginID] [bit] NULL,
	[sFrontLoginID] [nvarchar](50) NULL,
	[bFullImport] [bit] NULL,
	[sDeptTopCode] [nvarchar](50) NULL,
	[bRoleTopEmpty] [bit] NULL,
	[bSyncLoginPW] [bit] NULL,
	[bLevel] [bit] NULL,
	[bTest] [bit] NULL,
	[sTestMail] [nvarchar](200) NULL,
	[bFixBug] [bit] NULL,
 CONSTRAINT [PK_OrgImport] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OrgImport] ON
INSERT [dbo].[OrgImport] ([iAutoKey], [bSyncLoginID], [sFrontLoginID], [bFullImport], [sDeptTopCode], [bRoleTopEmpty], [bSyncLoginPW], [bLevel], [bTest], [sTestMail], [bFixBug]) VALUES (1, 0, N'', 1, N'', 0, 1, 0, 0, N'joumingt@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[OrgImport] OFF
/****** Object:  Table [dbo].[NodeStart]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeStart](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[virtualPath] [nvarchar](50) NULL,
	[viewAp] [nvarchar](50) NULL,
	[isAuto] [bit] NULL,
	[tableName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeStart] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'104', N'FlowForm/Ot', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'115', N'FlowForm/Absc', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'257', N'FlowForm/Batch', N'List.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'269', N'FlowForm/Card', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'279', N'FlowForm/Manage', N'ViewFlow.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'282', N'FlowForm/Abs1', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'298', N'FlowForm/Manage', N'Form.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'301', N'FlowForm/Manage', N'FormCode.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'307', N'FlowForm/ShiftShort', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'315', N'FlowForm/ShiftLong', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'355', N'FlowForm/Ot1', N'Check.aspx', 0, N'wfFormApp')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'378', N'FlowForm/Manage', N'Agent.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'387', N'FlowForm/Manage', N'FormDataGroup.aspx', 0, N'')
INSERT [dbo].[NodeStart] ([FlowNode_id], [virtualPath], [viewAp], [isAuto], [tableName]) VALUES (N'96', N'FlowForm/Abs', N'Check.aspx', 0, N'wfFormApp')
/****** Object:  Table [dbo].[NodeService]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeService](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[webSrvUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK_NodeService] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'100', N'http://localhost/ezFlow/Forms/FlowForm/ws/Abs.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'111', N'http://localhost/ezFlow/Forms/FlowForm/ws/Ot.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'120', N'http://localhost/ezFlow/Forms/FlowForm/ws/Absc.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'278', N'http://localhost/ezFlow/Forms/FlowForm/ws/Card.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'286', N'http://localhost/ezFlow/Forms/FlowForm/ws/Abs1.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'310', N'http://localhost/ezFlow/Forms/FlowForm/ws/ShiftShort.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'320', N'http://localhost/ezFlow/Forms/FlowForm/ws/ShiftLong.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'361', N'http://localhost/ezFlow/Forms/FlowForm/ws/Ot1.asmx')
INSERT [dbo].[NodeService] ([FlowNode_id], [webSrvUrl]) VALUES (N'386', N'http://localhost/ezFlow/Forms/FlowForm/ws/AbsSetManage.asmx')
/****** Object:  Table [dbo].[NodeMultiStart]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeMultiStart](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FlowNode_id] [nvarchar](50) NULL,
	[FlowTree_idSub] [nvarchar](50) NULL,
	[isFinish] [bit] NULL,
 CONSTRAINT [PK_NodeMulti] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NodeMultiInit]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeMultiInit](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeMultiInit] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NodeMangLoopBreak]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeMangLoopBreak](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FlowNode_id] [nvarchar](50) NULL,
	[note] [nvarchar](255) NULL,
	[tableName] [nvarchar](50) NULL,
	[fdName1] [nvarchar](50) NULL,
	[fdType1] [nvarchar](50) NULL,
	[criteria1] [nvarchar](50) NULL,
	[minValue1] [nvarchar](50) NULL,
	[maxValue1] [nvarchar](50) NULL,
	[fdName2] [nvarchar](50) NULL,
	[fdType2] [nvarchar](50) NULL,
	[criteria2] [nvarchar](50) NULL,
	[minValue2] [nvarchar](50) NULL,
	[maxValue2] [nvarchar](50) NULL,
	[fdName3] [nvarchar](50) NULL,
	[fdType3] [nvarchar](50) NULL,
	[criteria3] [nvarchar](50) NULL,
	[minValue3] [nvarchar](50) NULL,
	[maxValue3] [nvarchar](50) NULL,
	[fdName4] [nvarchar](50) NULL,
	[fdType4] [nvarchar](50) NULL,
	[criteria4] [nvarchar](50) NULL,
	[minValue4] [nvarchar](50) NULL,
	[maxValue4] [nvarchar](50) NULL,
	[fdName5] [nvarchar](50) NULL,
	[fdType5] [nvarchar](50) NULL,
	[criteria5] [nvarchar](50) NULL,
	[minValue5] [nvarchar](50) NULL,
	[maxValue5] [nvarchar](50) NULL,
	[fdName6] [nvarchar](50) NULL,
	[fdType6] [nvarchar](50) NULL,
	[criteria6] [nvarchar](50) NULL,
	[minValue6] [nvarchar](50) NULL,
	[maxValue6] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeCheckLoopBreak] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[NodeMangLoopBreak] ON
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (8, N'98', N'駁回', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (10, N'107', N'駁回', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (11, N'107', N'核准', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (61, N'284', N'N', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (62, N'284', N'Y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (64, N'309', N'N', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (65, N'309', N'Y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'11', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (66, N'317', N'N', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (67, N'317', N'Y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'11', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (77, N'357', N'Y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (78, N'357', N'N', N'wfFormApp', N'bSign', N'Boolean', N'==', N'0', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (79, N'98', N'核准', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<<', N'01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (95, N'107', N'核准(DI=D)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'D', N'', N'sConditions1', N'String', N'<=', N'10', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (96, N'107', N'核准(DI=I)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'I', N'', N'sConditions1', N'String', N'<=', N'09', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (97, N'98', N'核准-龍利(Day<=1)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'11', N'', N'sConditions2', N'String', N'<=', N'01', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (98, N'98', N'核准-龍利(Day<=2)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'10', N'', N'sConditions2', N'String', N'<=', N'02', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (99, N'98', N'核准-龍利(Day<=5)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'09', N'', N'sConditions2', N'String', N'<=', N'05', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (100, N'98', N'核准-龍利(Day<=9)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'07', N'', N'sConditions2', N'String', N'<=', N'09', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (101, N'98', N'核准-龍利(Day>9)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (102, N'98', N'核准-和生(Day<=1)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'10', N'', N'sConditions2', N'String', N'<=', N'01', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (103, N'98', N'核准-和生(Day<=2)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'09', N'', N'sConditions2', N'String', N'<=', N'02', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (104, N'98', N'核准-和生(Day<=4)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'07', N'', N'sConditions2', N'String', N'<=', N'04', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (105, N'98', N'核准-和生(Day<=6)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'sConditions2', N'String', N'<=', N'06', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (106, N'98', N'核准-和生(Day<=10)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'04', N'', N'sConditions2', N'String', N'<=', N'10', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (107, N'98', N'核准-和生(Day>10)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'03', N'', N'sConditions3', N'String', N'==', N'AA04', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (108, N'98', N'核准-和佳(Day<=2)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'12', N'', N'sConditions2', N'String', N'<=', N'02', N'', N'sConditions3', N'String', N'==', N'AA08', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (109, N'98', N'核准-和佳(Day<=4)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'sConditions2', N'String', N'<=', N'04', N'', N'sConditions3', N'String', N'==', N'AA08', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (111, N'98', N'核准-和佳(Day>4)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'04', N'', N'sConditions3', N'String', N'==', N'AA08', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (112, N'98', N'核准-台北(Day<=1)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'10', N'', N'sConditions2', N'String', N'<=', N'01', N'', N'sConditions3', N'String', N'==', N'AA01T', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (113, N'98', N'核准-台北(Day<=2)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'08', N'', N'sConditions2', N'String', N'<=', N'02', N'', N'sConditions3', N'String', N'==', N'AA01T', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (114, N'98', N'核准-台北(Day<=4)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'07', N'', N'sConditions2', N'String', N'<=', N'04', N'', N'sConditions3', N'String', N'==', N'AA01T', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (115, N'98', N'核准-台北(Day<=6)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'sConditions2', N'String', N'<=', N'06', N'', N'sConditions3', N'String', N'==', N'AA01T', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (116, N'98', N'核准-台北(Day>6)', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'sConditions3', N'String', N'==', N'AA01T', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (118, N'284', N'Y-非龍潭/利澤廠', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'<>', N'AA01', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (119, N'284', N'Y-龍潭/利澤廠-Day<=1', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'sConditions2', N'String', N'<=', N'01', N'', N'sConditions1', N'String', N'<=', N'11', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (120, N'284', N'Y-龍潭/利澤廠-Day<=2', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'sConditions2', N'String', N'<=', N'02', N'', N'sConditions1', N'String', N'<=', N'10', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (121, N'284', N'Y-龍潭/利澤廠-Day<=5', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'sConditions2', N'String', N'<=', N'05', N'', N'sConditions1', N'String', N'<=', N'09', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (122, N'284', N'Y-龍潭/利澤廠-Day<=9', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'sConditions2', N'String', N'<=', N'09', N'', N'sConditions1', N'String', N'<=', N'07', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[NodeMangLoopBreak] ([auto], [FlowNode_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (123, N'284', N'Y-龍潭/利澤廠-Day>9', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions3', N'String', N'==', N'AA01', N'', N'sConditions1', N'String', N'<=', N'06', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[NodeMangLoopBreak] OFF
/****** Object:  Table [dbo].[NodeMang]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeMang](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeMang] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'107', N'Check.aspx')
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'284', N'Check.aspx')
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'309', N'Check.aspx')
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'317', N'Check.aspx')
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'357', N'Check.aspx')
INSERT [dbo].[NodeMang] ([FlowNode_id], [apName]) VALUES (N'98', N'Check.aspx')
/****** Object:  Table [dbo].[NodeMail]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeMail](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[receiveType] [nvarchar](50) NULL,
	[customEmail] [nvarchar](50) NULL,
	[dynamicTable] [nvarchar](50) NULL,
	[dynamicFdMail] [nvarchar](50) NULL,
	[isCustom] [bit] NULL,
	[subject] [nvarchar](50) NULL,
	[mailContent] [nvarchar](255) NULL,
 CONSTRAINT [PK_NodeMail] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NodeInit]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeInit](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeInit] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeInit] ([FlowNode_id], [apName]) VALUES (N'382', N'Check.aspx')
/****** Object:  Table [dbo].[NodeForm]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeForm](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeForm] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'105', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'116', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'258', N'List.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'270', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'280', N'ViewFlow.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'299', N'Form.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'302', N'FormCode.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'308', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'316', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'356', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'371', N'Std.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'379', N'Agent.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'388', N'FormDataGroup.aspx')
INSERT [dbo].[NodeForm] ([FlowNode_id], [apName]) VALUES (N'97', N'Std.aspx')
/****** Object:  Table [dbo].[NodeEnd]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeEnd](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[isMailStarter] [bit] NULL,
	[isMailAllMang] [bit] NULL,
 CONSTRAINT [PK_NodeEnd] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'106', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'259', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'276', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'281', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'288', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'300', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'303', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'311', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'322', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'362', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'377', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'380', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'385', 0, 0)
INSERT [dbo].[NodeEnd] ([FlowNode_id], [isMailStarter], [isMailAllMang]) VALUES (N'389', 0, 0)
/****** Object:  Table [dbo].[NodeDynamic]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeDynamic](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
	[tableName] [nvarchar](50) NULL,
	[fdRole] [nvarchar](100) NULL,
	[fdEmp] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeDynamic] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[NodeDynamic] ([FlowNode_id], [apName], [tableName], [fdRole], [fdEmp]) VALUES (N'383', N'Check.aspx', N'wfDynamic', N'Role_id', N'Emp_id')
INSERT [dbo].[NodeDynamic] ([FlowNode_id], [apName], [tableName], [fdRole], [fdEmp]) VALUES (N'384', N'Check.aspx', N'wfDynamic', N'Role_id', N'Emp_id')
/****** Object:  Table [dbo].[NodeCustom]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeCustom](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
	[Role_id] [nvarchar](100) NULL,
	[Emp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeCustom] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NodeAgentInit]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NodeAgentInit](
	[FlowNode_id] [nvarchar](50) NOT NULL,
	[apName] [nvarchar](50) NULL,
 CONSTRAINT [PK_NodeAgentInit] PRIMARY KEY CLUSTERED 
(
	[FlowNode_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[sCode] [nvarchar](50) NOT NULL,
	[sName] [nvarchar](50) NULL,
	[sParentCode] [nvarchar](50) NULL,
	[iSort] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[sCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'ArrangeIcons', N'全部最小化', N'Etc', 3)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Cascade', N'重疊顯示', N'Etc', 4)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Close', N'全部關閉', N'Etc', 7)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Etc', N'其它', N'', 5)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'EtcSeparator1', N'-', N'Etc', 2)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'EtcSeparator2', N'-', N'Etc', 8)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Exit', N'離開', N'Process', 4)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'ezFlow', N'流程編輯', N'Form', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmDeptView', N'部門檢視', N'Org', 2)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmOrgImport', N'組織匯入', N'Org', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmProcessError', N'錯誤回報', N'Process', 2)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmProcessFlow', N'流程監控', N'Process', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmSubWork', N'兼職設定', N'SubWork', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'fmUpdateNote', N'更新備註', N'Etc', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Form', N'表單', N'', 4)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'FormSeparator1', N'-', N'Form', 2)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Org', N'組織', N'', 3)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'Process', N'流程', N'', 1)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'ProcessSeparator1', N'-', N'Process', 3)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'SubWork', N'兼職', N'', 2)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'TeamViewer', N'遠端求助', N'Etc', 9)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'TileHorizontal', N'垂直對齊', N'Etc', 5)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'TileVertical', N'水平對齊', N'Etc', 6)
INSERT [dbo].[Menu] ([sCode], [sName], [sParentCode], [iSort]) VALUES (N'WindowsList', N'已開畫面', N'', 6)
/****** Object:  Table [dbo].[HrPost]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HrPost](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[caption] [nvarchar](50) NULL,
	[content] [ntext] NULL,
	[adate] [datetime] NULL,
	[Emp_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_HrPost] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HrNoticeFiles]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HrNoticeFiles](
	[iAutoKey] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[HrNotice_iAutoKey] [int] NOT NULL,
	[sServerName] [nvarchar](255) NOT NULL,
	[sUploadName] [nvarchar](255) NOT NULL,
	[sType] [nvarchar](50) NOT NULL,
	[iSize] [int] NOT NULL,
	[dDate] [datetime] NOT NULL,
	[sDescription] [ntext] NOT NULL,
 CONSTRAINT [PK_HrNoticeFiles] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HrNotice]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HrNotice](
	[iAutoKey] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[sCaption] [nvarchar](50) NOT NULL,
	[sContent] [ntext] NOT NULL,
	[dDateA] [datetime] NOT NULL,
	[dDateD] [datetime] NOT NULL,
	[sKeyMan] [nvarchar](50) NOT NULL,
	[dDate] [datetime] NOT NULL,
 CONSTRAINT [PK_HrNotice] PRIMARY KEY CLUSTERED 
(
	[iAutoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlowTreePowerRoleOnly]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowTreePowerRoleOnly](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FlowTree_id] [nvarchar](50) NULL,
	[Role_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_FlowTreePowerRoleOnly] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FlowTreePowerRoleOnly] ON
INSERT [dbo].[FlowTreePowerRoleOnly] ([auto], [FlowTree_id], [Role_id]) VALUES (174, N'64', N'AGA0AB0A7101')
INSERT [dbo].[FlowTreePowerRoleOnly] ([auto], [FlowTree_id], [Role_id]) VALUES (175, N'64', N'ABB0AA0C1200')
INSERT [dbo].[FlowTreePowerRoleOnly] ([auto], [FlowTree_id], [Role_id]) VALUES (176, N'76', N'ABB0C00C1220')
SET IDENTITY_INSERT [dbo].[FlowTreePowerRoleOnly] OFF
/****** Object:  Table [dbo].[FlowTreePower]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowTreePower](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FlowTree_id] [nvarchar](50) NULL,
	[Dept_path] [nvarchar](2000) NULL,
	[isAllSub] [bit] NULL,
	[PosLevel_sorting] [int] NULL,
 CONSTRAINT [PK_FlowTreePower] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FlowTreePower] ON
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (90, N'17', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (91, N'15', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (92, N'16', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (99, N'60', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (101, N'61', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (113, N'66', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (114, N'67', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (128, N'62', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (130, N'73', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (133, N'16', N'/Top', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (134, N'15', N'/Top', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (138, N'75', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (142, N'58', N'/', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (143, N'64', N'/禾伸堂/電子元件生產事業群/RAYMOND辦公室/管理中心/人資部/LT人資課', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (144, N'64', N'/禾伸堂/羅先生辦公室/總管理中心/管理戰略室/行政管理處/人資部/人事行政課', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (148, N'65', N'/禾伸堂/電子元件生產事業群/RAYMOND辦公室/管理中心/人資部/LT人資課', 1, -1000)
INSERT [dbo].[FlowTreePower] ([auto], [FlowTree_id], [Dept_path], [isAllSub], [PosLevel_sorting]) VALUES (149, N'65', N'/禾伸堂/羅先生辦公室/總管理中心/管理戰略室/行政管理處/人資部/人事行政課', 1, -1000)
SET IDENTITY_INSERT [dbo].[FlowTreePower] OFF
/****** Object:  Table [dbo].[FlowTree]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowTree](
	[id] [nvarchar](50) NOT NULL,
	[FlowGroup_id] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[dateB] [datetime] NULL,
	[dateE] [datetime] NULL,
	[isVisible] [bit] NULL,
 CONSTRAINT [PK_FlowTree] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'15', N'10', N'請假單', CAST(0x00009A6300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'16', N'10', N'加班單', CAST(0x00009A6300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'17', N'10', N'銷假單', CAST(0x00009A6300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'58', N'10', N'批次審核加班單', CAST(0x00009CFE00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'60', N'10', N'忘刷單', CAST(0x00009D1300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'61', N'17', N'流程檢視', CAST(0x00009D1A00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'62', N'10', N'公出單', CAST(0x00009D2600000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'64', N'12', N'流程設定', CAST(0x00009D4C00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'65', N'12', N'代碼設定', CAST(0x00009D4C00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'66', N'10', N'換班單(日期)', CAST(0x00009D5000000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'67', N'10', N'調班單(班別)', CAST(0x00009D5000000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'73', N'10', N'預估加班單', CAST(0x00009E0500000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'75', N'12', N'請假公出通知設定', CAST(0x00009FCF00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
INSERT [dbo].[FlowTree] ([id], [FlowGroup_id], [name], [dateB], [dateE], [isVisible]) VALUES (N'76', N'12', N'表單權限設定', CAST(0x0000A1BA00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime), 1)
/****** Object:  Table [dbo].[FlowNode]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowNode](
	[id] [nvarchar](50) NOT NULL,
	[FlowTree_id] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[nodeType] [nvarchar](50) NULL,
	[xPos] [int] NULL,
	[yPos] [int] NULL,
 CONSTRAINT [PK_FlowNode] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'100', N'15', N'服務程式', N'11', 832, 70)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'104', N'16', N'流程開始', N'1', 25, 235)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'105', N'16', N'填寫表單', N'2', 162, 235)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'106', N'16', N'流程結束', N'12', 830, 364)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'107', N'16', N'主管審核', N'3', 320, 235)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'111', N'16', N'服務程式', N'11', 512, 138)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'115', N'17', N'流程開始', N'1', 62, 252)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'116', N'17', N'填寫表單', N'2', 236, 99)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'120', N'17', N'服務程式', N'11', 452, 250)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'257', N'58', N'流程開始', N'1', 109, 242)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'258', N'58', N'填寫表單', N'2', 266, 243)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'259', N'58', N'流程結束', N'12', 543, 265)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'269', N'60', N'流程開始', N'1', 31, 197)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'270', N'60', N'填寫表單', N'2', 173, 197)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'276', N'60', N'流程結束', N'12', 567, 196)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'278', N'60', N'服務程式', N'11', 375, 196)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'279', N'61', N'流程開始', N'1', 69, 200)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'280', N'61', N'填寫表單', N'2', 218, 200)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'281', N'61', N'流程結束', N'12', 375, 200)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'282', N'62', N'流程開始', N'1', 4, 239)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'284', N'62', N'主管審核', N'3', 345, 243)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'286', N'62', N'服務程式', N'11', 538, 151)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'288', N'62', N'流程結束', N'12', 752, 149)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'298', N'64', N'流程開始', N'1', 36, 199)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'299', N'64', N'填寫表單', N'2', 229, 205)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'300', N'64', N'流程結束', N'12', 459, 217)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'301', N'65', N'流程開始', N'1', 96, 219)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'302', N'65', N'填寫表單', N'2', 293, 219)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'303', N'65', N'流程結束', N'12', 511, 205)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'307', N'66', N'流程開始', N'1', 15, 253)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'308', N'66', N'填寫表單', N'2', 157, 253)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'309', N'66', N'主管審核', N'3', 309, 253)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'310', N'66', N'服務程式', N'11', 482, 252)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'311', N'66', N'流程結束', N'12', 666, 252)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'315', N'67', N'流程開始', N'1', 5, 268)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'316', N'67', N'填寫表單', N'2', 145, 268)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'317', N'67', N'主管審核', N'3', 297, 268)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'320', N'67', N'服務程式', N'11', 467, 269)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'322', N'67', N'流程結束', N'12', 666, 267)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'355', N'73', N'流程開始', N'1', 35, 254)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'356', N'73', N'填寫表單', N'2', 204, 254)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'357', N'73', N'主管審核', N'3', 389, 254)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'361', N'73', N'服務程式', N'11', 719, 205)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'362', N'73', N'流程結束', N'12', 901, 392)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'371', N'62', N'填寫表單', N'2', 176, 240)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'377', N'17', N'流程結束', N'12', 632, 175)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'378', N'75', N'流程開始', N'1', 110, 201)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'379', N'75', N'填寫表單', N'2', 315, 200)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'380', N'75', N'流程結束', N'12', 570, 192)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'382', N'15', N'Auto Pass', N'4', 384, 412)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'383', N'15', N'人事單位', N'7', 192, 452)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'384', N'15', N'人事單位', N'7', 562, 51)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'385', N'15', N'流程結束', N'12', 831, 410)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'386', N'15', N'服務程式', N'11', 562, 209)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'387', N'76', N'流程開始', N'1', 10, 283)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'388', N'76', N'填寫表單', N'2', 191, 297)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'389', N'76', N'流程結束', N'12', 409, 335)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'96', N'15', N'流程開始', N'1', 29, 209)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'97', N'15', N'填寫表單', N'2', 193, 209)
INSERT [dbo].[FlowNode] ([id], [FlowTree_id], [name], [nodeType], [xPos], [yPos]) VALUES (N'98', N'15', N'主管審核', N'3', 382, 209)
/****** Object:  Table [dbo].[FlowLinkPower]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowLinkPower](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[FlowLink_id] [nvarchar](50) NULL,
	[note] [nvarchar](255) NULL,
	[tableName] [nvarchar](50) NULL,
	[fdName1] [nvarchar](50) NULL,
	[fdType1] [nvarchar](50) NULL,
	[criteria1] [nvarchar](50) NULL,
	[minValue1] [nvarchar](50) NULL,
	[maxValue1] [nvarchar](50) NULL,
	[fdName2] [nvarchar](50) NULL,
	[fdType2] [nvarchar](50) NULL,
	[criteria2] [nvarchar](50) NULL,
	[minValue2] [nvarchar](50) NULL,
	[maxValue2] [nvarchar](50) NULL,
	[fdName3] [nvarchar](50) NULL,
	[fdType3] [nvarchar](50) NULL,
	[criteria3] [nvarchar](50) NULL,
	[minValue3] [nvarchar](50) NULL,
	[maxValue3] [nvarchar](50) NULL,
	[fdName4] [nvarchar](50) NULL,
	[fdType4] [nvarchar](50) NULL,
	[criteria4] [nvarchar](50) NULL,
	[minValue4] [nvarchar](50) NULL,
	[maxValue4] [nvarchar](50) NULL,
	[fdName5] [nvarchar](50) NULL,
	[fdType5] [nvarchar](50) NULL,
	[criteria5] [nvarchar](50) NULL,
	[minValue5] [nvarchar](50) NULL,
	[maxValue5] [nvarchar](50) NULL,
	[fdName6] [nvarchar](50) NULL,
	[fdType6] [nvarchar](50) NULL,
	[criteria6] [nvarchar](50) NULL,
	[minValue6] [nvarchar](50) NULL,
	[maxValue6] [nvarchar](50) NULL,
 CONSTRAINT [PK_FlowLinkPower] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FlowLinkPower] ON
INSERT [dbo].[FlowLinkPower] ([auto], [FlowLink_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (131, N'463', N'y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[FlowLinkPower] ([auto], [FlowLink_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (133, N'471', N'無薪假、無薪病假', N'wfFormApp', N'sConditions6', N'String', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[FlowLinkPower] ([auto], [FlowLink_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (134, N'475', N'Y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[FlowLinkPower] ([auto], [FlowLink_id], [note], [tableName], [fdName1], [fdType1], [criteria1], [minValue1], [maxValue1], [fdName2], [fdType2], [criteria2], [minValue2], [maxValue2], [fdName3], [fdType3], [criteria3], [minValue3], [maxValue3], [fdName4], [fdType4], [criteria4], [minValue4], [maxValue4], [fdName5], [fdType5], [criteria5], [minValue5], [maxValue5], [fdName6], [fdType6], [criteria6], [minValue6], [maxValue6]) VALUES (139, N'497', N'y', N'wfFormApp', N'bSign', N'Boolean', N'==', N'1', N'', N'sConditions5', N'String', N'==', N'1', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[FlowLinkPower] OFF
/****** Object:  Table [dbo].[FlowLink]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowLink](
	[id] [nvarchar](50) NOT NULL,
	[FlowTree_id] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[linkType] [nvarchar](50) NULL,
	[linkStyle] [nvarchar](50) NULL,
	[FlowNode_idSource] [nvarchar](50) NULL,
	[FlowNode_idTarget] [nvarchar](50) NULL,
	[FlowNode_ArrowSource] [nvarchar](50) NULL,
	[FlowNode_ArrowTarget] [nvarchar](50) NULL,
 CONSTRAINT [PK_FlowLink] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'106', N'17', N'', N'3', N'1', N'115', N'116', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'287', N'58', N'', N'3', N'1', N'257', N'258', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'288', N'58', N'', N'3', N'1', N'258', N'259', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'305', N'60', N'', N'3', N'1', N'269', N'270', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'315', N'61', N'', N'3', N'1', N'279', N'280', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'316', N'61', N'', N'3', N'1', N'280', N'281', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'343', N'64', N'', N'3', N'1', N'298', N'299', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'344', N'64', N'', N'3', N'1', N'299', N'300', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'345', N'65', N'', N'3', N'1', N'301', N'302', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'346', N'65', N'', N'3', N'1', N'302', N'303', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'358', N'66', N'', N'3', N'1', N'307', N'308', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'359', N'66', N'', N'3', N'1', N'308', N'309', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'367', N'67', N'', N'3', N'1', N'315', N'316', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'368', N'67', N'', N'3', N'1', N'316', N'317', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'414', N'73', N'', N'3', N'1', N'355', N'356', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'415', N'73', N'', N'3', N'1', N'356', N'357', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'437', N'62', N'Y', N'3', N'1', N'282', N'371', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'438', N'62', N'Y', N'3', N'1', N'371', N'284', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'452', N'75', N'Y', N'3', N'1', N'378', N'379', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'453', N'75', N'Y', N'3', N'1', N'379', N'380', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'454', N'60', N'Y', N'3', N'1', N'270', N'278', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'455', N'60', N'Y', N'3', N'1', N'278', N'276', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'456', N'17', N'Y', N'3', N'1', N'116', N'120', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'457', N'17', N'Y', N'3', N'1', N'120', N'377', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'463', N'15', N'y', N'1', N'1', N'382', N'98', N'2', N'7')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'467', N'15', N'n', N'2', N'1', N'97', N'98', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'471', N'15', N'Y', N'1', N'1', N'97', N'383', N'7', N'2')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'475', N'15', N'y', N'1', N'1', N'383', N'382', N'3', N'6')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'483', N'15', N'n', N'2', N'1', N'382', N'385', N'8', N'6')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'484', N'15', N'y', N'3', N'1', N'384', N'100', N'8', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'487', N'15', N'y', N'3', N'1', N'100', N'385', N'7', N'2')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'488', N'16', N'y', N'3', N'1', N'107', N'111', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'489', N'16', N'y', N'3', N'1', N'111', N'106', N'8', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'490', N'62', N'y', N'3', N'1', N'284', N'286', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'491', N'62', N'', N'3', N'1', N'286', N'288', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'492', N'66', N'y', N'3', N'1', N'309', N'310', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'493', N'66', N'y', N'3', N'1', N'310', N'311', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'494', N'67', N'y', N'3', N'1', N'317', N'320', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'495', N'67', N'y', N'3', N'1', N'320', N'322', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'496', N'15', N'y', N'3', N'1', N'98', N'386', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'497', N'15', N'y', N'1', N'1', N'386', N'384', N'2', N'7')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'498', N'15', N'n', N'2', N'1', N'386', N'100', N'3', N'6')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'499', N'76', N'y', N'3', N'1', N'387', N'388', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'500', N'76', N'y', N'3', N'1', N'388', N'389', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'501', N'15', N'n', N'2', N'1', N'383', N'100', N'3', N'6')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'502', N'73', N'y', N'3', N'1', N'361', N'362', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'503', N'73', N'y', N'3', N'1', N'357', N'361', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'77', N'15', N'', N'3', N'1', N'96', N'97', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'86', N'16', N'', N'3', N'1', N'104', N'105', N'5', N'4')
INSERT [dbo].[FlowLink] ([id], [FlowTree_id], [name], [linkType], [linkStyle], [FlowNode_idSource], [FlowNode_idTarget], [FlowNode_ArrowSource], [FlowNode_ArrowTarget]) VALUES (N'87', N'16', N'', N'3', N'1', N'105', N'107', N'5', N'4')
/****** Object:  Table [dbo].[FlowGroup]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlowGroup](
	[id] [nvarchar](50) NOT NULL,
	[idParent] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[dateB] [datetime] NULL,
	[dateE] [datetime] NULL,
 CONSTRAINT [PK_FlowGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[FlowGroup] ([id], [idParent], [name], [dateB], [dateE]) VALUES (N'10', N'', N'人事差勤流程', CAST(0x00009A6300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime))
INSERT [dbo].[FlowGroup] ([id], [idParent], [name], [dateB], [dateE]) VALUES (N'12', N'10', N'流程設定', CAST(0x00009A6300000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime))
INSERT [dbo].[FlowGroup] ([id], [idParent], [name], [dateB], [dateE]) VALUES (N'17', N'', N'流程管理', CAST(0x00009ABF00000000 AS DateTime), CAST(0x00011D58018B80D4 AS DateTime))
/****** Object:  Table [dbo].[EmpBak]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpBak](
	[id] [nvarchar](50) NOT NULL,
	[pw] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[isNeedAgent] [bit] NULL,
	[dateB] [datetime] NULL,
	[dateE] [datetime] NULL,
	[email] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmpBak] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emp]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp](
	[id] [nvarchar](50) NOT NULL,
	[pw] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[isNeedAgent] [bit] NULL,
	[dateB] [datetime] NULL,
	[dateE] [datetime] NULL,
	[email] [nvarchar](50) NULL,
	[login] [nvarchar](50) NULL,
	[sex] [nvarchar](50) NULL,
 CONSTRAINT [PK_Emp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeptLevel]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeptLevel](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](50) NULL,
	[sorting] [decimal](16, 2) NULL,
 CONSTRAINT [PK_DeptLevel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dept]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dept](
	[id] [nvarchar](50) NOT NULL,
	[idParent] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[path] [nvarchar](2000) NULL,
	[DeptLevel_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dept] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckAgentPowerM]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckAgentPowerM](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CheckAgentAlways_auto] [int] NULL,
	[Dept_id] [nvarchar](50) NULL,
	[isAllSub] [bit] NULL,
 CONSTRAINT [PK_CheckAgentPowerM] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckAgentPowerD]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckAgentPowerD](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[CheckAgentPowerM_auto] [int] NULL,
	[FlowTree_id] [nvarchar](50) NULL,
 CONSTRAINT [PK_CheckAgentPowerD] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckAgentDefault]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckAgentDefault](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Role_idSource] [nvarchar](100) NULL,
	[Emp_idSource] [nvarchar](50) NULL,
	[Role_idTarget1] [nvarchar](100) NULL,
	[Emp_idTarget1] [nvarchar](50) NULL,
	[Role_idTarget2] [nvarchar](100) NULL,
	[Emp_idTarget2] [nvarchar](50) NULL,
	[Role_idTarget3] [nvarchar](100) NULL,
	[Emp_idTarget3] [nvarchar](50) NULL,
 CONSTRAINT [PK_CheckAgent] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CheckAgentAlways]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CheckAgentAlways](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Role_idSource] [nvarchar](100) NULL,
	[Emp_idSource] [nvarchar](50) NULL,
	[Role_idTarget] [nvarchar](100) NULL,
	[Emp_idTarget] [nvarchar](50) NULL,
 CONSTRAINT [PK_CheckAgentAlways] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutoStartLog]    Script Date: 08/28/2013 14:27:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoStartLog](
	[auto] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[ProcessFlow_id] [int] NULL,
	[adate] [datetime] NULL,
	[note] [nvarchar](50) NULL,
	[isSuccess] [bit] NULL,
 CONSTRAINT [PK_AutoStartLog] PRIMARY KEY CLUSTERED 
(
	[auto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_ProcessFlow_ProcessNode_auto]    Script Date: 08/28/2013 14:27:30 ******/
ALTER TABLE [dbo].[ProcessFlow] ADD  CONSTRAINT [DF_ProcessFlow_ProcessNode_auto]  DEFAULT ((0)) FOR [ProcessNode_auto]
GO
/****** Object:  Default [DF_ProcessNode_isMulti]    Script Date: 08/28/2013 14:27:30 ******/
ALTER TABLE [dbo].[ProcessNode] ADD  CONSTRAINT [DF_ProcessNode_isMulti]  DEFAULT ((0)) FOR [isMulti]
GO
