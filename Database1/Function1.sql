CREATE  FUNCTION [dbo].[Function1]
(
	@param1 nvarchar(1)
)
RETURNS @returntable TABLE
(
	Id int,
	Name nchar(50)
)
AS
BEGIN
	INSERT @returntable
	SELECT Id, Name FROM Table1 WHERE CHARINDEX(@param1, Name) = 1 
	RETURN
END
