#region Tuplas
  Console.WriteLine("-- Tuplas: ");
  (string, int) SuaIdade(string name, DateTime aniversario){
    int age = DateTime.Today.Year - aniversario.Year;
    if(DateTime.Today.DayOfYear < aniversario.DayOfYear) age--;
    return (name, age);
  }

  List<(string, int)> dados = new();
  dados.Add(SuaIdade("Bruno", new DateTime(2000, 1, 19)));
  dados.Add(SuaIdade("Maria", new DateTime(1993, 6, 8)));
  dados.Add(SuaIdade("João", new DateTime(2005, 12, 25)));
  Console.WriteLine("Informações: ");
  foreach(var dado in dados) Console.WriteLine($"{dado.Item1}, Idade: {dado.Item2}");
#endregion

#region Expressões Lambda
  Console.WriteLine("-- Expressões Lambda: ");
  Func<int, int> somaDosQuadrados = x => x*x + x*x;
  Console.WriteLine($"Soma dos quadrados de 10: {somaDosQuadrados(10)}");
  Console.WriteLine($"Soma dos quadrados de 5: {somaDosQuadrados(5)}");
  Console.WriteLine($"Soma dos quadrados de 50: {somaDosQuadrados(50)}");
#endregion

#region LINQ com Lista
  Console.WriteLine("-- LINQ com Lista: ");
  List<(string nome, int idade)> dadosPessoas = new();
  dadosPessoas.Add((nome: "Bruna", idade: 30));
  dadosPessoas.Add((nome: "Maria", idade: 46));
  dadosPessoas.Add((nome: "Bruno", idade: 21));
  dadosPessoas.Add((nome: "Brendom", idade: 24));
  Console.WriteLine($"Pessoas com mais de 30 anos: {string.Join(", ", dadosPessoas.Where(x => x.idade >= 30).Select(x => x.nome))}");
#endregion

#region LINQ com Array
  Console.WriteLine("-- LINQ com Array: ");
  int[] numerosInteiros = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  Console.WriteLine($"Numeros pares: {string.Join(", ", numerosInteiros.Where(x => x % 2 == 0))}");
#endregion

#region Combinação de Tuplas, Expressõẽs Lambda e LINQ
  
#endregion