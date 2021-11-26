CREATE TABLE [dbo].[AppConfig] (
    [Category]    NVARCHAR (50)   NOT NULL,
    [Code]        NVARCHAR (50)   NOT NULL,
    [Comp]        NVARCHAR (50)   NOT NULL,
    [NameP]       NVARCHAR (50)   NOT NULL,
    [Value]       NVARCHAR (2000) NOT NULL,
    [Note]        NVARCHAR (500)  NOT NULL,
    [DataType]    NVARCHAR (50)   NOT NULL,
    [ControlType] NVARCHAR (50)   NOT NULL,
    [DataSource]  NVARCHAR (500)  NOT NULL,
    [Sort]        INT             NOT NULL,
    [KeyDate]     DATETIME        NOT NULL,
    [KeyMan]      NVARCHAR (50)   NOT NULL,
    CONSTRAINT [PK_AppConfig] PRIMARY KEY CLUSTERED ([Category] ASC, [Code] ASC, [Comp] ASC)
);

