CREATE PROCEDURE [dbo].[AddNOwner]
	@status NVARCHAR(256),
	@agreement NVARCHAR(256)
AS
BEGIN 
	INSERT INTO NOwner (Status, Agreement)
	VALUES (@status, @agreement)
END
