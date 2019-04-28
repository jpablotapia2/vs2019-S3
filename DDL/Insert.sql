ALTER PROCEDURE usp_InsertArtist
(
 @Name nvarchar(120)
)
AS
BEGIN
	--DECLARE @nroReg INT

	--SELECT @nroReg = COUNT(1) FROM Artist WHERE Name = @Name

	--IF(@nroReg=0)
	IF (NOT EXISTS(SELECT ArtistId from Artist WHERE Name = @Name))
	BEGIN
		INSERT INTO Artist(Name)
		VALUES (@Name)

		SELECT SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
GO



CREATE PROCEDURE usp_UpdateArtist
(
 @ArtistId int,
 @Name nvarchar(120)
)
AS
BEGIN
	IF NOT EXISTS(SELECT ArtistId FROM Artist WHERE Name=@Name)
	BEGIN
		UPDATE Artist SET Name=@Name 
		WHERE ArtistId=@ArtistId 
	END

END
GO

CREATE PROCEDURE usp_DeleteArtist
(
 @ArtistId int
)
AS
BEGIN

	DELETE FROM Artist WHERE ArtistId=@ArtistId

END
GO

EXEC usp_DeleteArtist 282