CREATE TABLE [dbo].[HRBlackList] (
    [AutoKey]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [IDNO]     NVARCHAR (50)  NOT NULL,
    [JOB]      NVARCHAR (50)  NULL,
    [Reason]   NVARCHAR (100) NULL,
    [OUDT]     DATETIME       NULL,
    [Remark]   NVARCHAR (500) NULL,
    [Key_Date] DATETIME       NOT NULL,
    [Key_Man]  NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_BlackList] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

