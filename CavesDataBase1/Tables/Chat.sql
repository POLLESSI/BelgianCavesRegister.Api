﻿CREATE TABLE [dbo].[Chat]
(
	[Chat_Id] INT IDENTITY,
	[newMessage] NVARCHAR(256),
	[Author] NVARCHAR(128) NOT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_Chat PRIMARY KEY ([Chat_Id]),

	--ON DELETE SET NULL
	--ON UPDATE CASCADE
)

GO

CREATE TRIGGER [dbo].[OnDeleteChat]
	ON [dbo].[Chat]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Chat SET Active = 0
		WHERE Chat_Id = (SELECT Chat_Id FROM deleted)
	END