CREATE TABLE [dbo].[NotifyClass] (
    [Code]         NVARCHAR (50)  NOT NULL,
    [Comp]         NVARCHAR (50)  NOT NULL,
    [DisplayName]  NVARCHAR (50)  NOT NULL,
    [AssemblyName] NVARCHAR (50)  NOT NULL,
    [ClassName]    NVARCHAR (50)  NOT NULL,
    [Memo]         NVARCHAR (50)  NOT NULL,
    [Title]        NVARCHAR (50)  NOT NULL,
    [Message]      NVARCHAR (MAX) NOT NULL,
    [Status]       NVARCHAR (50)  NOT NULL,
    [Sort]         INT            NOT NULL,
    [KeyDate]      DATETIME       NOT NULL,
    [KeyMan]       NVARCHAR (50)  NOT NULL,
    [NOTIFYDAY]    INT            NOT NULL,
    [RELATIONAPP]  NVARCHAR (50)  NULL,
    CONSTRAINT [PK_NotifyType] PRIMARY KEY CLUSTERED ([Code] ASC, [Comp] ASC)
);



