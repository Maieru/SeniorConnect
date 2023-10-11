CREATE TABLE [dbo].[tbUsuario]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[Usuario]			VARCHAR(200)	NOT NULL,
	[Senha]				VARCHAR(MAX)	NOT NULL,
	[AssinaturaId]		INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbAssinatura(Id)
)
