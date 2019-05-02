CREATE TABLE [dbo].[HRReferralCodes] (
    [Code] INT            NOT NULL,
    [Role] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.HRReferralCodes] PRIMARY KEY CLUSTERED ([Code] ASC)
);

