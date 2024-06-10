CREATE TABLE [dbo].[Chat]
(
	[Chat_Id] INT IDENTITY,
	[NewMessage] NVARCHAR(128) NULL,
	[Author] NVARCHAR(32) NOT NULL,
	[Site_Id] INT NULL,
	[SendingDate] DATE DEFAULT GETDATE(),
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_Chat PRIMARY KEY ([Chat_Id]),
	CONSTRAINT FK_Chat_Site FOREIGN KEY (Site_Id) REFERENCES [Site]([Site_Id]),
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
