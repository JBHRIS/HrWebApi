/****** Object:  Table [dbo].[ABASET]    Script Date: 2019/11/4 ¤W¤È 11:50:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SALARYCALC](
	[GUID] uniqueidentifier PRIMARY KEY NOT NULL DEFAULT newid() ,
	[SOURCE] nvarchar(50) NOT NULL,
	[USERID] nvarchar(50) NOT NULL,
	[TIMEB] datetime NULL,
	[TIMEE] datetime NULL,
);
GO

CREATE TABLE [dbo].[WriteRuleNobrTable]  
(
	[AUTOKEY] INT IDENTITY PRIMARY KEY NOT NULL,
	[GUID] uniqueidentifier NOT NULL,
	[EMPID] nvarchar(50) NOT NULL,  
	[KEY_DATE] datetime NOT NULL  
);  
GO  
