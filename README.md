# snackSite

School opdracht periode 4

## Inhoudsopgave

### [Inleiding](#inleiding-1)

### [Installatie](#installatie-1)

### [Nuget pakketten](#nuget-pakketten-1)

### [Code](#code-1)

### [Termen](#termen-1)

## Inleiding

Dit is een school opdracht voor periode 4. Het is een snack site waar je snacks kan bestellen. Je kan je registreren en inloggen. Als je ingelogd bent kan je snacks bestellen. Als je admin bent kan je snacks toevoegen, verwijderen en aanpassen.

## Installatie

1. Clone/Download de repository
2. importeer de database
   1. snackSiteDB.sql voor importeren db tabellen.
   2. snackSiteDummyData.sql voor dummy data.
3. Open de solution in visual studio of de folder in een andere editor.
4. Open de appsettings.json file om de database connectie aan te passen.
5. run de applicatie via terminal of de editor zelf.

- Om een admin account aan te maken dien je in de db of dummydata sql bestand de table Gebruiker te benaderen en de Adminrole op 1 te zetten.

## Nuget pakketten

- de volgende nuget pakketen zijn gebruikt:

  - Dapper - 2.0.138
  - Newtonsoft.Json - 13.0.3
  - MySql.Data 8.0.33

## Code

- Program.cs wordt gebruikt om de session aan te maken. Dit wordt gedaan door de session te starten in de main functie. Dit wordt gedaan door de volgende code:

```c#
builder.Services.AddSession();

app.UseSession();
```

- de data in de session wordt opgeslagen in json format. Dit wordt gedaan door de volgende code:

```c#
    public int GetUserId(string? user) 
    {
        if (user == null) return 0;
        if (!CheckIfLoggedIn(user)) return 0;
        // JsonConvert is een voorbeeld van Newtonsoft.Json functie
        -- > var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
        return userObject?.GebruikerId ?? 0;
    }
```

- Met dapper is het makkelijker om de database te gebruiken. Dit wordt gedaan door de volgende code:

```c#
    public Gebruiker Get(int gebruikerId)
    {
        string sql = "SELECT * FROM gebruiker WHERE GebruikerId = @GebruikerId";

        using var connection = GetConnection();
        // QuerySingle is een voorbeeld van dapper functie
        --> var Gebruikers = connection.QuerySingle<Gebruiker>(sql, new { gebruikerId });
        return Gebruikers;
    }
```

### Helpers

- Hash.cs
  - In deze class wordt de hash functie gemaakt. Deze functie wordt gebruikt om de wachtwoorden te hashen. dit wordt gebruikt bij t inloggen en registreren.

```c#
    public static string HashedPassword(string? password)
    {
        if (password == null) return "";
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
```

- Session.cs
  - In deze class wordt er gecheckt of er ingelogd is of niet. Ook kan je hier de Gebruiker id en de adminrole ophalen.

```c#
    public bool CheckIfLoggedIn(string? user)
    {
        if (user == null) return false;
        return true;
    }

    public int GetUserId(string? user)
    {
        if (user == null) return 0;
        if (!CheckIfLoggedIn(user)) return 0;
        var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
        return userObject?.GebruikerId ?? 0;
    }

    public bool CheckAdmin(string? user)
    {
        if (user == null) return false;
        if (!CheckIfLoggedIn(user)) return false;
        var userObject = JsonConvert.DeserializeObject<Gebruiker>(user);
        return userObject?.Adminrole == true;
    }
```

### Models

  Met deze classes kunnen is er te bepalen hoe de properties van de database eruit zien. Dit is dan te gebruiken in de frond-end en back-end. Razorpages kan hierdoor ook nette errors geven als er iets fout gaat. Voorbeeld code hieronder vanuit de Gebruikers.cs class.

  ```c#
    [Required]
    public int GebruikerId { get; set; }
    [Required, MinLength(2), MaxLength(128)]
    public string Naam { get; set; } = null!; 
    [Required, MinLength(5), MaxLength(128)]
    public string? Wachtwoord { get; set; }
    [Compare(nameof(Wachtwoord))] 
    public string? PasswordConfirm { get; set; }

    [Required (ErrorMessage = "Email is verplicht"), EmailAddress]
    public string Email { get; set; } = null!;

    [Required, Range(0, 99999.99)]
    public decimal Budget { get; set; }
    // 0 = user, 1 = admin
    [Required]
    public bool Adminrole { get; set; }
```

### Pages

- Index.cshtml
  - Dit is de home page. Hier kan je de snacks zien die er zijn. Als je ingelogd bent kan je de snacks bestellen. Als je admin bent werkt de knop voor Admin page. Wanneer je nog niet bent ingelogd kom je op de login page. Vanaf hier kan je naar de register page gaan om een account aan te maken. Deze checks worden via de session gedaan in de backend.
- Login.cshtml
  - Dit is de login page. Hier kan je inloggen met je email en wachtwoord. Als je nog geen account hebt kan je naar de register page gaan om een account aan te maken.
- Register.cshtml
  - Dit is de register page. Hier kan je een account aanmaken. Als je al een account hebt kan je naar de login page gaan om in te loggen.
- Admin.cshtml
  - Dit is de admin page. Hier is een tabel gemaakt dat de folder [Crud](#crud) gebruikt. Hier staat 4 cruds pagina's: Aanbieders, Gebruikers, Opties en Producten. Het is ook mogelijk om het globale budget aan te passen. Dit staat los van de crud dit wordt gedaan via een simpele insert query.
- Bestellijst.cshtml
  - Dit is de bestellijst page, hier kan je de snacks zien die er zijn besteld. Vanuit deze pagina is het de bedoeling dat je via een knop de bestellingen in de knipboard kan zetten.

### Repositories

- In de repositories word er database verbinding gemaakt de functie GetDbConnection() komt uit de DbUtils.cs class. Deze functie wordt gebruikt om de database connectie te maken. Dit wordt gedaan door de connection string uit de appsettings.json file te halen. Deze functie wordt gebruikt in de repositories en de crud classes. Met GetConnection() in de repositories kan je de database aanpassen en lezen.

De GetDbConnection() functie:

```C#
    public IDbConnection GetDbConnection()
    {
        string connectionString = Program.Configuration
            .GetConnectionString("snackSite")!;

        return new MySqlConnection(connectionString);
    }
```

De GetConnection() functie:

```c#
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
```

### wwwroot

- hier staan de css/js/images files in. Deze komen bij de front-end te staan. De css en js files worden gebruikt voor de layout en de animaties.

## Termen

- ### CRUD

  - Create, Read, Update, Delete
    - met create INSERT je data in de database.
    - met read SELECT je data uit de database.
    - met update UPDATE je data in de database.
    - mte delete DELETE je data uit de database.
