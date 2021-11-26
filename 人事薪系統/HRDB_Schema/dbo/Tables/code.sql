CREATE TABLE [dbo].[code] (
    [key]   VARCHAR (50)  NOT NULL,
    [value] NVARCHAR (50) NOT NULL,
    [type]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_code] PRIMARY KEY CLUSTERED ([key] ASC, [type] ASC)
);

