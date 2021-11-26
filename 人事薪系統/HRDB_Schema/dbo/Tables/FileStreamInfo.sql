CREATE TABLE [dbo].[FileStreamInfo] (
    [FileID]        INT             IDENTITY (1, 1) NOT NULL,
    [FileName]      NVARCHAR (100)  NOT NULL,
    [ExtensionName] NVARCHAR (50)   NOT NULL,
    [FullName]      NVARCHAR (1000) NOT NULL,
    [FileStream]    VARBINARY (MAX) NOT NULL,
    [FileSize]      BIGINT          NOT NULL,
    [FileTicket]    NVARCHAR (50)   NOT NULL,
    [CreateMan]     NVARCHAR (50)   NOT NULL,
    [CreateTime]    DATETIME        NOT NULL,
    CONSTRAINT [PK_FileStreamInfo] PRIMARY KEY CLUSTERED ([FileID] ASC)
);

