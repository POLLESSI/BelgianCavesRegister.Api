CREATE TABLE [dbo].[Site]
(
	[Site_Id] INT IDENTITY,
	[Site_Name] NVARCHAR(32) NOT NULL UNIQUE,
	[Site_Description] NVARCHAR(256) NOT NULL,
	[Latitude] REAL NULL UNIQUE,
	[Longitude] REAL NULL UNIQUE,
	[Length] DECIMAL(5, 2) NOT NULL,
	[Depth] DECIMAL(5, 2) NULL,
	[AccessRequirement] NVARCHAR(256) NOT NULL UNIQUE,
	[PracticalInformation] NVARCHAR(512) NULL,
	[DonneesLambda_Id] INT,
	[NOwner_Id] INT,
	[ScientificData_Id] INT,
	[Bibliography_Id] INT,
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_Site PRIMARY KEY ([Site_Id]),
	CONSTRAINT FK_Site_LambdaData FOREIGN KEY ([DonneesLambda_Id]) REFERENCES [LambdaData]([DonneesLambda_Id]),
	CONSTRAINT FK_Site_NOwner FOREIGN KEY ([NOwner_Id]) REFERENCES [NOwner]([NOwner_Id]),
	CONSTRAINT FK_Site_ScientificData FOREIGN KEY ([ScientificData_Id]) REFERENCES [ScientificData]([ScientificData_Id]),
	CONSTRAINT FK_Site_Bibliography FOREIGN KEY (Bibliography_Id) REFERENCES [Bibliography]([Bibliography_Id]),
	CONSTRAINT UK_AccessRequirement UNIQUE (AccessRequirement)
)

GO

CREATE TRIGGER [dbo].[OnDeleteSite]
	ON [dbo].[Site]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE [Site] SET Active = 0
		WHERE Site_Id = (SELECT Site_Id FROM deleted)
	END