#region Questao1
  Console.WriteLine("Questao Data:");
  string dataQualquer = "25/10/2023";
  string[] dataSeparada = dataQualquer.Split('/');
  foreach(string s in dataSeparada){
    Console.WriteLine(s);
  }
#endregion

#region Questao2
  Console.Write("Numeros pares: ");
  int[] inteiros = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
  foreach(int i in inteiros){
    if(i % 2 == 0) Console.Write(i + " ");
  }
  Console.WriteLine();
#endregion

#region Questao3
  Console.WriteLine("Cidades que comecam com a letra S:");
  List<string> cidades = new List<string>{"Rio de Janeiro", "São Paulo", "Belo Horizonte", "Brasília", "PortAlegre"};
  cidades.Add("Florianópolis");
  cidades.Add("Curitiba");
  cidades.Add("Santos");
  foreach(string cidade in cidades){
    if(cidade.StartsWith("S")){
      Console.WriteLine(cidade);
    }
  }
#endregion

#region Questao4
  Console.WriteLine("Diferença entre datas:");
  int dia, mes, ano, hora, minutos;
  Console.WriteLine("Digite a data: ");
  Console.Write("Dia: ");
  int.TryParse(Console.ReadLine(), out dia);
  Console.Write("Mes: ");
  int.TryParse(Console.ReadLine(), out mes);
  Console.Write("Ano: ");
  int.TryParse(Console.ReadLine(), out ano);
  Console.WriteLine("Digite a hora: ");
  Console.Write("Hora: ");
  int.TryParse(Console.ReadLine(), out hora);
  Console.Write("Minuto: ");
  int.TryParse(Console.ReadLine(), out minutos);
  
  DateTime data = new DateTime(ano, mes, dia, hora, minutos, 0);
  TimeSpan diferenca = DateTime.Today - data;
  Console.WriteLine("Diferença: " + diferenca);
  Console.WriteLine("Anos: " + diferenca.Days / 365);
#endregion