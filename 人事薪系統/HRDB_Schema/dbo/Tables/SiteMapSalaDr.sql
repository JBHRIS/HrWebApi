CREATE TABLE [dbo].[SiteMapSalaDr] (
    [Pid]         INT             IDENTITY (1, 1) NOT NULL,
    [SALADR_Code] NVARCHAR (50)   NOT NULL,
    [SiteMapUrl]  NVARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_SiteMapSalaDr] PRIMARY KEY CLUSTERED ([Pid] ASC)
);

