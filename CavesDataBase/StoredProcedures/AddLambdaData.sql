CREATE PROCEDURE [dbo].[AddLambdaData]
	@localisation NVARCHAR(128),
	@topo NVARCHAR(MAX),
	@acces NVARCHAR(256),
	@equipementSheet NVARCHAR(MAX),
	@practicalInformation NVARCHAR(520),
	@description NVARCHAR(10)
AS
BEGIN
	INSERT INTO LambdaData (Localisation, Topo, Acces, EquipementSheet, PracticalInformation, Description)
	VALUES (@localisation, @topo, @acces, @equipementSheet, @practicalInformation, @description)
END
