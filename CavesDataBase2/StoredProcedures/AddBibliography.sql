CREATE PROCEDURE [dbo].[AddBibliography]
	@title NVARCHAR(64),
	@author NVARCHAR(32),
	@iSBN NVARCHAR(16),
	@dataType NVARCHAR(64),
	@detail NVARCHAR(512)
AS
BEGIN
	INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail)
	VALUES (@title, @author, @iSBN, @dataType, @detail)
END
