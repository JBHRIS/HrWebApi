CREATE TABLE [dbo].[DiversionAttendType] (
    [DiversionAttendType]     NVARCHAR (50)    NOT NULL,
    [DiversionAttendTypeName] NVARCHAR (50)    NOT NULL,
    [CheckWFH_Attend]         BIT              NOT NULL,
    [CheckWorkLog]            BIT              NOT NULL,
    [CheckWebCard]            BIT              NOT NULL,
    [CheckTemperoturyReport]  BIT              NOT NULL,
    [KeyDate]                 DATETIME         NOT NULL,
    [KeyMan]                  NVARCHAR (50)    NOT NULL,
    [AutoKey]                 INT              IDENTITY (1, 1) NOT NULL,
    [Guid]                    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_DiversionAttendType] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

