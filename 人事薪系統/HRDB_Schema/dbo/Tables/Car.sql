CREATE TABLE [dbo].[Car] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (50) NOT NULL,
    [CarId]             NVARCHAR (50) NOT NULL,
    [LicensePlate]      NVARCHAR (50) NULL,
    [EnableSchedueRent] BIT           CONSTRAINT [DF_Car_EnableSchedueRent] DEFAULT ((0)) NOT NULL,
    [CanRent]           BIT           CONSTRAINT [DF_Car_CanRent] DEFAULT ((1)) NOT NULL,
    [DispBackColor]     INT           NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC)
);

