CREATE PROCEDURE [dbo].[CreateScientificData]
	@dataType NVARCHAR(128),
	@detailsData NVARCHAR(512),
	@referenceData NVARCHAR(256)
AS
BEGIN
	INSERT INTO ScientificData (DataType, DetailsData, ReferenceData)
	VALUES (@dataType, @detailsData, @referenceData)
END
