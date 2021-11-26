CREATE TABLE [dbo].[ResetPasswordKey] (
    [ResetKey]     NVARCHAR (50) NOT NULL,
    [Nobr]         NVARCHAR (50) NOT NULL,
    [DeadLineTime] DATETIME      NOT NULL,
    [KeyDate]      DATETIME      NOT NULL,
    [KeyMan]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ResetPasswordKey] PRIMARY KEY CLUSTERED ([ResetKey] ASC)
);

