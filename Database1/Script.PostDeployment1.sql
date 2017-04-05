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
MERGE INTO Table1 AS Target 
USING (VALUES 
  (0, N'Undefined'), 
  (1, N'Billing'), 
  (2, N'Home'), 
  (3, N'Main Office'), 
  (4, N'Primary'), 
  (5, N'Shipping'), 
  (6, N'Archive') 
) 
AS Source (Id, Name) 
ON Target.Id = Source.Id 
WHEN MATCHED THEN 
	UPDATE SET Name = Source.Name 
WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name) 
	VALUES (Id, Name) 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;