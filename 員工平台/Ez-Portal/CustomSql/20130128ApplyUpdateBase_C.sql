USE [HOLYSTONEHR_T]
GO

/****** Object:  Table [dbo].[ApplyUpdateBase]    Script Date: 01/28/2013 23:59:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ApplyUpdateBase](
	[Pk] [int] IDENTITY(1,1) NOT NULL,
	[Approve] [bit] NULL,
	[ApproveMan] [nvarchar](50) NULL,
	[ApproveDatetime] [datetime] NULL,
	[ApplyMan] [nvarchar](50) NOT NULL,
	[ApplyDatetime] [datetime] NOT NULL,
	[GSM] [nvarchar](50) NOT NULL,
	[EMAIL] [nvarchar](60) NOT NULL,
	[TEL1] [nvarchar](50) NOT NULL,
	[TEL2] [nvarchar](50) NOT NULL,
	[POSTCODE1] [nvarchar](50) NOT NULL,
	[ADDR1] [nvarchar](60) NOT NULL,
	[POSTCODE2] [nvarchar](50) NOT NULL,
	[ADDR2] [nvarchar](60) NOT NULL,
	[PROVINCE] [nvarchar](50) NOT NULL,
	[BORN_ADDR] [nvarchar](50) NOT NULL,
	[CONT_MAN] [nvarchar](50) NOT NULL,
	[CONT_REL1] [nvarchar](50) NOT NULL,
	[CONT_TEL] [nvarchar](50) NOT NULL,
	[CONT_GSM] [nvarchar](50) NOT NULL,
	[CONT_MAN2] [nvarchar](50) NOT NULL,
	[CONT_REL2] [nvarchar](50) NOT NULL,
	[CONT_TEL2] [nvarchar](50) NOT NULL,
	[CONT_GSM2] [nvarchar](50) NOT NULL,
	[GSM_Old] [nvarchar](50) NOT NULL,
	[EMAIL_Old] [nvarchar](60) NOT NULL,
	[TEL1_Old] [nvarchar](50) NOT NULL,
	[TEL2_Old] [nvarchar](50) NOT NULL,
	[POSTCODE1_Old] [nvarchar](50) NOT NULL,
	[ADDR1_Old] [nvarchar](60) NOT NULL,
	[POSTCODE2_Old] [nvarchar](50) NOT NULL,
	[ADDR2_Old] [nvarchar](60) NOT NULL,
	[PROVINCE_Old] [nvarchar](50) NOT NULL,
	[BORN_ADDR_Old] [nvarchar](50) NOT NULL,
	[CONT_MAN_Old] [nvarchar](50) NOT NULL,
	[CONT_REL1_Old] [nvarchar](50) NOT NULL,
	[CONT_TEL_Old] [nvarchar](50) NOT NULL,
	[CONT_GSM_Old] [nvarchar](50) NOT NULL,
	[CONT_MAN2_Old] [nchar](10) NOT NULL,
	[CONT_REL2_Old] [nvarchar](50) NOT NULL,
	[CONT_TEL2_Old] [nvarchar](50) NOT NULL,
	[CONT_GSM2_Old] [nvarchar](50) NOT NULL,
	[GSM_IsChanged] [bit] NOT NULL,
	[EMAIL_IsChanged] [bit] NOT NULL,
	[TEL1_IsChanged] [bit] NOT NULL,
	[TEL2_IsChanged] [bit] NOT NULL,
	[POSTCODE1_IsChanged] [bit] NOT NULL,
	[ADDR1_IsChanged] [bit] NOT NULL,
	[POSTCODE2_IsChanged] [bit] NOT NULL,
	[ADDR2_IsChanged] [bit] NOT NULL,
	[PROVINCE_IsChanged] [bit] NOT NULL,
	[BORN_ADDR_IsChanged] [bit] NOT NULL,
	[CONT_MAN_IsChanged] [bit] NOT NULL,
	[CONT_REL1_IsChanged] [bit] NOT NULL,
	[CONT_TEL_IsChanged] [bit] NOT NULL,
	[CONT_GSM_IsChanged] [bit] NOT NULL,
	[CONT_MAN2_IsChanged] [bit] NOT NULL,
	[CONT_REL2_IsChanged] [bit] NOT NULL,
	[CONT_TEL2_IsChanged] [bit] NOT NULL,
	[CONT_GSM2_IsChanged] [bit] NOT NULL,
 CONSTRAINT [PK_ApplyUpdateBase] PRIMARY KEY CLUSTERED 
(
	[Pk] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_GSM_IsChanged]  DEFAULT ((0)) FOR [GSM_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_EMAIL_IsChanged]  DEFAULT ((0)) FOR [EMAIL_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_TEL1_IsChanged]  DEFAULT ((0)) FOR [TEL1_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_TEL2_IsChanged]  DEFAULT ((0)) FOR [TEL2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_POSTCODE1_IsChanged]  DEFAULT ((0)) FOR [POSTCODE1_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_ADDR1_IsChanged]  DEFAULT ((0)) FOR [ADDR1_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_POSTCODE2_IsChanged]  DEFAULT ((0)) FOR [POSTCODE2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_ADDR2_IsChanged]  DEFAULT ((0)) FOR [ADDR2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_PROVINCE_IsChanged]  DEFAULT ((0)) FOR [PROVINCE_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_BORN_ADDR_IsChanged]  DEFAULT ((0)) FOR [BORN_ADDR_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_MAN_IsChanged]  DEFAULT ((0)) FOR [CONT_MAN_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_REL1_IsChanged]  DEFAULT ((0)) FOR [CONT_REL1_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_TEL_IsChanged]  DEFAULT ((0)) FOR [CONT_TEL_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_GSM_IsChanged]  DEFAULT ((0)) FOR [CONT_GSM_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_MAN2_IsChanged]  DEFAULT ((0)) FOR [CONT_MAN2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_REL2_IsChanged]  DEFAULT ((0)) FOR [CONT_REL2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_TEL2_IsChanged]  DEFAULT ((0)) FOR [CONT_TEL2_IsChanged]
GO

ALTER TABLE [dbo].[ApplyUpdateBase] ADD  CONSTRAINT [DF_ApplyUpdateBase_CONT_GSM2_IsChanged]  DEFAULT ((0)) FOR [CONT_GSM2_IsChanged]
GO

