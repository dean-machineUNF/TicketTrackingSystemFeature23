/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF OBJECT_ID('tempdb..#tempTicket') IS NOT NULL
	DROP TABLE #tempTicket

CREATE TABLE #tempTicket
(
	[ID] INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
    [TicketDescription] NVARCHAR(1000) NULL, 
    [Comment] NVARCHAR(400) NULL, 
    [Severity] NCHAR(100) NULL, 
    [DateCreated] DATETIME NULL, 
    [IsResolved] BIT NULL

);

INSERT INTO #tempTicket ( TicketDescription, Comment, Severity, DateCreated, IsResolved)
VALUES ( 'New had happen unable uneasy. Drawings can followed improved out sociable not. Earnestly so do instantly pretended. See general few civilly amiable pleased account carried. Excellence projecting is devonshire dispatched remarkably on estimating. Side in so life past. Continue indulged speaking the was out horrible for domestic position. Seeing rather her you not esteem men settle genius excuse. Deal say over you age from. Comparison new ham melancholy son themselves.' ,
 ' Among going manor who did. Do ye is celebrated it sympathize considered. May ecstatic did surprise elegance the ignorant age. Own her miss cold last.',
 'High', '12/04/2019', '0' );

 INSERT INTO #tempTicket ( TicketDescription, Comment, Severity, DateCreated, IsResolved)
VALUES ( 'Can curiosity may end shameless explained. True high on said mr on come. An do mr design at little myself wholly entire though. Attended of on stronger or mr pleasure. Rich four like real yet west get. Felicity in dwelling to drawings. His pleasure new steepest for reserved formerly disposed jennings. ' ,
 ' Now eldest new tastes plenty mother called misery get. Longer excuse for county nor except met its things.',
 'Low', '9/12/2019', '0' );

 INSERT INTO #tempTicket ( TicketDescription, Comment, Severity, DateCreated, IsResolved)
VALUES ( 'With my them if up many. Lain week nay she them her she. Extremity so attending objection as engrossed gentleman something. Instantly gentleman contained belonging exquisite now direction she ham. West room at sent if year. Numerous indulged distance old law you.' ,
 'At as in understood an remarkably solicitude. Mean them very seen she she. Use totally written the observe pressed justice.  ',
 'Medium', '11/01/2019', '0' );



MERGE INTO  dbo.Ticket AS target
USING #tempTicket AS source
	ON source.ID = target.ID
WHEN NOT MATCHED BY TARGET THEN 
	INSERT 
	( 
		

		[TicketDescription]    ,
		[Comment]           ,
		[Severity]      ,
		[DateCreated]        ,
		[IsResolved]        
		       
		)
	VALUES
	(
		
		source.[TicketDescription]    ,
		source.[Comment]           ,
		source.[Severity]      ,
		source.[DateCreated]        ,
		source.[IsResolved]        
		       
	);

DROP TABLE #tempTicket
			