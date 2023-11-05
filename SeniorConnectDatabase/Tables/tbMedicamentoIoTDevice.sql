﻿CREATE TABLE [dbo].[tbMedicamentoIoTDevice]
(	
	[Id]			INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[MedicamentoId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbMedicamento(Id) ON DELETE CASCADE,
	[IoTDeviceId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbIotDevice(Id) ON DELETE CASCADE,
)
