CREATE TABLE [dbo].[ApplicationUserRule] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [ApplicationID]   INT           NOT NULL,
    [UserID]          NVARCHAR (50) NOT NULL,
    [CanAdd]          BIT           NOT NULL,
    [CanEdit]         BIT           NOT NULL,
    [CanDelete]       BIT           NOT NULL,
    [CanExport]       BIT           NOT NULL,
    [CreateMan]       NVARCHAR (50) NOT NULL,
    [CreateTime]      DATETIME      NOT NULL,
    [ApplicationType] NVARCHAR (50) CONSTRAINT [DF_Table_1_Guid] DEFAULT ('') NOT NULL,
    [Tag]             NVARCHAR (50) CONSTRAINT [DF_ApplicationUserRule_Tag] DEFAULT ('') NOT NULL,
    [Field01]         NVARCHAR (50) NULL,
    [Field02]         NVARCHAR (50) NULL,
    [Field03]         NVARCHAR (50) NULL,
    [Field04]         NVARCHAR (50) NULL,
    [Field05]         NVARCHAR (50) NULL,
    CONSTRAINT [PK_ApplicationUserRule] PRIMARY KEY CLUSTERED ([ID] ASC)
);

