CREATE TABLE [dbo].[jqForeignKey] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [SettingID]    INT           NOT NULL,
    [ParentID]     INT           NOT NULL,
    [ParentTable]  NVARCHAR (50) NOT NULL,
    [ParentColumn] NVARCHAR (50) NOT NULL,
    [ChildID]      INT           NOT NULL,
    [ChildTable]   NVARCHAR (50) NOT NULL,
    [ChildColumn]  NVARCHAR (50) NOT NULL,
    [CreateMan]    NVARCHAR (50) NOT NULL,
    [CreateDate]   DATETIME      NOT NULL,
    CONSTRAINT [PK_jqForeignKey] PRIMARY KEY CLUSTERED ([ID] ASC)
);

