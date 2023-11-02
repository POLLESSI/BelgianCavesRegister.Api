CREATE PROCEDURE [dbo].[sqlNUserRegister]
	@Email NVARCHAR(64),
	@Pseudo NVARCHAR(64),
	@Password NVARCHAR(64)
AS

BEGIN
	DECLARE @passwordHash BINARY(64), @securityStamp UNIQUEIDENTIFIER;

	SET @securityStamp = NEWID()
	SET @passwordHash = dbo.fHasher (TRIM(@Password), @securityStamp)

	INSERT INTO NUser (Email, Pseudo, PasswordHash, SecurityStamp)
	VALUES (TRIM(@Email), TRIM(@Pseudo), @passwordHash, @securityStamp)
END
