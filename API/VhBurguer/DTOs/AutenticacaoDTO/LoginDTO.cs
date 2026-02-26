namespace VhBurguer.DTOs.AutenticacaoDto
{
	public class LoginDto
	{
		public string Email { get; set; } = null!;
		public string Senha { get; set; } = null!;
		public bool StatusUsuario { get; set; }
	}
}