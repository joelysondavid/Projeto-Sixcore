using System;

namespace Fatec.Clinica.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsultaInput
    {
        public DateTime data { get; set; }
        public string hora { get; set; }
        public int idPaciente { get; set; }
        public int idMedico { get; set; }
        public int TipoEspecialista { get; set; }
    }
}
