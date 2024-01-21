CREATE PROCEDURE [dbo].[UpdateLambdaData]
	@localisation NVARCHAR(128),
	@topo NVARCHAR(MAX),
	@acces NVARCHAR(256),
	@equipementSheet NVARCHAR(512),
	@practicalInformation NVARCHAR(512),
	@description NVARCHAR(10),
	@donneesLambda_Id INT
AS
	UPDATE LambdaData SET Localisation = @localisation,
						  Topo = @topo,
						  Acces = @acces,
						  EquipementSheet = @equipementSheet,
						  PracticalInformation = @practicalInformation,
						  [Description] = @description

	WHERE DonneesLambda_Id = @donneesLambda_Id