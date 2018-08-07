using System;
using System.Collections.Generic;
using System.Text;

namespace Fatec.Clinica.Dominio.Dto
{
    public class ConsultaDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Paciente { get; set; }
        public string Medico { get; set; }
        public string Especialidade { get; set; }
    }
}