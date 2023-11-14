#region Questao1
  Console.WriteLine("Numeros divisiveis por 3 e 4:");
  for(int i = 0; i<=30; i++){
    if(i % 3 == 0) Console.Write(i + " ");
    else if(i % 4 == 0) Console.Write(i + " ");
  }
  Console.WriteLine();
#endregion

#region Questao2
  Console.WriteLine("Sequencia de Fibonacci");
  Console.Write("0 ");
  int anterior = 0, proximo = 1;
  do{
    Console.Write(proximo + " ");
    int tmp = anterior;
    anterior = proximo;
    proximo += tmp;
  }while(proximo <= 100);
  Console.WriteLine();
#endregion

#region Questao3
  Console.WriteLine("Tabela:");
  for(int i=1; i<=8; i++){
    int x = i;
    for(int j=1; j<=i; j++){
      Console.Write(" " + x + " ");
      x += i;
    }
    Console.WriteLine();
  }
#endregion