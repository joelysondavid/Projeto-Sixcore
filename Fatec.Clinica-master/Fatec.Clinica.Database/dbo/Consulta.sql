use FatecClinica
CREATE TABLE Consulta
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Data] DATE NOT NULL,
	[Hora] TEXT NOT NULL,
	[IdPaciente] INT NOT NULL,
	[IdMedico] INT NOT NULL,
	[TipoEspecialista] INT NOT NULL,
	CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY (IdPaciente) REFERENCES [Paciente]([Id]),
	CONSTRAINT [FK_Consulta_Medico] FOREIGN KEY (IdMedico) REFERENCES [Medico]([Id]),
	CONSTRAINT [FK_Consulta_Especialidade] FOREIGN KEY (TipoEspecialista) REFERENCES [Especialidade]([Id])
)

/*SELECT C.Id, C.Data, C.Hora, P.Nome As Paciente, 
		M.Nome As Medico, E.Nome As Especialidade
		FROM [Consulta] C 
		INNER JOIN [Paciente] P ON C.IdPaciente = P.Id
		INNER JOIN [Medico] M ON C.IdMedico = M.Id 
		INNER JOIN [Especialidade] E ON C.TipoEspecialista = E.Id

select * from consulta
DELETE FROM Consulta
where id = 20*/