CREATE PROCEDURE [dbo].[sqlUtilisateurLogin]
	@Email NVARCHAR(64),
	@Password NVARCHAR(64)
AS

BEGIN
	SET NOCOUNT OFF;

	DECLARE @PasswordHash BINARY(64), @SecurityStamp UNIQUEIDENTIFIER;

	SET @SecurityStamp = (SELECT SecurityStamp FROM [NUser] where Email = @Email)
	SET @PasswordHash = dbo.fHasher(@PasswordHash, @SecurityStamp)

	IF EXISTS (SELECT TOP 1 * FROM [NUser] WHERE Email = @Email AND PasswordHash = @PasswordHash)
	BEGIN
		SELECT * INTO #TempNUser
		FROM [NUser]
		WHERE Email LIKE @Email
		ALTER TABLE #TempNUser
		DROP COLUMN PasswordHash, SecurityStamp
		SELECT * FROM #TempNUser
		DROP TABLE #TempNUser
	END

	RETURN 0
END
