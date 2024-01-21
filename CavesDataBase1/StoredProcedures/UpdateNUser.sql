CREATE PROCEDURE [dbo].[UpdateNUser]
	@pseudo NVARCHAR(64),
	@passwordHash BINARY(64),
	@securityStamp UNIQUEIDENTIFIER,
	@email NVARCHAR(64),
	@nPerson_Id INT,
	@role_Id INT,
	@nUser_Id UNIQUEIDENTIFIER
AS
	UPDATE NUser SET Pseudo = @pseudo,
					 PasswordHash = @passwordHash,
					 SecurityStamp = @securityStamp,
					 Email = @email,
					 NPerson_Id = @nPerson_Id,
					 Role_Id = @role_Id
	WHERE NUser_Id = @nUser_Id
