CREATE TABLE [dbo].[U_SYS7] (
    [AUTO]            INT           IDENTITY (1, 1) NOT NULL,
    [CARD_NAME]       NVARCHAR (50) NULL,
    [NOBR_POS]        INT           NULL,
    [NOBR_LEN]        INT           NULL,
    [SER_POS]         INT           NULL,
    [SER_LEN]         INT           NULL,
    [DATE_POS]        INT           NULL,
    [DATE_LEN]        INT           NULL,
    [TIME_POS]        INT           NULL,
    [TIME_LEN]        INT           NULL,
    [CARDDATEFORMAT]  NVARCHAR (50) NULL,
    [CARDNOEUQALNOBR] BIT           NULL,
    [SPILT_SIGNAL]    NVARCHAR (50) NULL,
    [TEXT_TYPE]       NVARCHAR (50) NULL,
    [IGNORE_SIGNAL]   NVARCHAR (50) NULL,
    [CODE_POS]        INT           NULL,
    [CODE_LEN]        INT           NULL,
    [DATE_FORMAT]     NVARCHAR (50) NULL,
    [TIME_FORMAT]     NVARCHAR (50) NULL,
    [TEMPERATURE_POS] INT           DEFAULT ((0)) NULL,
    [TEMPERATURE_LEN] INT           DEFAULT ((0)) NULL,
    CONSTRAINT [PK_U_SYS7] PRIMARY KEY CLUSTERED ([AUTO] ASC)
);



