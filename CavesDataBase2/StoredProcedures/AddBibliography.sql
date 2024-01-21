CREATE PROCEDURE [dbo].[AddBibliography]
	@title NVARCHAR(64),
	@author NVARCHAR(32),
	@iSBN INT,
	@dataType NVARCHAR(32),
	@detail NVARCHAR(512)
AS
BEGIN
	INSERT INTO Bibliography (Title, Author, ISBN, DataType, Detail)
	VALUES (@title, @author, @iSBN, @dataType, @detail)
END
