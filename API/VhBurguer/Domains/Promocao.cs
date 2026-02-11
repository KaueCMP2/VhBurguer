using System;
using System.Collections.Generic;

namespace VhBurguer.Domains;

public partial class Promocao
{
    public int PromocaoId { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? DataExpiracao { get; set; }

    public bool? StatusPromocao { get; set; }
}
