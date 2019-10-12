﻿CREATE TABLE [dbo].[Players]
(
	PlayerId VARCHAR(255) NOT NULL,
    PlayerName NVARCHAR(255) NOT NULL,
    PlayerCountry CHAR(2) NULL,
	PlayerAvatar VARBINARY(MAX) NOT NULL,
	Balance DECIMAL(9,2) DEFAULT(0) NOT NULL,
	Role VARCHAR(40) NOT NULL DEFAULT('Guest'),	
	PlayerLastActivity DATETIME2 NOT NULL DEFAULT (SYSDATETIME()),
    PlayerCreated DATETIME2 NOT NULL DEFAULT (SYSDATETIME()),
    CONSTRAINT PK_Players PRIMARY KEY (PlayerId)   
)
