Alter Table Bankcode ADD CodePage int DEFAULT 950 NOT NULL
GO
/****** Object:  Table [dbo].[EncodingTable]    Script Date: 2019/11/21 下午 05:38:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncodingTable](
	[Autokey] [int] IDENTITY(1,1) NOT NULL,
	[CodePage] [int] NOT NULL,
	[CodeDSP] [nvarchar](50) NOT NULL,
	[CodeName] [nvarchar](50) NOT NULL,
	[KEY_MAN] [nvarchar](50) NULL,
	[KEY_DATE] [datetime] NULL,
 CONSTRAINT [PK_EncodingTable] PRIMARY KEY CLUSTERED 
(
	[Autokey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EncodingTable] ON 

INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (1, 936, N'gb2312', N'簡體中文（GB2312）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (2, 950, N'big5', N'繁體中文（Big5）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (3, 1200, N'utf-16', N'Unicode', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (4, 1201, N'unicodeFFFE', N'Unicode （大 endian）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (5, 1252, N'Windows-1252', N'西歐語系（Windows）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (6, 10003, N'x-mac-韓文', N'韓文（Mac）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (7, 10008, N'x-mac-chinesesimp', N'簡體中文（Mac）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (8, 12000, N'utf-32', N'Unicode （UTF-32）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (9, 12001, N'utf-32BE', N'Unicode （UTF-32 Big endian）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (10, 20127, N'us-ascii', N'US-ASCII	', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (11, 20936, N'x-cp20936', N'簡體中文（GB2312-80）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (12, 20949, N'x-cp20949', N'韓文 Korean-wansung-unicode', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (13, 28591, N'iso-8859-1', N'西歐語系（ISO）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (14, 28598, N'iso-8859-8', N'希伯來文（ISO-視覺效果）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (15, 38598, N'iso-8859-8-i', N'希伯來文（ISO-邏輯）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (16, 50220, N'iso-2022-jp', N'日文（JIS）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (17, 50221, N'csISO2022JP', N'日文（JIS-允許1個位元組的假名）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (18, 50222, N'iso-2022-jp', N'日文（JIS-允許1個位元組的假名-SO/SI）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (19, 50225, N'iso-2022-kr', N'韓文（ISO）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (20, 50227, N'x-cp50227', N'簡體中文（ISO-2022）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (21, 51932, N'euc-jp', N'日文（EUC）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (22, 51936, N'EUC-CN', N'簡體中文（EUC）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (24, 51949, N'euc-kr', N'韓文（EUC）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (25, 52936, N'hz-gb-2312', N'簡體中文（HZ）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (26, 54936, N'GB18030', N'簡體中文（GB18030）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (27, 57002, N'x-iscii-de', N'ISCII 梵文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (28, 57003, N'x-iscii-be', N'ISCII 孟加拉國文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (29, 57004, N'x-iscii-ta', N'ISCII 泰米爾', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (30, 57005, N'x-iscii-te', N'ISCII 泰盧固文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (31, 57006, N'x-iscii-as', N'ISCII 阿薩姆文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (32, 57007, N'x-iscii-or', N'ISCII 奧裡亞文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (33, 57008, N'x-iscii-ka', N'ISCII 埃納卡', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (34, 57009, N'x-iscii-ma', N'ISCII 馬拉雅拉姆', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (35, 57010, N'x-iscii-gu', N'ISCII 古吉拉特文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (36, 57011, N'x-iscii-pa', N'ISCII 旁遮普文', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (37, 65000, N'utf-7', N'Unicode （UTF-7）', N'JB', NULL)
INSERT [dbo].[EncodingTable] ([Autokey], [CodePage], [CodeDSP], [CodeName], [KEY_MAN], [KEY_DATE]) VALUES (38, 65001, N'utf-8', N'Unicode (UTF-8)', N'JB', NULL)
SET IDENTITY_INSERT [dbo].[EncodingTable] OFF
