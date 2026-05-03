namespace VhBurguer.DTOs.CategoriaDTO
{
    public class CriarCategoriaDTO
    {
        public string Nome { get; set; }
        public CriarCategoriaDTO(string nome)
        {
            Nome = nome;
        }
    }
}
