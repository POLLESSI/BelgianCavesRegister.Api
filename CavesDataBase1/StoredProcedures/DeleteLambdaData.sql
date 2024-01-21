CREATE PROCEDURE [dbo].[DeleteLambdaData]
	@donneesLambda_Id INT
AS
	DELETE FROM LambdaData WHERE DonneesLambda_Id = @donneesLambda_Id
RETURN 0