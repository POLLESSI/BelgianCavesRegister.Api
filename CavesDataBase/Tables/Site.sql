CREATE TABLE [dbo].[Site]
(
	[Site_Id] INT IDENTITY, 
    [Site_Name] NVARCHAR(32) NOT NULL UNIQUE, 
    [Site_Description] NVARCHAR(256) NOT NULL, 
    [Latitude] DECIMAL(8, 6) NULL, 
    [Longitude] DECIMAL(9, 6) NULL, 
    [Length] DECIMAL(7, 2) NOT NULL, 
    [Depth] DECIMAL(6, 2) NULL, 
    [AccessRequirement] NVARCHAR(256) NULL UNIQUE, 
    [PracticalInformation] NVARCHAR(512) NULL, 
    [Active] BIT DEFAULT 1


    CONSTRAINT PK_Site PRIMARY KEY ([Site_Id]),
    CONSTRAINT UK_AccessRequirement UNIQUE (AccessRequirement)
)
--ON DELETE SET NULL ON UPDATE Cascade
GO

CREATE TRIGGER [dbo].[OnDeleteSite]
	ON [dbo].[Site]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE Site SET Active = 0
		WHERE Site_Id = (SELECT Site_Id FROM deleted)
	END