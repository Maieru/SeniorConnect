CREATE TABLE [dbo].[tbLembreteIoTDevice]
(
	[Id]			INT				NOT NULL PRIMARY KEY IDENTITY (1, 1),
	[LembreteId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbLembrete(Id),
	[IoTDeviceId]	INT				NOT NULL FOREIGN KEY REFERENCES dbo.tbIotDevice(Id),
)
