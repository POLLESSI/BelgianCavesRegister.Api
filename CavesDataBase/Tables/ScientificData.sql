﻿CREATE TABLE [dbo].[ScientificData]
(
	[ScientificData_Id] INT IDENTITY, 
    [DataType] NVARCHAR(128) NOT NULL, 
    [DetailsData] NVARCHAR(512) NULL, 
    [ReferenceData] NVARCHAR(256) NOT NULL,
    [Active] BIT DEFAULT 1

    CONSTRAINT PK_ScientificData PRIMARY KEY ([ScientificData_Id]),
)

GO

CREATE TRIGGER [dbo].[OnDeleteScientificData]
	ON [dbo].[ScientificData]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE ScientificData SET Active = 0
		WHERE ScientificData_Id = (SELECT ScientificData_Id FROM deleted)
	END
