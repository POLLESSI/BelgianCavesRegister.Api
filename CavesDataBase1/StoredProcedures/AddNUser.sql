CREATE PROCEDURE [dbo].[AddNUser]
	@pseudo NVARCHAR(64),
	@passwordHash BINARY(64),
	@securityStamp UNIQUEIDENTIFIER,
	@email NVARCHAR(64),
	@nPerson_Id INT,
	@role_Id INT
AS
BEGIN
	INSERT INTO NUser (Pseudo, PasswordHash, SecurityStamp, Email, NPerson_Id, Role_Id)
	VALUES (@pseudo, @passwordHash, @securityStamp, @email, @nPerson_Id, @role_Id)
END
