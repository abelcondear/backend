CREATE DATABASE countries
GO

-- DROP TABLE coordinate
-- DROP TABLE border
-- DROP TABLE [language]
-- DROP TABLE timezone
-- DROP TABLE country


CREATE TABLE country (
	id INT IDENTITY(1,1),
	name VARCHAR(250),
	capital VARCHAR(250),
	region VARCHAR(50),
	subregion VARCHAR(50),
	[population] INT,
	area INT,
	currency VARCHAR(100),
	flag VARCHAR(250),
	PRIMARY KEY(id)
)

GO
CREATE TABLE coordinate (
id INT IDENTITY(1,1),
country_id INT,
latitude BIGINT,
longitude BIGINT,
PRIMARY KEY (id),
FOREIGN KEY (country_id) REFERENCES country(id)
)

GO
CREATE TABLE border (
id INT IDENTITY(1,1),
country_id INT,
name VARCHAR(250),
PRIMARY KEY (id),
FOREIGN KEY (country_id) REFERENCES country(id)
)

GO
CREATE TABLE [LANGUAGE] (
id INT IDENTITY(1,1),
country_id INT,
name VARCHAR(250),
PRIMARY KEY (id),
FOREIGN KEY (country_id) REFERENCES country(id)
)

GO
CREATE TABLE [timezone] (
id INT IDENTITY(1,1),
country_id INT,
name VARCHAR(250),
PRIMARY KEY (id),
FOREIGN KEY (country_id) REFERENCES country(id)
)

GO
SELECT * FROM country
SELECT * FROM [language]
SELECT * FROM border
SELECT * FROM timezone
SELECT * FROM coordinate