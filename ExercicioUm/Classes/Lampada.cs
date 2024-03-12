namespace ExercicioUm.Classes;

public class Lampada
{
    private bool Ligada { get;set; } = false;

    public Lampada(bool _ligarLampada)
    {
        if(_ligarLampada)
        {
            this.Ligar();
        }
    }

    public void Ligar(){
        this.Ligada = true;
    }
    public void Desligar(){
        this.Ligada = false;
    }
    public void ImprimirEstado(){
        if(this.Ligada)
        {
            System.Console.WriteLine("Lâmpada ligada!");
        }
        else
        {
            System.Console.WriteLine("Lâmpada desligada!");
        }
    }
}
