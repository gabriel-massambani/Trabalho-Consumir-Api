namespace WebAPI.Model
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        // Chave estrangeira
        public int EnderecoId { get; set; }

        // Relação de navegação
        public Endereco Endereco { get; set; }


    }
}
