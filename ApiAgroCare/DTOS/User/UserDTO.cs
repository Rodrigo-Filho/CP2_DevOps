using ApiAgroCare.Model;

namespace ApiAgroCare.DTOS.User
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Number { get; set; }
        public string Endereco { get; set; }
        public int NumerosAnimais { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Planos Planos { get; set; }
    }
}
