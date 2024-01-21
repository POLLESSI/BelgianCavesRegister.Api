CREATE PROCEDURE [dbo].[AddChat]
	@newMessage NVARCHAR(256),
	@author NVARCHAR(128)
AS
BEGIN
	INSERT INTO Chat (newMessage, Author)
	VALUES (@newMessage, @author)
END
