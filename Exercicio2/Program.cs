namespace Exercicio2;

class Program{
    static void Main(string[] args){
        object o = null;
        try{
            Console.WriteLine(o.ToString());
        }catch(NullReferenceException e){
            Console.WriteLine("Referência de objeto não definida como uma instância de um objeto.");
        }
    }
}
