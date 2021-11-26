CREATE TABLE [dbo].[ApplicationStructure] (
    [NodeID]           INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationID]    INT            NOT NULL,
    [ParentID]         INT            NOT NULL,
    [ApplicationName]  NVARCHAR (100) NOT NULL,
    [DataAdapterID]    INT            NOT NULL,
    [CustomizeSetting] NVARCHAR (MAX) NOT NULL,
    [ApplicationType]  NVARCHAR (50)  NOT NULL,
    [CreateMan]        NVARCHAR (50)  NOT NULL,
    [CreateTime]       DATETIME       NOT NULL,
    [Guid]             NVARCHAR (50)  CONSTRAINT [DF_ApplicationStructure_Guid] DEFAULT ('') NOT NULL,
    [Tag]              NVARCHAR (50)  CONSTRAINT [DF_ApplicationStructure_Tag] DEFAULT ('') NOT NULL,
    [Field01]          NVARCHAR (50)  NULL,
    [Field02]          NVARCHAR (50)  NULL,
    [Field03]          NVARCHAR (50)  NULL,
    [Field04]          NVARCHAR (50)  NULL,
    [Field05]          NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ApplicationStructure] PRIMARY KEY CLUSTERED ([NodeID] ASC)
);

