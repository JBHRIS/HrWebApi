CREATE TABLE [dbo].[HcodeType] (
    [HTYPE]           NVARCHAR (50) NOT NULL,
    [TYPE_NAME]       NVARCHAR (50) NOT NULL,
    [GetCode]         NVARCHAR (50) NOT NULL,
    [Sort]            INT           NOT NULL,
    [YearMax]         NCHAR (10)    NOT NULL,
    [AutoCreateHours] BIT           NOT NULL,
    [MergeDisplay]    BIT           NOT NULL,
    [Unit]            NVARCHAR (50) NOT NULL,
    [KEY_DATE]        DATETIME      NOT NULL,
    [KEY_MAN]         NVARCHAR (50) NOT NULL,
    [ExtendCode]      NVARCHAR (50) NULL,
    [ExpireCode]      NVARCHAR (50) NULL,
    [HTYPE_DISP]      NVARCHAR (50) NULL,
    CONSTRAINT [PK_HcodeType] PRIMARY KEY CLUSTERED ([HTYPE] ASC)
);



