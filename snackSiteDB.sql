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

CREATE TABLE Product(
	 ProductId INTEGER auto_increment PRIMARY KEY,
	 ProductNaam varchar(255) NOT NULL,
	 Productbeschrijving varchar(255),
	 ProductPrijs DECIMAL(10,2) NOT NULL,
	 ProductCategorie VARCHAR(255) NOT NULL,
	 AanbiederNaam VARCHAR(255) NOT NULL
);

CREATE TABLE Opties(
	 OptieId INTEGER auto_increment PRIMARY KEY,
	 OptieNaam VARCHAR(255) NOT NULL,
	 OptieBeschrijving VARCHAR(255),
	 OptiePrijs DECIMAL(10,2) NOT NULL,
	 OptieCategorie varchar(255) NOT NULL
);

CREATE TABLE Bestelling (
	 BestellingId INTEGER auto_increment PRIMARY KEY,
	 TotaalPrijs DECIMAL(10,2),
	 DatumWeek DATE NOT NULL
);

CREATE TABLE HeeftOpties(
	 OptieId INTEGER NOT NULL,
	 ProductId INTEGER NOT NULL,
	 FOREIGN KEY (OptieId) REFERENCES Opties (OptieId),
	 FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	 CONSTRAINT PK_HeeftOpties PRIMARY KEY (OptieId, ProductId)
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