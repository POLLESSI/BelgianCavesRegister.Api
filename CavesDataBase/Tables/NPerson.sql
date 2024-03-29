﻿CREATE TABLE [dbo].[NPerson]
(
	[NPerson_Id] INT NOT NULL IDENTITY,
	[Lastname] NVARCHAR(32) NOT NULL,
	[Firstname] NVARCHAR(32) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[Email] NVARCHAR(64) NOT NULL UNIQUE,
	[Address_Street] NVARCHAR(64) NOT NULL,
	[Address_Nbr] NVARCHAR(8) NOT NULL,
	[PostalCode] NVARCHAR(8) NOT NULL,
	[Address_City] NVARCHAR(64) NOT NULL,
	[Address_Country] NVARCHAR(64),
	[Telephone] NVARCHAR(16) NULL,
	[Gsm] NVARCHAR(16) NULL,
	[Active] BIT DEFAULT 1
	
	CONSTRAINT PK_NPerson PRIMARY KEY ([NPerson_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteNPerson]
	ON [dbo].[NPerson]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE NPerson SET Active = 0
		WHERE NPerson_Id = (SELECT NPerson_Id FROM deleted) 
	END	
