namespace Avaliacao;

public class Exercicio
{
    // Atributos
    private string? _grupoMuscular;
    private int _series;
    private int _repeticoes;
    private int _tempoIntervalo;
    
    // Propriedades
    public string? GrupoMuscular
    {
        get => _grupoMuscular;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new Exception("Grupo Muscular não pode ser nulo");
            _grupoMuscular = value;
        }
    }
    public int Series
    {
        get => _series;
        set
        {
            if (value < 0) throw new Exception("Séries não pode ser negativa");
            _series = value;
        }
    }
    public int Repeticoes
    {
        get => _repeticoes;
        set
        {
            if (value < 0) throw new Exception("Repetições não pode ser negativa");
            _repeticoes = value;
        }
    }
    public int TempoIntervalo
    {
        get => _tempoIntervalo;
        set
        {
            if (value < 0) throw new Exception("Tempo de Intervalo não pode ser negativa");
            _tempoIntervalo = value;
        }
    }
}