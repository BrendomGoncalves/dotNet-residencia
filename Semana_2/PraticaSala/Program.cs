#region foreach
  string[] pessoas = {"Maria", "Joao", "Marcelo", "Fabricio", "Ana"};

  foreach(string pessoa in pessoas){
    Console.WriteLine(pessoa);
  }
#endregion

#region Name
  string? nome = Console.ReadLine();
  Console.WriteLine($"Nome digitado: {nome}");
#endregion