﻿CREATE FUNCTION [dbo].[fHasher]
(
	@PasswordHash VARCHAR(128),
	@SecurityStamp UNIQUEIDENTIFIER
)
RETURNS BINARY(64)
AS
BEGIN
	DECLARE @hashedValue VARBINARY(64) = CONVERT(BINARY(64), CONCAT(HASHBYTES('SHA_512', (@PasswordHash + CAST(@SecurityStamp AS VARCHAR(36)))), @SecurityStamp))
	RETURN @hashedvalue
END
