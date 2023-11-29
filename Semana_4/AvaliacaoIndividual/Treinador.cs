namespace Semana_4.AvaliacaoIndividual;

public class Treinador : Usuario
{
    public Treinador(string _nome, DateTime _dataNascimento, string _cpf, string _cref) : base(_nome, _dataNascimento, _cpf)
    {
        CREF = _cref;
    }
    public string CREF{ get; set; }
}