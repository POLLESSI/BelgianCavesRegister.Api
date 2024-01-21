CREATE PROCEDURE [dbo].[DeleteChat]
	@chat_Id INT
AS
	DELETE FROM Chat WHERE Chat_Id = @chat_Id
