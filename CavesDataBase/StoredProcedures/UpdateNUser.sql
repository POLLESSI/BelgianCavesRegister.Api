CREATE PROCEDURE [dbo].[UpdateNUser]
	
	@pseudo NVARCHAR(64),
	@passwordHash BINARY(64),
	@SecurityStamp UNIQUEIDENTIFIER,
	@email NVARCHAR(64),
	@role_Id INT,
	@nUser_Id UNIQUEIDENTIFIER
	
AS
	UPDATE NUser SET Pseudo = @pseudo,
					PasswordHash = @passwordHash,
					SecurityStamp = @SecurityStamp,
					Email = @email,
					Role_Id = @role_Id

	WHERE NUser_Id = @nUser_Id
