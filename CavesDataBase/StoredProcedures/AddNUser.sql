CREATE PROCEDURE [dbo].[AddNUser]
	
	@pseudo NVARCHAR(64),
	@passwordHash BINARY(64),
	@securityStamp UNIQUEIDENTIFIER,
	@email NVARCHAR(64),
	@role_Id INT
	
AS
BEGIN
	INSERT INTO NUser (Pseudo, PasswordHash, SecurityStamp, Email, Role_Id)
	VALUES (@pseudo, @passwordHash, @securityStamp, @email, @role_Id)
END
