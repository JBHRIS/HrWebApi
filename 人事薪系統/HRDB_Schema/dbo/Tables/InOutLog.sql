CREATE TABLE [dbo].[InOutLog] (
    [Autokey]        INT           NOT NULL,
    [EmployeeID]     NVARCHAR (20) NOT NULL,
    [Type]           NVARCHAR (20) NOT NULL,
    [InOutTime]      DATETIME      NOT NULL,
    [DataSource]     NVARCHAR (20) NOT NULL,
    [CreateBy]       NVARCHAR (20) NOT NULL,
    [CreateDate]     DATETIME      NOT NULL,
    [LastUpdateBy]   NVARCHAR (20) NOT NULL,
    [LastUpdateDate] DATETIME      NOT NULL
);

