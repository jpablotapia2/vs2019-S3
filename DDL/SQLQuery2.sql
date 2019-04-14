create procedure usp_GetAll
(
	@filterByName NVARCHAR(100)
)
AS
BEGIN
	SELECT * FROM Artist E
	WHERE Name LIKE @filterByName
END


EXEC usp_GetAll 'AERO%'