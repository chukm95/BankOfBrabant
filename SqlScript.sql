DROP TABLE IF EXISTS RekeningBevoegdes;
DROP TABLE IF EXISTS Klanten;
DROP TABLE IF EXISTS Medewerkers;
DROP TABLE IF EXISTS Rekeningen;

CREATE TABLE Klanten (
ID bigint PRIMARY KEY auto_increment,
Voornaam varchar(50) NOT NULL,
Tussenvoegsel varchar(10) NOT NULL,
Achternaam varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
Adres varchar(100) NOT NULL,
Geslacht tinyint NOT NULL,
KVKNummer varchar(8) NOT NULL unique, -- add unique
BKRPositief bool NOT NULL,
Blacklisted bool NOT NULL,
PaspoortCheck bool NOT NULL
);

CREATE TABLE Medewerkers (
ID bigint PRIMARY KEY auto_increment,
Voornaam varchar(50) NOT NULL,
Tussenvoegsel varchar(10) NOT NULL,
Achternaam varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
Adres varchar(100) NOT NULL,
Geslacht tinyint NOT NULL
);

CREATE TABLE Rekeningen(
ID bigint PRIMARY KEY auto_increment,
RekeningNummer varchar(50) NOT NULL unique, -- add unique
RekeningType tinyint NOT NULL,
Saldo decimal(13, 2) NOT NULL,
RentePercentage float NOT NULL
);

CREATE TABLE RekeningBevoegdes(
KlantID bigint,
RekeningID bigint,
Relatie tinyint NOT NULL,

CONSTRAINT fkfk_KlantID FOREIGN KEY (KlantID) REFERENCES Klanten(ID) ON DELETE CASCADE,
CONSTRAINT fkfk_RekeningID FOREIGN KEY (RekeningID) REFERENCES Rekeningen(ID) ON DELETE CASCADE,

PRIMARY KEY (KlantID, RekeningID)

);

CREATE TABLE `transacties` (
  `Verstuurder` varchar(50) NOT NULL,
  `Ontvanger` varchar(50) NOT NULL,
  `Euros` double NOT NULL,
  `Datum` datetime NOT NULL,
  `ID` bigint(20) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Verstuurder_UNIQUE` (`Verstuurder`),
  UNIQUE KEY `Ontvanger_UNIQUE` (`Ontvanger`),
  KEY `rekeningnaarFK_idx` (`Ontvanger`),
  CONSTRAINT `rekeningnaarFK` FOREIGN KEY (`Ontvanger`) REFERENCES `rekeningen` (`RekeningNummer`),
  CONSTRAINT `rekeningvanFK` FOREIGN KEY (`Verstuurder`) REFERENCES `rekeningen` (`RekeningNummer`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci