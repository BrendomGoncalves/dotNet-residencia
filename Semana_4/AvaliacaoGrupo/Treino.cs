namespace Avaliacao;

public class Treino
{
    // Construtores
    public Treino() {}
    public Treino(string tipo, string objetivo, int duracao, DateTime dataInicio, int vencimento, Treinador? treinador)
    {
        Tipo = tipo;
        Objetivo = objetivo;
        Duracao = duracao;
        DataInicio = dataInicio;
        Vencimento = vencimento;
        Treinador = treinador;
        _exercicios = new List<Exercicio>();
        _clientes = new List<(Cliente, int)?>();
    }
    
    // Atributos
    private string? _tipo;
    private string? _objetivo;
    private int _duracao;
    private DateTime _dataInicio;
    private int _vencimento;
    private Treinador? _treinador;
    private List<Exercicio>? _exercicios;
    private List<(Cliente,int)?>? _clientes;
    
    // Propriedades
    public string? Tipo
    {
        get => _tipo;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Especie não pode ser nulo");
            _tipo = value;
        }
    }
    public string? Objetivo
    {
        get => _objetivo;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Objetivo não pode ser nulo");
            _objetivo = value;
        }
    }
    public int Duracao
    {
        get => _duracao;
        set
        {
            if (value < 0) throw new Exception("Duração não pode ser negativa");
            _duracao = value;
        }
    }
    public DateTime DataInicio
    {
        get => _dataInicio;
        set
        {
            if (value > DateTime.Now) throw new Exception("Data de início inválida");
            _dataInicio = value;
        }
    }
    public int Vencimento
    {
        get => _vencimento;
        set
        {
            if (value < 0) throw new Exception("Vencimento não pode ser negativo");
            _vencimento = value;
        }
    }
    public Treinador? Treinador
    {
        get => _treinador;
        set
        {
            if (value == null) throw new Exception("Treinador não pode ser nulo");
            _treinador = value;
        }
        
    }
    
    // Metodos
    public int tamanhoExercicios()
    {
        return _exercicios?.Count ?? 0;
    }
    public int tamanhoClientes()
    {
        return _clientes?.Count ?? 0;
    }
}