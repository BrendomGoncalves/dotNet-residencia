#region Tupla Exemplo
  var tuple1 = (10, 20);
  Console.WriteLine($"Tupla 1: {tuple1.Item1},  {tuple1.Item2}");
#endregion

#region Tupla Exemplo 2
  var tuple2 = (x: 5, y: 20);
  Console.WriteLine($"Tupla 2: {tuple2.x},  {tuple2.y}");
#endregion

#region Tupla Exemplo 3
  var tuple3 = (id: 10, name: "Helder", nascimento: new DateTime(1999, 5, 20));
  Console.WriteLine($"Tupla 3: {tuple3.id}, {tuple3.name}, {tuple3.nascimento}");
#endregion

#region Tupla Exemplo 4
  List<(int id, string name, DateTime nascimento)> lista = new();
  lista.Add(tuple3);
  lista.Add((11, "Nicole", new DateTime(2019, 1, 12)));
  Console.WriteLine("Tupla 4:");
  lista.ForEach(x => Console.WriteLine($"- {x.id}, {x.name}, {x.nascimento.ToString("dd/MM/yyyy")}"));
#endregion

#region Questão 1
  Console.WriteLine($"{CalcAge("Helder", new DateTime(1987, 9, 24))}");
  Console.WriteLine($"{CalcAge("Brendom", new DateTime(1999, 5, 20))}");

  (string, int) CalcAge(string name, DateTime aniversario){
    
    int age = DateTime.Today.Year - aniversario.Year;
    if(DateTime.Today.DayOfYear < aniversario.DayOfYear) age--;
    return (name, age);
  }
#endregion

#region Lambda Exemplo
  Func<int, int, int> soma = (x, y) => x + y;
  Console.WriteLine(soma(10, 20));

  Action<int, int> subtracao = (x, y) => Console.WriteLine($"Resultado da subtração: {x - y}");
  subtracao(50, 20);

  string[] nomes = {"Helder", "Nicole", "Brendom"};
  Console.WriteLine($"Nomes com 6 letras: {nomes.Where(x => x.Length == 6).Count()}");
#endregion

#region LINQ Exemplo
  List<int> listaNormal = new() {1, 2, 3, 4, 5};
  var listaAoQuadrado = listaNormal.Select(x => x * x);
  Console.WriteLine($"Lista Original: {string.Join(", ", listaNormal)}");
  Console.WriteLine($"Lista ao Quadrado: {string.Join(", ", listaAoQuadrado)}");

  var listaSomada = listaNormal.Select((x, index) => x + listaAoQuadrado.ElementAt(index));
  Console.WriteLine($"Summed List: {string.Join(", ", listaSomada)}");
#endregion