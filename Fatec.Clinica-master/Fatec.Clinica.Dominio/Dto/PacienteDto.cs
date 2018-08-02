using System;
using System.Collections.Generic;
using System.Text;

namespace Fatec.Clinica.Dominio.Dto
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Historico { get; set; }
        public string Nascimento { get; set; }
    }
}
