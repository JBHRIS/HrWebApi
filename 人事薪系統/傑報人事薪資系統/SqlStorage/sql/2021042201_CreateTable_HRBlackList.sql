/****** Object:  Table [dbo].[HRBlackList]    Script Date: 2021/4/22 ¤W¤È 10:07:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[HRBlackList](
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IDNO] [nvarchar](50) NOT NULL,
	[JOB] [nvarchar](50) NULL,
	[Reason] [nvarchar](100) NULL,
	[OUDT] [datetime] NULL,
	[Remark] [nvarchar](500) NULL,
	[Key_Date] [datetime] NOT NULL,
	[Key_Man] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


