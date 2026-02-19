using VhBurguer.Exceptions;

namespace VhBurguer.Aplications.Regras
{
    public class HorarioAlteracaoProduto
    {
        public static void ValidarHorario()
        {
            var agora = DateTime.Now.TimeOfDay;
            var abertura = new TimeSpan(10, 0, 0); //10h00
            var fechamento = new TimeSpan(23, 0, 0); //23h00

            var estaAberto = agora >= abertura && agora <= fechamento;

            if (estaAberto)
            {
                throw new DomainException("Produto só pode ser modificado após o fim do horário de funcionamento!");
            }
        }
    }
}
