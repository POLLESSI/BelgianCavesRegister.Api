CREATE PROCEDURE [dbo].[UpdateNOwner]
	@status NVARCHAR(256),
	@agreement NVARCHAR(256),
	@nOwner_Id INT
AS
	UPDATE NOwner SET [Status] = @status,
					  Agreement = @agreement
	WHERE NOwner_Id = @nOwner_Id
