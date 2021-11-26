if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MangUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[MangUser]
GO

CREATE TABLE [dbo].[MangUser] (
	[type] [char] (1) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[nobr] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[name_c] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[key_man] [char] (10) COLLATE Chinese_Taiwan_Stroke_CI_AS NOT NULL ,
	[key_date] [datetime] NOT NULL 
) ON [PRIMARY]
GO

