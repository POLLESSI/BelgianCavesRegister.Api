CREATE PROCEDURE [dbo].[DeleteBibliography]
	@bibliography_Id INT
AS
	DELETE FROM Bibliography WHERE Bibliography_Id = @bibliography_Id 
RETURN 0