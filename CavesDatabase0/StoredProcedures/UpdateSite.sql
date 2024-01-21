CREATE PROCEDURE [dbo].[UpdateSite]
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
	@bibliography_Id INT,
	@site_Id INT
AS
	UPDATE [Site] SET Site_Name = @site_Name,
					  Site_Description = @site_Description,
					  Latitude = @latitude,
					  Longitude = @longitude,
					  [Length] = @length,
					  Depth = @depth,
					  AccessRequirement = @accessRequirement,
					  PracticalInformation = @practicalInformation,
					  DonneesLambda_Id = @donneesLambda_Id,
					  NOwner_Id = @nOwner_Id,
					  ScientificData_Id = @scientificData_Id,
					  Bibliography_Id = @bibliography_Id
	WHERE Site_Id = @site_Id