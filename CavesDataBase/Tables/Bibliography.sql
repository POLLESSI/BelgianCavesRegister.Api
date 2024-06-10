CREATE TABLE [dbo].[Bibliography]
(
	[Bibliography_Id] INT IDENTITY, 
    [Title] NVARCHAR(64) NOT NULL, 
    [Author] NVARCHAR(32) NOT NULL, 
    [ISBN] NVARCHAR(16) NOT NULL, 
    [DataType] NVARCHAR(32) NOT NULL, 
    [Detail] NVARCHAR(512) NOT NULL,
    [Site_Id] INT NULL,
    [Active] BIT DEFAULT 1

    CONSTRAINT PK_Bibliography PRIMARY KEY ([Bibliography_Id]),
    CONSTRAINT FK_Bibliography_Site FOREIGN KEY (Site_Id) REFERENCES [Site]([Site_Id])
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