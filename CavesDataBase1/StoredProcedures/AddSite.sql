CREATE PROCEDURE [dbo].[AddSite]
	@site_Name NVARCHAR(32),
	@site_Description NVARCHAR(256),
	@latitude REAL,
	@longitude REAL,
	@length DECIMAL(5, 2),
	@depth DECIMAL(5, 2),
	@accessRequirement NVARCHAR(256),
	@practicalInformation NVARCHAR(512),
	@donneesLambda_Id INT,
	@nOwner_Id INT,
	@scientificData_Id INT,
	@bibliography_Id INT
AS
BEGIN
	INSERT INTO Site (Site_Name, Site_Description, Latitude, Longitude, [Length], Depth, AccessRequirement, PracticalInformation, DonneesLambda_Id, NOwner_Id, ScientificData_Id, Bibliography_Id)
	VALUES (@site_Name, @site_Description, @latitude, @longitude, @length, @depth, @accessRequirement, @practicalInformation, @donneesLambda_Id, @nOwner_Id, @scientificData_Id, @bibliography_Id)
END
