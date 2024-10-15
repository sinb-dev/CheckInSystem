USE CheckInSystem
GO
CREATE TABLE employee(
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    cardID char(11) UNIQUE,
    firstName varchar(50),
    middleName varchar(100),
    lastName varchar(50),
    isOffSite bit,
    offSiteUntil DATE,
);

USE CheckInSystem
GO
CREATE TABLE [Group]
(
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    GroupName varchar(50) NOT NULL,
);

USE CheckInSystem
GO
CREATE TABLE employeeGroup(
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    employeeID INT NOT NULL,
    groupID INT NOT NULL,
    FOREIGN KEY (employeeID) REFERENCES employee(ID) ON DELETE CASCADE,
    FOREIGN KEY (groupID) REFERENCES [Group](ID) ON DELETE CASCADE,
);

USE CheckInSystem
GO
CREATE TABLE onSiteTime(
    ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    employeeID INT NOT NULL,
    arrivalTime DATETIME NOT NULL,
    departureTime DATETIME,
    FOREIGN KEY (employeeID) REFERENCES employee(ID) ON DELETE CASCADE
);