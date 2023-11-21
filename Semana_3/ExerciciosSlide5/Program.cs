#region Tuplas
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
  
#endregion

#region LINQ com Lista
  
#endregion

#region LINQ com Array
  
#endregion

#region Combinação de Tuplas, Expressõẽs Lambda e LINQ
  
#endregion