CREATE PROCEDURE [dbo].[UpdateBibliography]
	@title NVARCHAR(64),
	@author NVARCHAR(32),
	@iSBN NVARCHAR(16),
	@dataType NVARCHAR(64),
	@detail NVARCHAR(512),
	@bibliography_Id INT
AS
	UPDATE Bibliography SET Title = @title,
							Author = @author,
							ISBN = @iSBN,
							DataType = @dataType,
							Detail = @detail
	WHERE Bibliography_Id = @bibliography_Id
