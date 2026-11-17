-- =====================================
-- 1. TABEL ARTSEN
-- =====================================

CREATE TABLE Artsen (
    ArtsID INT IDENTITY(1,1) PRIMARY KEY,
    Voornaam VARCHAR(50) NOT NULL,
    Achternaam VARCHAR(50) NOT NULL,
    Specialisatie VARCHAR(100),
    Telefoonnummer VARCHAR(20),
    Email VARCHAR(100) UNIQUE
);
GO


-- =====================================
-- 2. TABEL PATIENTEN
-- =====================================

CREATE TABLE Patienten (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    Voornaam VARCHAR(50) NOT NULL,
    Achternaam VARCHAR(50) NOT NULL,
    Geboortedatum DATE NOT NULL,
    Telefoonnummer VARCHAR(20),
    Email VARCHAR(100) UNIQUE
);
GO


-- =====================================
-- 3. TABEL AFSPRAKEN
-- =====================================

CREATE TABLE Afspraken (
    AfspraakID INT IDENTITY(1,1) PRIMARY KEY,
    ArtsID INT NOT NULL,
    PatientID INT NOT NULL,
    Datum DATE NOT NULL,
    Tijd TIME NOT NULL,
    Status VARCHAR(30) NOT NULL,
    Type VARCHAR(20) NOT NULL,

    FOREIGN KEY (ArtsID)
        REFERENCES Artsen(ArtsID),

    FOREIGN KEY (PatientID)
        REFERENCES Patienten(PatientID),

    CHECK (Type IN ('Consultatie', 'Controle', 'Operatie'))
);
GO


-- =====================================
-- 4. TABEL CONSULTATIES
-- =====================================

CREATE TABLE Consultaties (
    AfspraakID INT PRIMARY KEY,
    Diagnose VARCHAR(255),
    Opmerkingen VARCHAR(MAX),

    FOREIGN KEY (AfspraakID)
        REFERENCES Afspraken(AfspraakID)
);
GO


-- =====================================
-- 5. TABEL CONTROLES
-- =====================================

CREATE TABLE Controles (
    AfspraakID INT PRIMARY KEY,
    ReferentieAfspraakID INT NOT NULL,
    Resultaat VARCHAR(MAX),

    FOREIGN KEY (AfspraakID)
        REFERENCES Afspraken(AfspraakID),

    FOREIGN KEY (ReferentieAfspraakID)
        REFERENCES Afspraken(AfspraakID),

    CHECK (AfspraakID <> ReferentieAfspraakID)
);
GO


-- =====================================
-- 6. TABEL OPERATIES
-- =====================================

CREATE TABLE Operaties (
    AfspraakID INT PRIMARY KEY,
    OperatieType VARCHAR(100) NOT NULL,
    Duur INT,

    FOREIGN KEY (AfspraakID)
        REFERENCES Afspraken(AfspraakID)
);
GO
