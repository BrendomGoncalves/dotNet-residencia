namespace Semana_4.AvaliacaoIndividual;

public class Usuario
{
    public Usuario(string? _nome, DateTime _dataNascimento, string? _cpf)
    {
        Nome = _nome;
        DataNascimento = _dataNascimento;
        Cpf = _cpf;
    }
    private string _cpf;
    private DateTime _dataNascimento;
    public string? Nome { get; set; }
    public DateTime DataNascimento
    {
        get { return _dataNascimento; }
        set
        {
            if (value < DateTime.Now) _dataNascimento = value;
            else throw new Exception($"{value} - Data invalida!");
        }
    }
    public string? Cpf
    {
        get { return _cpf; }
        set
        {
            if (ValidarCpf(value)) _cpf = value;
            else throw new Exception("CPF invalido!");
        }
    }
    
    private bool ValidarCpf(string cpf)
    {
        if (cpf.Length != 11 || cpf == null) return false;
        return true;
    }
}