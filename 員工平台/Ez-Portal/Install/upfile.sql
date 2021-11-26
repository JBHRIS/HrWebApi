if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UPFILE]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[UPFILE]
GO

CREATE TABLE [dbo].[UPFILE] (
	[autoKey] [int] IDENTITY (1, 1) NOT NULL ,
	[newsfileid] [nvarchar] (20) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[upfilename] [nvarchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[serverfilename] [nvarchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[filetype] [nvarchar] (200) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[filesize] [nvarchar] (100) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL ,
	[upfiledate] [datetime] NULL ,
	[filedesc] [varchar] (500) COLLATE Chinese_Taiwan_Stroke_CI_AS NULL 
) ON [PRIMARY]
GO

