using System;

namespace Fatec.Clinica.Dominio
{
    public class Consulta
    {
        
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int TipoEspecialista{ get; set; }

    }
}
