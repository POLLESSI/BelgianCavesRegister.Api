CREATE TABLE [dbo].[WeatherForecast]
(
	[WeatherForecast_Id] INT IDENTITY,
	[Date] SMALLDATETIME NULL,
	[TemperatureC] INT NOT NULL,
	[TemperatureF] INT NULL,
	[Summary] NVARCHAR(256) NOT NULL,
	[Description] NVARCHAR(256) NOT NULL,
	[Humidity] INT NOT NULL,
	[Precipitation] FLOAT NOT NULL,
	[Active] BIT DEFAULT 1

	CONSTRAINT PK_WeatherForecast PRIMARY KEY ([WeatherForecast_Id])
)

GO

CREATE TRIGGER [dbo].[OnDeleteWeatherForecast]
	ON [dbo].[WeatherForecast]
	INSTEAD OF DELETE
	AS
	BEGIN
		UPDATE WeatherForecast SET Active = 0
		WHERE WeatherForecast_Id = (SELECT WeatherForecast_Id FROM deleted)
	END