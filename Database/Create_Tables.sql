-- tables
-- Table: Slownik contains data for dropdown lists
CREATE TABLE Slownik (
    slownik_id int  NOT NULL identity,
    nazwa text  NOT NULL,
	kod text NOT NULL,
    CONSTRAINT slownik_pk PRIMARY KEY  (slownik_id)
);

-- Table: Zadania contains data about tasks
CREATE TABLE Zadania (
    Zadanie_id int  NOT NULL identity,
    Zadanie text  NOT NULL,
	Opis text NOT NULL,
    slownik_id int  NOT NULL,
	DoTime date,
	StartTime date not null,
    CONSTRAINT zadania_pk PRIMARY KEY  (Zadanie_id)
);


-- Table: Zadania_zakonczone contains data on task finish time
CREATE TABLE Zadania_zakonczone (
    Zadanie_id int  NOT NULL,
    FinishTime date  NULL,
    CONSTRAINT Zadania_zakonczone_pk PRIMARY KEY  (Zadanie_id)
);

-- Table: Uzytkownik contains login and password of users who have access to the database
CREATE TABLE Uzytkownik (
	IdUzytkownik int Primary Key not null identity,
    Login nvarchar(100)  NOT NULL,
    Haslo nvarchar(100)  NOT NULL
);

-- foreign keys
-- Reference: Zadania_Slownik_fk (table: Zadania)
ALTER TABLE Zadania ADD CONSTRAINT Zadania_Slownik
    FOREIGN KEY (slownik_id)
    REFERENCES Slownik (slownik_id);

-- Reference: Zadania_zakonczone_Zadania_fk (table: Zadania_zakonczone)
ALTER TABLE Zadania_zakonczone ADD CONSTRAINT Zadania_zakonczone_Zadania
    FOREIGN KEY (Zadanie_id)
    REFERENCES Zadania (Zadanie_id);

