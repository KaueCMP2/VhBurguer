
namespace VhBurguer.DTOs.PromocaoDto
{
    public class LerPromocaoDTO
    {
        public int PromocaoId { get; set; }
        public string Nome { get; set; } = null!;

        public DateTime? DataExpiracao { get; set; }

        public bool? StatusPromocao { get; set; }


    }
}
