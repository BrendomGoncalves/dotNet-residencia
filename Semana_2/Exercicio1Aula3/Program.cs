#region Questao1
  Console.WriteLine("Numeros divisiveis por 3 e 4:");
  for(int i = 0; i<=30; i++){
    if(i % 3 == 0) Console.WriteLine(i);
    else if(i % 4 == 0) Console.WriteLine(i);
  }
#endregion

#region Questao2
  Console.WriteLine("Sequencia de Fibonacci");
  Console.WriteLine("0");
  int anterior = 0, proximo = 1;
  do{
    Console.WriteLine(proximo);
    int tmp = anterior;
    anterior = proximo;
    proximo += tmp;
  }while(proximo <= 100);
#endregion

#region Questao3
  Console.WriteLine("Tabela:");
  
#endregion