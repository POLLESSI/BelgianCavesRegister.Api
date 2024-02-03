CREATE PROCEDURE [dbo].[CreateNOwner]
	@status NVARCHAR(256),
	@agrement NVARCHAR(256)
AS
BEGIN
	INSERT INTO NOwner ([Status], Agreement)
	VALUES (@status, @agrement)
END