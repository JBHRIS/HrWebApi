CREATE TABLE [dbo].[NotifyParameterMaster] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NotifyMasterId] INT            NOT NULL,
    [ParameterCode]  NVARCHAR (50)  NOT NULL,
    [ParameterName]  NVARCHAR (50)  NOT NULL,
    [Value]          NVARCHAR (MAX) NOT NULL,
    [DataType]       NCHAR (50)     NOT NULL,
    [FieldType]      NCHAR (50)     NOT NULL,
    [Source]         NVARCHAR (MAX) NOT NULL,
    [CreateTime]     DATETIME       NOT NULL,
    [CreateMan]      NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_NotifyParameterMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

