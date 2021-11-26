/****** Object:  Table [dbo].[SalaryTransferBank]    Script Date: 2021/10/27 ¤W¤È 11:59:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SalaryTransferBank](
	[AUTO] [int] IDENTITY(1,1) NOT NULL,
	[COMP_ID] [nvarchar](max) NOT NULL,
	[COMP_NO] [nvarchar](max) NOT NULL,
	[COMP_NAME] [nvarchar](max) NOT NULL,
	[COMPANY_BANK_AC] [nvarchar](max) NOT NULL,
	[COMPANY_BANK_NO] [nvarchar](max) NOT NULL,
	[COMPANY_BANK_NAME] [nvarchar](max) NULL,
	[COMPANY_BANK_ID] [nvarchar](max) NOT NULL,
	[COMPANY_BANK_USER] [nvarchar](max) NOT NULL,
	[COMPANY_BRANCH_CODE] [nvarchar](max) NOT NULL,
	[COMPANY_BANK_LENGTH] [int] NOT NULL,
	[COMP_HAS_HEADER] [bit] NOT NULL,
	[COMP_HAS_FOOTER] [bit] NOT NULL,
	[COMP_DATE_TYPE] [nvarchar](max) NOT NULL,
	[KEY_MAN] [nvarchar](50) NOT NULL,
	[KEY_DATE] [datetime] NOT NULL,
	[GUID] [nvarchar](50) NULL,
 CONSTRAINT [PK_SalaryTransferBank] PRIMARY KEY CLUSTERED 
(
	[AUTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
