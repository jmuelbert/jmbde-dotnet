CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Employee" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Employee" PRIMARY KEY AUTOINCREMENT,
    "Active" INTEGER,
    "Birthday" TEXT,
    "BusinessMail" TEXT,
    "ChipCard" TEXT,
    "City" TEXT,
    "CompanyId" INTEGER,
    "DataCare" INTEGER,
    "DepartmentId" INTEGER,
    "EmployeeNO" TEXT NOT NULL,
    "EndDate" TEXT,
    "FaxNumber" TEXT,
    "FirstName" TEXT,
    "Gender" TEXT,
    "LastUpdate" TEXT,
    "Mail" TEXT,
    "MiddleName" TEXT,
    "MobileNumber" TEXT,
    "Name" TEXT NOT NULL,
    "Notes" TEXT,
    "PhoneNumber" TEXT,
    "Photo" BLOB,
    "PlaceId" INTEGER,
    "StartDate" TEXT,
    "Street" TEXT,
    "WorkfunctionId" INTEGER,
    "ZipCode" TEXT
);

CREATE TABLE "Computer" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Computer" PRIMARY KEY AUTOINCREMENT,
    "Active" INTEGER,
    "EmployeeId" INTEGER NOT NULL,
    "LastUpdate" TEXT,
    "Name" TEXT NOT NULL,
    CONSTRAINT "FK_Computer_Employee_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employee" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Mobile" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Mobile" PRIMARY KEY AUTOINCREMENT,
    "Active" INTEGER,
    "EmployeeId" INTEGER NOT NULL,
    "LastUpdate" TEXT,
    "Number" TEXT NOT NULL,
    CONSTRAINT "FK_Mobile_Employee_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employee" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Phone" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Phone" PRIMARY KEY AUTOINCREMENT,
    "Active" INTEGER,
    "EmployeeId" INTEGER NOT NULL,
    "LastUpdate" TEXT,
    "Number" TEXT NOT NULL,
    CONSTRAINT "FK_Phone_Employee_EmployeeId" FOREIGN KEY ("EmployeeId") REFERENCES "Employee" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Computer_EmployeeId" ON "Computer" ("EmployeeId");

CREATE INDEX "IX_Mobile_EmployeeId" ON "Mobile" ("EmployeeId");

CREATE INDEX "IX_Phone_EmployeeId" ON "Phone" ("EmployeeId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20160826145059_Initial', '1.0.0-rtm-21431');

