CREATE DATABASE IF NOT EXISTS SnackSite;

USE SnackSite;

DROP TABLE IF EXISTS Gebruiker, Product, Bestelling, Opties, HeeftBesteld, HeeftEenBestelling, HeeftOpties, HeeftEenProduct CASCADE;

create table Gebruiker (
	 GebruikerId INTEGER auto_increment PRIMARY KEY,
	 Naam varchar(255) NOT NULL UNIQUE ,
	 Wachtwoord varchar(255) NOT NULL,
	 Email varchar(255) NOT NULL,
	 Budget DECIMAL(10,2) NOT NULL,
	 Adminrole boolean NOT NULL
);

CREATE TABLE Aanbieders (
	AanbiederId INT AUTO_INCREMENT PRIMARY KEY,
	AanbiederNaam VARCHAR(50) NOT NULL,
	AanbiederLocatie VARCHAR(50)
);

CREATE TABLE Product (
	ProductId INT AUTO_INCREMENT PRIMARY KEY,
	ProductNaam VARCHAR(50) NOT NULL,
	Productbeschrijving VARCHAR(50),
	ProductPrijs DECIMAL(8,2) NOT NULL,
	ProductCategorie VARCHAR(50) NOT NULL,
	AanbiederId INT NOT NULL,
	INDEX(ProductCategorie),
	INDEX(AanbiederId),
	FOREIGN KEY (AanbiederId) REFERENCES Aanbieders (AanbiederId) ON DELETE CASCADE
);

CREATE TABLE Opties (
	OptieId INT AUTO_INCREMENT PRIMARY KEY,
	OptieNaam VARCHAR(50) NOT NULL,
	OptieBeschrijving VARCHAR(50),
	OptiePrijs DECIMAL(8,2) NOT NULL,
	OptieCategorie VARCHAR(50) NOT NULL,
	INDEX(OptieCategorie)
);

-- CREATE TABLE HeeftOpties (
-- 	 OptieId INTEGER NOT NULL,
-- 	 ProductId INTEGER NOT NULL,
-- 	 FOREIGN KEY (OptieId) REFERENCES Opties (OptieId),
-- 	 FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
-- 	 CONSTRAINT PK_HeeftOpties PRIMARY KEY (OptieId, ProductId)
-- );

CREATE TABLE HeeftOpties (
    ProductId INT NOT NULL,
    OptieId INT NOT NULL,
    PRIMARY KEY (ProductId, OptieId),
    FOREIGN KEY (ProductId) REFERENCES Product (ProductId) ON DELETE CASCADE,
    FOREIGN KEY (OptieId) REFERENCES Opties (OptieId) ON DELETE CASCADE
);

CREATE TABLE Bestelling (
	 BestellingId INTEGER auto_increment PRIMARY KEY,
	 TotaalPrijs DECIMAL(9,2),
	 DatumWeek DATE NOT NULL
);

CREATE TABLE HeeftBesteld(
	 ProductId INTEGER NOT NULL,
	 BestellingId INTEGER NOT NULL,
	 OptieId INTEGER NOT NULL,
	 GebruikerId INTEGER NOT NULL,
	 FOREIGN KEY (GebruikerId) REFERENCES Gebruiker(GebruikerId),
	 FOREIGN KEY (OptieId) REFERENCES Opties(OptieId),
	 FOREIGN KEY (ProductId) REFERENCES Product(ProductId),
	 FOREIGN KEY (BestellingId) REFERENCES Bestelling(BestellingId),
	 CONSTRAINT PK_HeeftBesteld PRIMARY KEY (ProductId, BestellingId)
);

CREATE TABLE HeeftEenBestelling(
    BestellingId INTEGER NOT NULL,
    GebruikerId  INTEGER NOT NULL,
    FOREIGN KEY (BestellingId) REFERENCES Bestelling (BestellingId),
    FOREIGN KEY (GebruikerId) REFERENCES Gebruiker (GebruikerId),
    CONSTRAINT PK_HeeftEenBestelling PRIMARY KEY (BestellingId,GebruikerId)
);