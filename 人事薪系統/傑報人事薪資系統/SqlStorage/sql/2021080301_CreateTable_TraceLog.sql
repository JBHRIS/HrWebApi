CREATE TABLE [dbo].[TraceLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Source] [nvarchar](50) NULL,
	[Inserted] [xml] NULL,
	[Deleted] [xml] NULL,
	[CreateTime] [datetime] NULL,
 CONSTRAINT [PK_TraceLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO