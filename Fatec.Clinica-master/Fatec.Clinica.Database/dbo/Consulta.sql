use FatecClinica
CREATE TABLE Consulta
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Data] DATE NOT NULL,
	[Hora] TIME('24:60') NOT NULL,
	[IdPaciente] INT NOT NULL,
	[IdMedico] INT NOT NULL,
	[TipoEspecialista] INT NOT NULL,
	CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY (IdPaciente) REFERENCES [Paciente]([Id]),
	CONSTRAINT [FK_Consulta_Medico] FOREIGN KEY (IdMedico) REFERENCES [Medico]([Id]),
	CONSTRAINT [FK_Consulta_Especialidade] FOREIGN KEY (TipoEspecialista) REFERENCES [Especialidade]([Id])
)
select * from medico
select * from consulta
select format(consulta.Data, 'd') from consulta

set language 'brazilian'
/*SELECT C.Id, C.Data, C.Hora, P.Nome As Paciente, 
		M.Nome As Medico, E.Nome As Especialidade
		FROM [Consulta] C 
		INNER JOIN [Paciente] P ON C.IdPaciente = P.Id
		INNER JOIN [Medico] M ON C.IdMedico = M.Id 
		INNER JOIN [Especialidade] E ON C.TipoEspecialista = E.Id


DELETE FROM Consulta
where id = 20*/