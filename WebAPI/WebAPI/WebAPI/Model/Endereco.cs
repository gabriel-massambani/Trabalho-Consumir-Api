namespace WebAPI.Model
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        // Relação de navegação inversa
        public ICollection<Cliente> Clientes { get; set; }
    }
}
