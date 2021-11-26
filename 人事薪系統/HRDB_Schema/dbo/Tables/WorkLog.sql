CREATE TABLE [dbo].[WorkLog] (
    [EmployeeId]  NVARCHAR (50)    NOT NULL,
    [AttendDate]  DATETIME         NOT NULL,
    [BeginTime]   NVARCHAR (50)    NOT NULL,
    [EndTime]     NVARCHAR (50)    NOT NULL,
    [WorkHours]   DECIMAL (16, 2)  NOT NULL,
    [Workitem]    NVARCHAR (50)    NULL,
    [Description] NVARCHAR (50)    NULL,
    [FileId]      NVARCHAR (50)    NULL,
    [KeyDate]     DATETIME         NOT NULL,
    [KeyMan]      NVARCHAR (50)    NOT NULL,
    [AutoKey]     INT              IDENTITY (1, 1) NOT NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_WorkLog] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

