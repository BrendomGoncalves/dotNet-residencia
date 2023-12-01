namespace Avaliacao;

public class Treinador
{
    // Atributos
    private string? _cref;
    
    // Propriedades
    public string? Cref
    {
        get => _cref;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Cref não pode ser nulo");
            _cref = value;
        }
    }
}