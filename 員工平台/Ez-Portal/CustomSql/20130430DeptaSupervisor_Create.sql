

/****** Object:  Table [dbo].[DeptaSupervisor]    Script Date: 2013/5/8 下午 03:07:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DeptaSupervisor](
	[AutoKey] [int] IDENTITY(1,1) NOT NULL,
	[D_No] [nvarchar](50) NOT NULL,
	[SupervisorNobr] [nvarchar](50) NOT NULL,
	[AddOrDel] [bit] NOT NULL,
	[KeyMan] [nvarchar](50) NULL,
	[KeyDate] [datetime] NULL,
 CONSTRAINT [PK_DeptaSupervisor] PRIMARY KEY CLUSTERED 
(
	[AutoKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[DeptaSupervisor] ADD  CONSTRAINT [DF_DeptaSupervisor_AddOrDel]  DEFAULT ((1)) FOR [AddOrDel]
GO

