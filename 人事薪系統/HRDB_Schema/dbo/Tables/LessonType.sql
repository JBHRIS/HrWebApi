CREATE TABLE [dbo].[LessonType] (
    [LessonCode] NVARCHAR (50) NOT NULL,
    [LessonName] NVARCHAR (50) NOT NULL,
    [KeyDate]    DATETIME      NOT NULL,
    [KeyMan]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_LessonType] PRIMARY KEY CLUSTERED ([LessonCode] ASC)
);

