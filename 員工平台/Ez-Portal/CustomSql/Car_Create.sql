USE [CHPTHR]
GO

/****** Object:  Table [dbo].[Car]    Script Date: 11/20/2013 22:57:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CarId] [nvarchar](50) NOT NULL,
	[LicensePlate] [nvarchar](50) NULL,
	[EnableSchedueRent] [bit] NOT NULL,
	[CanRent] [bit] NOT NULL,
 CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Car] ADD  CONSTRAINT [DF_Car_EnableSchedueRent]  DEFAULT ((0)) FOR [EnableSchedueRent]
GO

ALTER TABLE [dbo].[Car] ADD  CONSTRAINT [DF_Car_CanRent]  DEFAULT ((1)) FOR [CanRent]
GO

