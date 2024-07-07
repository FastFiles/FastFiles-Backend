CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE
);

INSERT INTO Users (Name, Password, Email)
VALUES ("Rafa", 'rafa123', "rafa@gmail.com");
SELECT * FROM Users;

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

SELECT * FROM Folders;

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


DROP TABLE File;
INSERT INTO File (Name, DateCreated, DateModified, Data, Status, UserId, FolderId)
VALUES
('example_file_1.txt', '2024-06-28', '2024-06-28', "0x48656c6c6f2c20576f726c6421", 'Active', 1, 1),
('example_file_2.pdf', '2024-06-29', '2024-06-29', "0x48656c6c6f2c20576f726c6421", 'Inactive', 2, 2);

SELECT * FROM File;