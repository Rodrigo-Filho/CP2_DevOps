namespace ApiAgroCare.DTOS.Veterinario
{
    public class VeterinarioEditarDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string CRMV { get; set; }
        public long Telefone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
