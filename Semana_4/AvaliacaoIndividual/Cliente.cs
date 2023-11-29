namespace Semana_4.AvaliacaoIndividual;

public class Cliente : Usuario
{
    public Cliente(string _nome, DateTime _dataNascimento, string _cpf, double _altura, double _peso) : base(_nome, _dataNascimento, _cpf)
    {
        Altura = _altura;
        Peso = _peso;
    }
    private double _altura;
    private double _peso;
    public double Altura
    {
        get { return _altura; }
        set
        {
            if (value > 0) _altura = value;
            else throw new Exception("Altura invalida!");
        }
    }
    public double Peso
    {
        get { return _peso; }
        set
        {
            if (value > 0) _peso = value;
            else throw new Exception("Peso invalido!");
        }
    }
}