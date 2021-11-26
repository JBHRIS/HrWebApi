CREATE TABLE [dbo].[qBaseM] (
    [iAutoKey]       INT           IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [sCode]          NVARCHAR (50) NOT NULL,
    [sTypeCode]      NVARCHAR (50) NOT NULL,
    [sNobr]          NVARCHAR (50) NOT NULL,
    [sPW]            NVARCHAR (50) NOT NULL,
    [sName]          NVARCHAR (50) NOT NULL,
    [sDeptCode]      NVARCHAR (50) CONSTRAINT [DF_qBaseM_sDeptCode] DEFAULT ('') NOT NULL,
    [sDeptName]      NVARCHAR (50) CONSTRAINT [DF_qBaseM_sDeptName] DEFAULT ('') NOT NULL,
    [dAmountDate]    DATETIME      NOT NULL,
    [dWriteDate]     DATETIME      CONSTRAINT [DF_qBaseM_dWriteDate] DEFAULT (getdate()) NOT NULL,
    [dSchoolDateB]   DATETIME      CONSTRAINT [DF_qBaseM_dSchoolDateB] DEFAULT (getdate()) NOT NULL,
    [dSchoolDateE]   DATETIME      CONSTRAINT [DF_qBaseM_dSchoolDateE] DEFAULT (getdate()) NOT NULL,
    [sYYMM]          NVARCHAR (50) NOT NULL,
    [sSer]           NVARCHAR (50) NOT NULL,
    [sCourseCode]    NVARCHAR (50) NOT NULL,
    [sCourseName]    NVARCHAR (50) CONSTRAINT [DF_qBaseM_sCourseName] DEFAULT ('') NOT NULL,
    [sNatureCode]    NVARCHAR (50) CONSTRAINT [DF_qBaseM_sNatureCode] DEFAULT ('') NOT NULL,
    [sNatureName]    NVARCHAR (50) CONSTRAINT [DF_qBaseM_sNatureName] DEFAULT ('') NOT NULL,
    [sDocentCode]    NVARCHAR (50) CONSTRAINT [DF_qBaseM_sDocentCode] DEFAULT ('') NOT NULL,
    [sDocentName]    NVARCHAR (50) CONSTRAINT [DF_qBaseM_sDocentName] DEFAULT ('') NOT NULL,
    [iTotalFraction] INT           NOT NULL
);

