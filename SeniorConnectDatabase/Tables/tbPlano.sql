CREATE TABLE [dbo].[tbPlano]
(
	[Id]		INT			 NOT NULL	PRIMARY KEY	 IDENTITY (1, 1),
	[Descricao] VARCHAR(100) NOT NULL,
	[Valor]		FLOAT		 NOT NULL,
)
