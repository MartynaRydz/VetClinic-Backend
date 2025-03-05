-- Tabela Gender
CREATE TABLE Gender (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Unikalny identyfikator p³ci
    Name NVARCHAR(50) NOT NULL         -- Nazwa p³ci, np. Male/Female
);

-- Tabela Species
CREATE TABLE Species (
    Id INT PRIMARY KEY IDENTITY(1,1),  -- Unikalny identyfikator gatunku
    Name NVARCHAR(100) NOT NULL        -- Nazwa gatunku, np. Dog/Cat
);

-- Tabela Pet
CREATE TABLE Pet (
    Id INT PRIMARY KEY IDENTITY(1,1),        -- Unikalny identyfikator zwierzaka
    Name NVARCHAR(100) NOT NULL,             -- Imiê zwierzaka
    SpeciesId INT NOT NULL,                  -- Klucz obcy do tabeli Species
    GenderId INT NOT NULL,                   -- Klucz obcy do tabeli Gender
    YearOfBirth DATE NOT NULL,               -- Data urodzenia
    IsDeleted BIT NOT NULL DEFAULT 0,        -- Flaga oznaczaj¹ca usuniêcie
    CONSTRAINT FK_Pet_Species FOREIGN KEY (SpeciesId) REFERENCES Species(Id),
    CONSTRAINT FK_Pet_Gender FOREIGN KEY (GenderId) REFERENCES Gender(Id)
);
