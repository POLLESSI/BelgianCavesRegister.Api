CREATE PROCEDURE [dbo].[UpdateScientificData]
	@dataType NVARCHAR(128),
	@detailsData NVARCHAR(512),
	@referenceData NVARCHAR(256),
	@scientificData_Id INT
AS
	UPDATE ScientificData SET DataType = @dataType,
							  DetailsData = @detailsData,
							  ReferenceData = @referenceData
	WHERE ScientificData_Id = @scientificData_Id
