

/****** Object:  Table [dbo].[FileStreamInfo]    Script Date: 2017/11/11 ¤W¤È 01:06:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FileStreamInfo](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](100) NOT NULL,
	[ExtensionName] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[FileStream] [varbinary](max) NOT NULL,
	[FileSize] [bigint] NOT NULL,
	[FileTicket] [nvarchar](50) NOT NULL,
	[CreateMan] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_FileStreamInfo] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

