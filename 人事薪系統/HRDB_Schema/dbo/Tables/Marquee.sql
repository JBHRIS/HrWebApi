CREATE TABLE [dbo].[Marquee] (
    [ID]          INT             IDENTITY (1, 1) NOT NULL,
    [DisplayText] NVARCHAR (1000) NOT NULL,
    [Enable]      BIT             CONSTRAINT [DF_Marquee_Enable] DEFAULT ((1)) NOT NULL,
    [StartDate]   DATETIME        NOT NULL,
    [EndDate]     DATETIME        NOT NULL,
    CONSTRAINT [PK_Marquee] PRIMARY KEY CLUSTERED ([ID] ASC)
);

