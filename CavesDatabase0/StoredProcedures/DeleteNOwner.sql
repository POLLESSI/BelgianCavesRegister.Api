CREATE PROCEDURE [dbo].[DeleteNOwner]
	@nOwner_Id INT
AS
	DELETE FROM NOwner WHERE NOwner_Id = @nOwner_Id
RETURN 0
