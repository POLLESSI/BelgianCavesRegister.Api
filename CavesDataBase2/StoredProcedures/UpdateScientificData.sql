CREATE PROCEDURE [dbo].[UpdateScientificData]
	@dataType NVARCHAR(128),
	@detailsData NVARCHAR(512),
	@refrerenceData NVARCHAR(256),
	@scientificData_Id INT
AS
	UPDATE ScientificData SET DataType = @dataType,
							  DetailsData = @detailsData,
							  ReferenceData = @refrerenceData
	WHERE ScientificData_Id = @scientificData_Id
