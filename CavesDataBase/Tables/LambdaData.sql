CREATE TABLE [dbo].[LambdaData]
(
	[DonneesLambda_Id] INT IDENTITY, 
    [Localisation] NVARCHAR(128) NOT NULL, 
    [Topo] NVARCHAR(2048) NOT NULL, 
    [Acces] NVARCHAR(256) NOT NULL, 
    [EquipementSheet] NVARCHAR(2048) NULL, 
    [PracticalInformation] NVARCHAR(512) NOT NULL, 
    [Description] NVARCHAR(128) NOT NULL,
	[Site_Id] INT NOT NULL,
    [Active] BIT DEFAULT 1

    CONSTRAINT PK_LamndaData PRIMARY KEY (DonneesLambda_Id),
	CONSTRAINT FK_LambdaData FOREIGN KEY (Site_Id) REFERENCES [Site]([Site_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteLambdaData]
	ON [dbo].[LambdaData]
	INSTEAD OF DELETE
	AS 
	BEGIN
		UPDATE LambdaData SET Active = 0
		WHERE DonneesLambda_Id = (SELECT DonneesLambda_Id FROM deleted)
	END