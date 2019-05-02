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


IF OBJECT_ID('tempdb..#tempHRReferralCodes') IS NOT NULL
	DROP TABLE #tempTicket

CREATE TABLE #tempHRReferralCodes (
    [Code] INT            NOT NULL,
    [Role] NVARCHAR (100) NULL,
    CONSTRAINT [PK_dbo.HRReferralCodes] PRIMARY KEY CLUSTERED ([Code] ASC)
);

INSERT INTO #tempHRReferralCodes ( Code, Role)
VALUES ( '4101989' ,
 'ADMIN' );

 INSERT INTO #tempHRReferralCodes ( Code, Role)
VALUES ( '11011989' ,
 'USER' );


MERGE INTO  dbo.HRReferralCodes AS target
USING #tempHRReferralCodes AS source
	ON source.Code = target.Code
WHEN NOT MATCHED BY TARGET THEN 
	INSERT 
	( 
		

		[Code]    ,
		[Role]           
		
		)
	VALUES
	(
		
		source.[Code]    ,
		source.[Role]           
		    
		       
	);

DROP TABLE #tempHRReferralCodes
			