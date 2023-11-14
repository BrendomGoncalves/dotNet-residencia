class ProgramaTarefas
{
  static void Main()
  {
    List<Tarefa> tarefas = new List<Tarefa>();
    char opcao;
    do
    {
      Console.Clear();
      Console.WriteLine("GERENCIADOR DE TAREFAS");
      Console.WriteLine("1. Nova tarefa");
      Console.Write("5. Exit\n> ");
      opcao = Console.ReadKey().KeyChar;
      Console.WriteLine();
      switch (opcao)
      {
        case '1':
          break;
        case '2':
          break;
        case '3':
          break;
        case '4':
          break;
        case '5':
          Console.Clear();
          Console.WriteLine("Encerrando...");
          break;
        default:
          Console.WriteLine("\nOpção inválida, escolha uma opção existente!");
          break;
      }
      if(opcao != '5'){
        Console.Write("Pressione ENTER para continuar...");
        Console.ReadKey();
      }
    } while (opcao != '5');
  }
}