
CREATE TABLE [dbo].[WeatherForecast2] (
    [Id]          INT            NOT NULL Primary Key,
    [Date]        DATE           NULL,
    [Temperature] FLOAT (53)     NULL,
    [Wind]        NVARCHAR (100) NULL,
    [WindSpeed]   FLOAT (53)     NULL,
    [Humidity]    FLOAT (53)     NULL,
    [Pressure]    FLOAT (53)     NULL,
    [Cloudliness] NVARCHAR (100) NULL,
    [SunRise]     TIME (7)       NULL,
    [SunSet]      TIME (7)       NULL,
    [CityId]      INT            NOT NULL

	FOREIGN KEY (CityId) REFERENCES [dbo].[City](Id)
);


