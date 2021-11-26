CREATE TABLE [dbo].[EFFS_ATTEND] (
    [autoKey]   INT            IDENTITY (1, 1) NOT NULL,
    [yy]        INT            NOT NULL,
    [seq]       INT            NOT NULL,
    [Desc]      NVARCHAR (200) NOT NULL,
    [keydate]   DATETIME       NOT NULL,
    [StdDate]   DATETIME       NOT NULL,
    [EndDate]   DATETIME       NOT NULL,
    [type]      NVARCHAR (10)  NULL,
    [n_yy]      INT            NULL,
    [n_seq]     INT            NULL,
    [s_yy]      INT            NULL,
    [s_seq]     INT            NULL,
    [att_adate] DATETIME       NULL,
    [att_ddate] DATETIME       NULL
);

