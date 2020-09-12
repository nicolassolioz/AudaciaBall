CREATE TABLE T_Player (
idPlayer int IDENTITY(1,1) NOT NULL PRIMARY KEY,
playerName varchar(255) NOT NULL,
fk_idTeam int
);

CREATE TABLE T_Team (
idTeam int IDENTITY(1,1) NOT NULL PRIMARY KEY,
fk_idPlayer1 int NOT NULL,
fk_idPlayer2 int NOT NULL,
FOREIGN KEY (fk_idPlayer1) REFERENCES T_Player(idPlayer),
FOREIGN KEY (fk_idPlayer2) REFERENCES T_Player(idPlayer)
);

CREATE TABLE T_Game (
idGame int IDENTITY(1,1) NOT NULL PRIMARY KEY,
scoreBlue int NOT NULL,
scoreRed int NOT NULL,
fk_idPlayerBlue int NOT NULL,
fk_idPlayerRed int NOT NULL,
gameDate DateTime NOT NULL,
FOREIGN KEY (fk_idPlayerBlue) REFERENCES T_Player(idPlayer),
FOREIGN KEY (fk_idPlayerRed) REFERENCES T_Player(idPlayer)
);

ALTER TABLE T_Player ADD fk_idTeam int;
ALTER TABLE T_Player ADD CONSTRAINT fk_idTeam FOREIGN KEY (fk_idTeam) REFERENCES T_Team(idTeam);