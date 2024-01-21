CREATE PROCEDURE [dbo].[DeleteSite]
	@site_Id INT
AS
	DELETE FROM [Site] WHERE Site_Id = @site_Id
RETURN 0
