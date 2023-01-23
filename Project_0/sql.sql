CREATE SCHEMA Venkat;

CREATE TABLE Venkat.[user](
    user_id INT NOT NULL IDENTITY(1,1),
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email_id VARCHAR(100) NOT NULL,
    [password] VARCHAR(20) NOT NULL,
    phone_no bigint NOT NULL,
    PRIMARY KEY(user_id)
);
  

CREATE TABLE Venkat.skills(
    [skill_id] INT NOT NULL IDENTITY(1,1),
    skill_name VARCHAR(256)  NOT NULL,
    skill_experience INT NOT NULL,
    PRIMARY KEY([skill_id]),
    us_id INT NOT NULL,

    CONSTRAINT FK_usid_skill FOREIGN KEY(us_id)
    REFERENCES Venkat.[user](user_id)

);



CREATE TABLE Venkat.edu(
    edu_id INT NOT NULL IDENTITY(1,1),
    institution_name VARCHAR(256) NOT NULL,
    course_name VARCHAR(256) NOT NULL,
    [start_date] DATE NOT NULL,
    [end_date] DATE NOT NULL,
    cgpa VARCHAR(10) NOT NULL,
    PRIMARY KEY(edu_id),
    us_id INT NOT NULL,
    CONSTRAINT FK_usid_edu FOREIGN KEY(us_id)
    REFERENCES Venkat.[user](user_id)
);

CREATE TABLE Venkat.comp(
    comp_id INT NOT NULL IDENTITY(1,1),
    about VARCHAR(100) NOT NULL,
    comp_name VARCHAR(256) NOT NULL,
    [start_date] DATE NOT null,
    [end_date] DATE NOT NULL,
    PRIMARY KEY(comp_id),
    us_id INT NOT NULL,

    CONSTRAINT FK_usid_Comp FOREIGN KEY(us_id)
    REFERENCES Venkat.[user](user_id)
);





SELECT * From Venkat.[user];
SELECT * From Venkat.[skills];
SELECT * From Venkat.[edu];
SELECT * From Venkat.[comp];





