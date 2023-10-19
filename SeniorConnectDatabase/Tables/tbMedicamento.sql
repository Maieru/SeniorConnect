CREATE TABLE [dbo].[tbMedicamento]
(
	[Id]			INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[Posicao]		CHAR			NOT NULL,
	[Descricao]		VARCHAR(100)	NOT NULL,
	[AssinaturaId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbAssinatura(Id),
)
