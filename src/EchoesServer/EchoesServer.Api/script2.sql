CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(95) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `AspNetRoles` (
    `Id` varchar(255) NOT NULL,
    `Name` varchar(256) NULL,
    `NormalizedName` varchar(256) NULL,
    `ConcurrencyStamp` longtext NULL,
    CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetUsers` (
    `Id` varchar(255) NOT NULL,
    `UserName` varchar(256) NULL,
    `NormalizedUserName` varchar(256) NULL,
    `Email` varchar(256) NULL,
    `NormalizedEmail` varchar(256) NULL,
    `EmailConfirmed` bit NOT NULL,
    `PasswordHash` longtext NULL,
    `SecurityStamp` longtext NULL,
    `ConcurrencyStamp` longtext NULL,
    `PhoneNumber` longtext NULL,
    `PhoneNumberConfirmed` bit NOT NULL,
    `TwoFactorEnabled` bit NOT NULL,
    `LockoutEnd` datetime(6) NULL,
    `LockoutEnabled` bit NOT NULL,
    `AccessFailedCount` int NOT NULL,
    CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
);

CREATE TABLE `Classes` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext NOT NULL,
    CONSTRAINT `PK_Classes` PRIMARY KEY (`Id`)
);

CREATE TABLE `AspNetRoleClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `RoleId` varchar(255) NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserClaims` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `UserId` varchar(255) NOT NULL,
    `ClaimType` longtext NULL,
    `ClaimValue` longtext NULL,
    CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserLogins` (
    `LoginProvider` varchar(255) NOT NULL,
    `ProviderKey` varchar(255) NOT NULL,
    `ProviderDisplayName` longtext NULL,
    `UserId` varchar(255) NOT NULL,
    CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
    CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserRoles` (
    `UserId` varchar(255) NOT NULL,
    `RoleId` varchar(255) NOT NULL,
    CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
    CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `AspNetUserTokens` (
    `UserId` varchar(255) NOT NULL,
    `LoginProvider` varchar(255) NOT NULL,
    `Name` varchar(255) NOT NULL,
    `Value` longtext NULL,
    CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
    CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Students` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `FirstName` longtext NOT NULL,
    `LastName` longtext NOT NULL,
    `UserId` varchar(255) NOT NULL,
    CONSTRAINT `PK_Students` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Students_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Subjects` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NULL,
    `ClassId` int NOT NULL,
    CONSTRAINT `PK_Subjects` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Subjects_Classes_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Classes` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Invitations` (
    `ClassId` int NOT NULL,
    `StudentId` int NOT NULL,
    CONSTRAINT `PK_Invitations` PRIMARY KEY (`StudentId`, `ClassId`),
    CONSTRAINT `FK_Invitations_Classes_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Classes` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_Invitations_Students_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `StudentClasses` (
    `StudentId` int NOT NULL,
    `ClassId` int NOT NULL,
    CONSTRAINT `PK_StudentClasses` PRIMARY KEY (`StudentId`, `ClassId`),
    CONSTRAINT `FK_StudentClasses_Classes_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Classes` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_StudentClasses_Students_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `Assignments` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Title` longtext NOT NULL,
    `Description` longtext NULL,
    `DueTo` datetime(6) NOT NULL,
    `SubjectId` int NOT NULL,
    `StudentId` int NULL,
    CONSTRAINT `PK_Assignments` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Assignments_Students_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`) ON DELETE RESTRICT,
    CONSTRAINT `FK_Assignments_Subjects_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subjects` (`Id`) ON DELETE CASCADE
);

CREATE TABLE `StudentAssignments` (
    `StudentId` int NOT NULL,
    `AssignmentId` int NOT NULL,
    CONSTRAINT `PK_StudentAssignments` PRIMARY KEY (`StudentId`, `AssignmentId`),
    CONSTRAINT `FK_StudentAssignments_Assignments_AssignmentId` FOREIGN KEY (`AssignmentId`) REFERENCES `Assignments` (`Id`) ON DELETE CASCADE,
    CONSTRAINT `FK_StudentAssignments_Students_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Students` (`Id`) ON DELETE CASCADE
);

CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

CREATE INDEX `IX_Assignments_StudentId` ON `Assignments` (`StudentId`);

CREATE INDEX `IX_Assignments_SubjectId` ON `Assignments` (`SubjectId`);

CREATE INDEX `IX_Invitations_ClassId` ON `Invitations` (`ClassId`);

CREATE INDEX `IX_StudentAssignments_AssignmentId` ON `StudentAssignments` (`AssignmentId`);

CREATE INDEX `IX_StudentClasses_ClassId` ON `StudentClasses` (`ClassId`);

CREATE INDEX `IX_Students_UserId` ON `Students` (`UserId`);

CREATE INDEX `IX_Subjects_ClassId` ON `Subjects` (`ClassId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20190128101749_Initial', '2.2.1-servicing-10028');

