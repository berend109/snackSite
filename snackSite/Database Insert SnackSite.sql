CREATE DATABASE IF NOT EXISTS SnackSite;

USE SnackSite;

DROP TABLE IF EXISTS Gebruiker, Product, Bestelling, Opties, Aanbieder, HeeftBesteld, HeeftEenBestelling, HeeftOpties, HeeftEenProduct CASCADE;

create table Gebruiker (
                           GebruikerId INTEGER auto_increment PRIMARY KEY,
                           Naam varchar(255) NOT NULL UNIQUE ,
                           Wachtwoord varchar(255) NOT NULL,
                           Email varchar(255) NOT NULL,
                           Adminrole boolean NOT NULL,
                           Budget DECIMAL(10,2) NOT NULL,
                           BudgetLimit BOOLEAN NOT NULL
);

CREATE TABLE Product(
                        ProductId INTEGER auto_increment PRIMARY KEY,
                        ProductNaam varchar(255) NOT NULL,
                        Productbeschrijving varchar(255),
                        ProductPrijs DECIMAL(10,2) NOT NULL,
                        ProductCategorie VARCHAR(255) NOT NULL,
                        Vegan BOOLEAN,
                        Vega BOOLEAN
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
                            ProductId INTEGER NOT NULL,
                            OptieId INTEGER NOT NULL,
                            Totaal DECIMAL,
                            Prijs DECIMAL(10,2),
                            FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
                            FOREIGN KEY (OptieId) REFERENCES Opties (OptieId)
);



CREATE TABLE Aanbieder(
                          AanbiederId INTEGER auto_increment PRIMARY KEY,
                          Naam varchar(255) NOT NULL
);

CREATE TABLE HeeftEenProduct (
                                 AanbiederId INTEGER NOT NULL,
                                 ProductId INTEGER NOT NULL ,
                                 FOREIGN KEY (AanbiederId) REFERENCES Aanbieder (AanbiederId),
                                 FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
                                 CONSTRAINT PK_HeeftEenProduct PRIMARY KEY (AanbiederId,ProductId)
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
INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget, BudgetLimit)
VALUES ('Alice', 'password123', 'alice@example.com', true, 7.50, true);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget, BudgetLimit)
VALUES ('Bob', 'securepass456', 'bob@example.com', false, 7.50, true);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget, BudgetLimit)
VALUES ('Charlie', 'abc123', 'charlie@example.com', false, 7.50, true);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget, BudgetLimit)
VALUES ('David', 'davidpass', 'david@example.com', false, 7.50, true);

INSERT INTO Gebruiker (Naam, wachtwoord, Email, Adminrole, Budget, BudgetLimit)
VALUES ('Eve', 'evesecret', 'eve@example.com', false, 7.50, true);

-- TABLE Product

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
VALUES ('Appel', 'Verse en sappige appel', 1.99, 'Fruit', true, false);

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
VALUES ('Komkommer', 'Knapperige komkommer', 0.99, 'Groenten', true, true);

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
VALUES ('Kipfilet', 'Botloze kipfilet', 5.99, 'Vlees', false, false);

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
VALUES ('Yoghurt', 'Romige yoghurt', 2.49, 'Zuivel', false, true);

INSERT INTO Product (ProductNaam, Productbeschrijving, ProductPrijs, ProductCategorie, Vegan, Vega)
VALUES ('Quinoa', 'Voedzame quinoa-granen', 3.99, 'Granen', true, true);

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
INSERT INTO Bestelling (ProductId, OptieId,totaal, prijs)
VALUES (1, 3, 1, 9.99);

INSERT INTO Bestelling (ProductId, OptieId, totaal, prijs)
VALUES (2, 5, 2, 4.95);

INSERT INTO Bestelling (ProductId, OptieId, totaal, prijs)
VALUES (3, 2, 3, 12.50);

INSERT INTO Bestelling (ProductId, OptieId, totaal, prijs)
VALUES (4, 1, 4, 2.99);

INSERT INTO Bestelling (ProductId, OptieId, totaal, prijs)
VALUES (5, 4, 5, 7.50);



-- TABLE Aanbieder 

INSERT INTO Aanbieder (Naam)
VALUES ('Restaurant De Smaakmaker');

INSERT INTO Aanbieder (Naam)
VALUES ('Pizzeria Bella Italia');

INSERT INTO Aanbieder (Naam)
VALUES ('Snackbar De Snelle Hap');

INSERT INTO Aanbieder (Naam)
VALUES ('Chinees Restaurant Lotus');

INSERT INTO Aanbieder (Naam)
VALUES ('Thais Eethuis Siam');

