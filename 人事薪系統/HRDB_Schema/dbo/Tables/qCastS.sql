CREATE TABLE [dbo].[qCastS] (
    [iAutoKey]   INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]      NVARCHAR (50) NOT NULL,
    [sThemeCode] NVARCHAR (50) NOT NULL,
    [iOrder]     INT           NOT NULL
);

