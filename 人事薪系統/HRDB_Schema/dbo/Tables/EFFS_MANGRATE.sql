CREATE TABLE [dbo].[EFFS_MANGRATE] (
    [AutoKey]  INT            IDENTITY (1, 1) NOT NULL,
    [yy]       INT            NULL,
    [seq]      INT            NULL,
    [nobr]     NVARCHAR (10)  NULL,
    [arrprate] DECIMAL (5, 2) NULL,
    [caterate] DECIMAL (5, 2) NULL,
    [mangnobr] NVARCHAR (10)  NULL
);

