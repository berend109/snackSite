-- select db
USE snacksite;

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