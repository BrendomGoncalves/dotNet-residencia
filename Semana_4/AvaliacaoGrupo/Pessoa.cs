namespace Avaliacao;

public class Pessoa
{
    // Atributos
    private string? _nome;
    private DateTime _nascimento;
    private string? _cpf;

    // Propriedades
    public string? Nome
    {
        get => _nome;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Nome não pode ser nulo");
            _nome = value;
        }
    }
    public DateTime Nascimento
    {
        get => _nascimento;
        set
        {
            if (value > DateTime.Now) throw new Exception("Data de nascimento inválida");
            _nascimento = value;
        }
    }
    public string? Cpf
    {
        get => _cpf;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 11) throw new Exception("Cpf não pode ser nulo");
            _cpf = value;
        }
    }
}