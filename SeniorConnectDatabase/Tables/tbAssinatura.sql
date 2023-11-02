﻿CREATE TABLE [dbo].[tbAssinatura]
(
	[Id]			INT			NOT NULL	PRIMARY KEY	IDENTITY (1, 1),
	[DataCriacao]	DATETIME	NOT NULL	CONSTRAINT DEFAULT_tbAssinatura_DataCriacao DEFAULT (GETDATE()),
	[PlanoId]		INT			NOT NULL	FOREIGN KEY REFERENCES dbo.tbPlano(Id) ON DELETE CASCADE
)
