CREATE TABLE [dbo].[tbLembreteMedicamento]
(
	[Id]			INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[Horario]		DATETIME		NOT NULL,
	[Descricao]		VARCHAR(100)	NOT NULL,
	[MedicamentoId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbMedicamento(Id)
)
