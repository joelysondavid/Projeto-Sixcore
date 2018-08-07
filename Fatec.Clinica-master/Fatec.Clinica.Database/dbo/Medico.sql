CREATE TABLE [dbo].[Medico]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[IdEspecialidade] INT NOT NULL,
    [Nome] VARCHAR(100) NOT NULL, 
    [CPF] VARCHAR(14) NOT NULL, 
    [CRM] VARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Medico_Especialidade] FOREIGN KEY (IdEspecialidade) REFERENCES [Especialidade]([Id])
)

ALTER TABLE medico ALTER COLUMN CPF VARCHAR(14) ;  
GO 