CREATE TABLE [dbo].[tbIotDevice]
(
	[Id]					INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[IdentificationKey]		VARCHAR(36)		NOT NULL,
	[AssinaturaId]			INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbAssinatura(Id),
	[Tipo]					CHAR			NOT NULL,				
	[Descricao]				VARCHAR(100)	NOT NULL,
	[QuantidadeContainer]	CHAR			NULL,	
)	
