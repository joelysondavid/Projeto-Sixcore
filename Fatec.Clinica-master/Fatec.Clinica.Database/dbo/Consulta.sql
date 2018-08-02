CREATE TABLE [dbo].[Consulta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[IdPaciente] INT NOT NULL,
	[IdMedico] INT NOT NULL,
	[IdEspecialidade] INT NOT NULL,
	CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY (IdPaciente) REFERENCES [Paciente]([Id]),
	CONSTRAINT [FK_Consulta_Medico] FOREIGN KEY (IdMedico) REFERENCES [Medico]([Id]),
	CONSTRAINT [FK_Consulta_Especialidade] FOREIGN KEY (IdEspecialidade) REFERENCES [Especialidade]([Id])
)
