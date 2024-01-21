CREATE PROCEDURE [dbo].[DeleteScientificData]
	@scientificData_Id INT
AS
	DELETE FROM ScientificData WHERE ScientificData_Id = @scientificData_Id
RETURN 0
