namespace Fatec.Clinica.Dominio
{
    public class Paciente : Login
    {
        public string Cpf { get; set; }
        public string Historico { get; set; }
        public string Nascimento { get; set; }
    }
}
