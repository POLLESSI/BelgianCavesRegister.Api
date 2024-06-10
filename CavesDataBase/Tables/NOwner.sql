﻿CREATE TABLE [dbo].[NOwner]
(
	[NOwner_Id] INT IDENTITY, 
    [Status] NVARCHAR(256) NOT NULL, 
    [Agreement] NVARCHAR(256) NOT NULL,
	[Site_Id] INT NULL,
    [Active] BIT DEFAULT 1

    CONSTRAINT PK_NOwner PRIMARY KEY ([NOwner_Id]),
	CONSTRAINT FK_NOwner_Site FOREIGN KEY (Site_Id) REFERENCES [Site]([Site_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteNOwner]
	ON [dbo].[NOwner]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE NOwner SET Active = 0
		WHERE NOwner_Id = (SELECT NOwner_Id FROM deleted)
	END