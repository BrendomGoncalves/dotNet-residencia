namespace Avaliacao;

public class Cliente
{
    private float _altura;
    private float _peso;
    
    // Propriedades
    public float Altura
    {
        get => _altura;
        set
        {
            if (value < 0) throw new Exception("Altura não pode ser negativa");
            _altura = value;
        }
    }
    public float Peso
    {
        get => _peso;
        set
        {
            if (value < 0) throw new Exception("Peso não pode ser negativo");
            _peso = value;
        }
    }
}