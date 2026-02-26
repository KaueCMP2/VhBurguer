// C#
public class CategoriaService
{
    private readonly ICategoriaRepository _repository;

    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    // restante do código...
}

// Program.cs
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaService>();