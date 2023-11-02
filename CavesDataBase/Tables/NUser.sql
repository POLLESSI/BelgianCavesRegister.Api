CREATE TABLE [dbo].[NUser]
(
	[NUser_Id] UNIQUEIDENTIFIER DEFAULT NEWID(), 
    [Pseudo] NVARCHAR(64) NOT NULL UNIQUE, 
    [PasswordHash] BINARY(64) NULL,
    [SecurityStamp] UNIQUEIDENTIFIER NULL,
    [Email] NVARCHAR(64) NOT NULL UNIQUE, 
    [NPerson_Id] INT NOT NULL,
    [Role_Id] INT NOT NULL DEFAULT 1,
    [Active] BIT DEFAULT 1

    CONSTRAINT [CK_NUser_Email] CHECK (Email like '__%@__%_%'),
    CONSTRAINT PK_NUser PRIMARY KEY ([NUser_Id]),
    CONSTRAINT [FK_NUser_NPerson] FOREIGN Key (NPerson_Id) REFERENCES [NPerson] ([NPerson_Id]),
    --ON DELETE CASCADE
    --ON UPDATE CASCADE

)

GO

CREATE TRIGGER [dbo].[OnDeleteUser]
	ON [dbo].[NUser]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE NUser SET Active = 0
		WHERE NUser_Id = (SELECT NUser_Id FROM deleted)
	END
