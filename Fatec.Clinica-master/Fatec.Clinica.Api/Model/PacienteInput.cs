using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fatec.Clinica.Api.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PacienteInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Historico { get; set; }
        public string Nascimento{ get; set; }
    }
}
