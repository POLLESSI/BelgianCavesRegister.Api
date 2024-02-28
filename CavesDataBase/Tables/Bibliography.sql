CREATE TABLE [dbo].[Bibliography]
(
	[Bibliography_Id] INT IDENTITY, 
    [Title] NVARCHAR(64) NOT NULL, 
    [Author] NVARCHAR(32) NOT NULL, 
    [ISBN] NVARCHAR(16) NOT NULL, 
    [DataType] NVARCHAR(32) NOT NULL, 
    [Detail] NVARCHAR(512) NOT NULL,
    [Active] BIT DEFAULT 1

    CONSTRAINT PK_Biography PRIMARY KEY ([Bibliography_Id]),
)

GO

CREATE TRIGGER [dbo].[OnDeleteBibliography]
    ON [dbo].[Bibliography]
    INSTEAD OF DELETE
    AS
    BEGIN
        UPDATE Bibliography SET Active = 0
        WHERE Bibliography_Id = (SELECT Bibliography_Id FROM deleted)
    END