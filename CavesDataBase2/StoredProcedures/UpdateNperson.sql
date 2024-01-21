CREATE PROCEDURE [dbo].[UpdateNperson]
	@lastname NVARCHAR(32),
	@firstname NVARCHAR(32),
	@birthDate DATE,
	@email NVARCHAR(64),
	@address_Street NVARCHAR(64),
	@address_Nbr INT,
	@postalCode INT,
	@address_City NVARCHAR(64),
	@address_Country NVARCHAR(64), 
	@telephone INT,
	@gsm INT,
	@nPerson_Id INT
AS
	UPDATE NPerson SET Lastname = @lastname,
					   Fistname = @firstname,
					   Email = @email,
					   Address_Street = @address_Street, 
					   Address_Nbr = @address_Nbr,
					   PostalCode = @postalCode,
					   Address_City = @address_City,
					   Address_Country = @address_Country,
					   Telephone = @telephone, 
					   Gsm = @gsm
	WHERE NPerson_Id = @nPerson_Id
