namespace Fatec.Clinica.Dominio
{
    public class Medico : Login
    {
        
        public int Crm { get; set; }
        public string Cpf { get; set; }
        public int IdEspecialidade { get; set; }
    }
}
