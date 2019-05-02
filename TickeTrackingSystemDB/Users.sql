CREATE TABLE [dbo].[Users] (
    [UserID]    INT            IDENTITY (1, 1) NOT NULL,
    [UserEmail] NVARCHAR (MAX) NULL,
    [Password]  NVARCHAR (MAX) NULL,
    [UserRole]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);