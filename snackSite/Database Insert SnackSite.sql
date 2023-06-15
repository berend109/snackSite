CREATE DATABASE IF NOT EXISTS SnackSite;

USE SnackSite;

DROP TABLE IF EXISTS Gebruiker, Product, Bestelling, Opties, HeeftBesteld, HeeftEenBestelling, HeeftOpties, HeeftEenProduct CASCADE;

create table Gebruiker (
                           GebruikerId INTEGER auto_increment PRIMARY KEY,
                           Naam varchar(255) NOT NULL UNIQUE ,
                           Wachtwoord varchar(255) NOT NULL,
                           Email varchar(255) NOT NULL,
                           Budget DECIMAL(10,2) NOT NULL,
                           Adminrole boolean
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


CREATE TABLE HeeftEenBestelling
(
    BestellingId INTEGER NOT NULL,
    GebruikerId  INTEGER NOT NULL,
    FOREIGN KEY (BestellingId) REFERENCES Bestelling (BestellingId),
    FOREIGN KEY (GebruikerId) REFERENCES Gebruiker (GebruikerId),
    CONSTRAINT PK_HeeftEenBestelling PRIMARY KEY (BestellingId,GebruikerId)
);



-- TABLE Gebruiker
INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget)
VALUES ('Alice', 'password123', 'alice@example.com', true, 7.50);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget)
VALUES ('Bob', 'securepass456', 'bob@example.com', false, 7.50);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget)
VALUES ('Charlie', 'abc123', 'charlie@example.com', false, 7.50);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget)
VALUES ('David', 'davidpass', 'david@example.com', false, 7.50);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget)
VALUES ('Eve', 'evesecret', 'eve@example.com', false, 7.50);

-- TABLE Product

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
VALUES ('Appel', 'Verse en sappige appel', 1.99, 'Fruit', 'Pizzeria Bella Italia');

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
VALUES ('Komkommer', 'Knapperige komkommer', 0.99, 'Groenten', 'Pizzeria Bella Italia');

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
VALUES ('Kipfilet', 'Botloze kipfilet', 5.99, 'Vlees', 'Pizzeria Bella Italia');

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
VALUES ('Yoghurt', 'Romige yoghurt', 2.49, 'Zuivel','Pizzeria Bella Italia' );

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, AanbiederNaam)
VALUES ('Quinoa', 'Voedzame quinoa-granen', 3.99, 'Granen','Restaurant De Smaakmaker');

-- TABLE Opties 

INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs, OptieCategorie)
VALUES ('Extra saus', 'Voeg extra saus toe aan de snack', 0.50, 'FrituurSnack');

INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs, OptieCategorie)
VALUES ('Friet upgrade', 'Upgrade de bijgerecht naar een grotere portie friet', 1.00, 'FrituurScnack');

INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs, OptieCategorie)
VALUES ('Kaas toevoegen', 'Voeg extra kaas toe aan de snack', 0.75, 'Broodje');

INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs, OptieCategorie)
VALUES ('Pittig', 'Maak de snack pittiger', 0.50, 'FrituurSnack');

INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs, OptieCategorie)
VALUES ('Extra toppings', 'Voeg extra toppings toe aan de snack', 0.75, 'FrituurSnack');

-- TABLE Bestelling
INSERT INTO Bestelling (totaalPrijs, DatumWeek)
VALUES (9.99,'2008-11-11');

INSERT INTO Bestelling (totaalPrijs, DatumWeek)
VALUES (4.95,'2008-11-11');

INSERT INTO Bestelling (totaalPrijs, DatumWeek)
VALUES (12.50,'2008-11-11');

INSERT INTO Bestelling (totaalPrijs, DatumWeek)
VALUES (2.99,'2008-11-11');

INSERT INTO Bestelling (totaalPrijs, DatumWeek)
VALUES (7.50,'2008-11-11');

-- Table heeftBesteld

INSERT INTO HeeftBesteld (productId, bestellingId, optieId, gebruikerId)
VALUES (1,1,1,1);
INSERT INTO HeeftBesteld (productId, bestellingId, optieId, gebruikerId)
VALUES (2,3,1,1);
INSERT INTO HeeftBesteld (productId, bestellingId, optieId, gebruikerId)
VALUES (2,1,3,1);
INSERT INTO HeeftBesteld (productId, bestellingId, optieId, gebruikerId)
VALUES (4,1,3,1);



-- TABLE Aanbieder 

-- INSERT INTO Aanbieder (Naam)
-- VALUES ('Restaurant De Smaakmaker');

-- INSERT INTO Aanbieder (Naam)
-- VALUES ('Pizzeria Bella Italia');

-- INSERT INTO Aanbieder (Naam)
-- VALUES ('Snackbar De Snelle Hap');

-- INSERT INTO Aanbieder (Naam)
-- VALUES ('Chinees Restaurant Lotus');

-- INSERT INTO Aanbieder (Naam)
-- VALUES ('Thais Eethuis Siam');


