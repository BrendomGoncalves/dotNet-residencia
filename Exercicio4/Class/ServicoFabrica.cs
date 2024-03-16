namespace Exercicio4.Class;

using Exercicio4.Class.Interface;

public class ServicoFabrica<T> where T : IServico, new(){
    public T NovaInstancia(){
        return new T();
    }
}
