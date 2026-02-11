using System;
using System.Collections.Generic;

namespace VhBurguer.Domains;

public partial class Log_AlteracaoProduto
{
    public int Log_AltercaoProdutoId { get; set; }

    public DateTime DataAlteracao { get; set; }

    public string NomeAnterior { get; set; } = null!;

    public decimal PrecoAnterior { get; set; }

    public int ProdutoId { get; set; }

    public virtual Produto Produto { get; set; } = null!;
}
