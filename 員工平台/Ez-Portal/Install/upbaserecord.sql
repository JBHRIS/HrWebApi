if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpBaseRecord]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[UpBaseRecord]
GO

CREATE TABLE [dbo].[UpBaseRecord] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[nobr] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name_c] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[updescr] [text] COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[key_date] [datetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

