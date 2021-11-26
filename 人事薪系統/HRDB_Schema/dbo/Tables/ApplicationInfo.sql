CREATE TABLE [dbo].[ApplicationInfo] (
    [ApplicationID]       INT            IDENTITY (1, 1) NOT NULL,
    [ApplicationName]     NVARCHAR (100) NOT NULL,
    [ApplicationCategory] NVARCHAR (100) NOT NULL,
    [AssemblyName]        NVARCHAR (100) NOT NULL,
    [ClassName]           NVARCHAR (100) NOT NULL,
    [Remark]              NVARCHAR (MAX) NOT NULL,
    [CreateMan]           NVARCHAR (100) NOT NULL,
    [CreateTime]          DATETIME       NOT NULL,
    CONSTRAINT [PK_ApplicationInfo] PRIMARY KEY CLUSTERED ([ApplicationID] ASC)
);

