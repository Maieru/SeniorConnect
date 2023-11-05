CREATE TABLE [dbo].[tbDashboardConfig]
(
	[Id]					INT				NOT NULL	PRIMARY KEY		IDENTITY (1, 1),
	[ConfigurationJson]		VARCHAR(MAX)	NOT NULL,
	[UsuarioId]				INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbUsuario(Id) ON DELETE CASCADE
)
