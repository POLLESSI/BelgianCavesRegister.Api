﻿CREATE PROCEDURE [dbo].[AddNPerson]
	@lastname NVARCHAR(32),
	@firstname NVARCHAR(32),
	@email NVARCHAR(64),
	@address_Street NVARCHAR(64),
	@address_Nbr INT,
	@postalCode INT,
	@address_City NVARCHAR(64),
	@address_Country NVARCHAR(64),
	@telephone INT,
	@gsm INT
AS
BEGIN
	INSERT INTO NPerson (Lastname, Firstname, Email, Address_Street, Address_Nbr, PostalCode, Address_City, Address_Country, Telephone, Gsm)
	VALUES (@lastname, @firstname, @email, @address_Street, @address_Nbr, @postalCode, @address_City, @address_Country, @telephone, @gsm)
END
