CREATE TABLE [dbo].[news] (
    [news_id]            NVARCHAR (50)  NOT NULL,
    [news_head]          NVARCHAR (200) CONSTRAINT [DF_news_news_head] DEFAULT ('') NOT NULL,
    [news_body]          NVARCHAR (MAX) CONSTRAINT [DF_news_news_body] DEFAULT ('') NOT NULL,
    [post_date]          DATETIME       CONSTRAINT [DF_news_post_date] DEFAULT (getdate()) NOT NULL,
    [post_deadline]      DATETIME       NOT NULL,
    [is_on]              BIT            CONSTRAINT [DF_news_is_on] DEFAULT ((0)) NOT NULL,
    [newsfileid]         NVARCHAR (50)  CONSTRAINT [DF_news_newsfileid] DEFAULT ('') NOT NULL,
    [PublishAllEmp]      NVARCHAR (50)  CONSTRAINT [DF_news_PublishAllEmp] DEFAULT ('1') NOT NULL,
    [LatestSendMailDate] DATETIME       NULL,
    [AttachmentCount]    INT            CONSTRAINT [DF_news_AttachmentCount] DEFAULT ((0)) NOT NULL,
    [sort]               BIGINT         CONSTRAINT [DF_news_sort] DEFAULT ((0)) NOT NULL,
    [BrowsingNumber]     INT            CONSTRAINT [DF_news_BrowsingNumber] DEFAULT ((0)) NOT NULL,
    [iAutokey]           INT            IDENTITY (1, 1) NOT NULL,
    [KEY_MAN]            NVARCHAR (50)  NULL,
    [KEY_DATE]           DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([iAutokey] ASC)
);





