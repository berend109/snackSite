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
 
-- TABLE Bestelling
INSERT INTO Bestelling (ProductId, totaal, prijs)
VALUES (1, 3, 9.99);
 
INSERT INTO Bestelling (ProductId, totaal, prijs)
VALUES (2, 5, 4.95);
 
INSERT INTO Bestelling (ProductId, totaal, prijs)
VALUES (3, 2, 12.50);
 
INSERT INTO Bestelling (ProductId, totaal, prijs)
VALUES (4, 1, 2.99);
 
INSERT INTO Bestelling (ProductId, totaal, prijs)
VALUES (5, 4, 7.50);
 
-- TABLE Opties 
 
INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs)
VALUES ('Extra saus', 'Voeg extra saus toe aan de snack', 0.50);
 
INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs)
VALUES ('Friet upgrade', 'Upgrade de bijgerecht naar een grotere portie friet', 1.00);
 
INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs)
VALUES ('Kaas toevoegen', 'Voeg extra kaas toe aan de snack', 0.75);
 
INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs)
VALUES ('Pittig', 'Maak de snack pittiger', 0.50);
 
INSERT INTO Opties (OptieNaam, OptieBeschrijving, OptiePrijs)
VALUES ('Extra toppings', 'Voeg extra toppings toe aan de snack', 0.75);
 
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
