CREATE TABLE [dbo].[Ticket]
(
	[ID] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [TicketDescription] NVARCHAR(1000) NULL, 
    [Comment] NVARCHAR(400) NULL, 
    [Severity] NCHAR(100) NULL, 
    [DateCreated] DATETIME NULL, 
    [IsResolved] BIT NULL
)
