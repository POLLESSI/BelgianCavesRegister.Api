CREATE PROCEDURE [dbo].[DeleteNPerson]
	@nPerson_Id INT
AS
	DELETE FROM NPerson WHERE NPerson_Id = @nPerson_Id