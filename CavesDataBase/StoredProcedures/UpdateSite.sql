CREATE PROCEDURE [dbo].[UpdateSite]
	@site_Name NVARCHAR(32),
	@site_Description NVARCHAR(256),
	@latitude REAL,
	@longitude REAL,
	@length DECIMAL(3, 2),
	@depth DECIMAL(3, 2),
	@accesRequirement NVARCHAR(256),
	@practicalInformation NVARCHAR(512),
	@donneesLamda_Id INT,
	@nOwner_Id INT,
	@scientificData_Id INT,
	@bibliography_Id INT,
	@active BIT,
	@site_Id INT

AS
	UPDATE Site SET Site_Name = @site_Name,
					Site_Description = @site_Description,
					Latitude = @latitude,
					Longitude = @longitude,
					Length = @length,
					Depth = @depth,
					AccessRequirement = @accesRequirement,
					PracticalInformation = @practicalInformation,
					DonneesLambda_Id = @donneesLamda_Id,
					NOwner_Id = @nOwner_Id,
					ScientificData_Id = @scientificData_Id,
					Active = @active
	WHERE Site_Id = @site_Id