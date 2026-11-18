-- =====================================
-- 1. TABEL ARTSEN
-- =====================================

CREATE TABLE Artsen (
    ArtsID INT IDENTITY(1,1) PRIMARY KEY,
    Voornaam VARCHAR(50) NOT NULL,
    Achternaam VARCHAR(50) NOT NULL,
    Specialisatie VARCHAR(100),
    Afdelingen VARCHAR(300),
    Riziv_Nummer VARCHAR(11) UNIQUE,
    Rijks_Register_Nummer VARCHAR(11) UNIQUE
);
GO


-- =====================================
-- 2. TABEL PATIENTEN
-- =====================================

CREATE TABLE Patienten (
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    Voornaam VARCHAR(50) NOT NULL,
    Achternaam VARCHAR(50) NOT NULL,
    Afdelingen VARCHAR(300),
    Rijks_Register_Nummer VARCHAR(11) UNIQUE
);
GO


-- =====================================
-- 3. TABEL AFSPRAKEN
-- =====================================

CREATE TABLE Afspraken (
    AfspraakID INT IDENTITY(1,1) PRIMARY KEY,
    AfspraakType VARCHAR(30) NOT NULL,
    Datum VARCHAR(100) NOT NULL,
    Tijd VARCHAR(100) NOT NULL,
    Duur VARCHAR(30) NOT NULL,
    Rijks_Register_Nummer_Patient VARCHAR(11) UNIQUE,
    Rijks_Register_Nummer_Arts VARCHAR(11) UNIQUE,
    AfdelingsCode VARCHAR(20)

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

    FOREIGN KEY (AfspraakID)
        REFERENCES Afspraken(AfspraakID)
);
GO


-- =====================================
-- 5. TABEL CONTROLES
-- =====================================

CREATE TABLE Controles (
    AfspraakID INT PRIMARY KEY,
    ReferentieAfspraakID VARCHAR(100) NOT NULL,

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
    Beschrijving VARCHAR(100) NOT NULL,
    

    FOREIGN KEY (AfspraakID)
        REFERENCES Afspraken(AfspraakID)
);
GO
