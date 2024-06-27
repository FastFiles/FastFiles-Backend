CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE
);

INSERT INTO Users (Name, Password, Email)
VALUES ("Rafa", 'rafa123', "rafa@gmail.com");

CREATE TABLE Folders (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    Description VARCHAR(150) NOT NULL,
    DateCreated DATE NOT NULL,
    DateModified DATE NOT NULL,
    Location VARCHAR(125) NOT NULL,
    Status ENUM("Active", "Inactive") DEFAULT "Active" NOT NULL,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

DROP TABLE Folders;

CREATE TABLE File (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    DateCreated DATE NOT NULL,
    DateModified DATE NOT NULL,
    Data BLOB NOT NULL,
    Status ENUM("Active", "Inactive") DEFAULT "Active" NOT NULL,
    UserId INT NOT NULL,
    FolderId INT NOT NULL,
    FOREIGN KEY (FolderId) REFERENCES Folders(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);