-- tables
-- Table: Dictionary
CREATE TABLE Dictionary (
    dict_id int  NOT NULL identity,
    name_dict text  NOT NULL,
	code text NOT NULL,
    CONSTRAINT dictionary_pk PRIMARY KEY  (dict_id)
);

-- Table: Tasks
CREATE TABLE Tasks (
    Task_id int  NOT NULL identity,
    Task text  NOT NULL,
	DescriptTask text NOT NULL,
    dict_id int  NOT NULL,
	DoTime date,
	StartTime date not null,
    CONSTRAINT Tasks_pk PRIMARY KEY  (Task_id)
);


-- Table: Tasks_Completed
CREATE TABLE Tasks_Completed (
    Task_id int  NOT NULL,
    FinishTime date  NULL,
    CONSTRAINT Tasks_Completed_pk PRIMARY KEY  (Task_id)
);

-- foreign keys
-- Reference: Tasks_Dictionary_fk (table: Tasks)
ALTER TABLE Tasks ADD CONSTRAINT Tasks_Dictionary_fk
    FOREIGN KEY (dict_id)
    REFERENCES Dictionary (dict_id);

-- Reference: Tasks_Completed_Tasks_fk (table: Zadania_zakonczone)
ALTER TABLE Tasks_Completed ADD CONSTRAINT Tasks_Completed_Tasks_fk
    FOREIGN KEY (Task_id)
    REFERENCES Tasks (Task_id);

-- Table: Users
CREATE TABLE Users (
	IdUser int Primary Key not null identity,
    Login nvarchar(100)  NOT NULL,
    Password nvarchar(100)  NOT NULL
);
