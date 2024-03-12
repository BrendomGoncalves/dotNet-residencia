namespace ExercicioDois.Classes
{
    public class Data
    {
        public int Dia { get; private set; }
        public int Mes { get; private set; }
        public int Ano { get; private set; }
        public int Hora { get; private set; }
        public int Minuto { get; private set; }
        public int Segundo { get; private set; }
        public const int FORMATO_24 = 24;
        public const int FORMATO_12 = 12;

        public Data() { }

        public Data(int dia, int mes, int ano)
        {
            if (dia < 1 || dia > 31) Dia = 1;
            else Dia = dia;

            if (mes < 1 || mes > 12) Mes = 1;
            else Mes = mes;

            if (ano < 1) Ano = 1;
            else Ano = ano;
        }

        public Data(int dia, int mes, int ano, int hora, int minuto, int segundo) : this(dia, mes, ano)
        {
            if (hora < 0 || hora > 23) Hora = 0;
            else Hora = hora;

            if (minuto < 0 || minuto > 59) Minuto = 0;
            else Minuto = minuto;

            if (segundo < 0 || segundo > 59) Segundo = 0;
            else Segundo = segundo;
        }

        public void Imprimir(int formato)
        {
            if (Dia == 0 && Mes == 0 && Ano == 0 && Hora == 0 && Minuto == 0 && Segundo == 0)
            {
                Console.WriteLine("Não há data e hora definida.");
            }
            else
            {
                if (Hora == 0 && Minuto == 0 && Segundo == 0)
                {
                    Console.WriteLine($"{Dia}/{Mes}/{Ano}");
                }
                else
                {
                    if (formato == 24)
                    {
                        Console.WriteLine($"{Dia}/{Mes}/{Ano} {Hora}:{Minuto}:{Segundo}");
                    }
                    else
                    {
                        if (Hora > 12)
                        {
                            Console.WriteLine($"{Dia}/{Mes}/{Ano} {Hora - 12}:{Minuto}:{Segundo} PM");
                        }
                        else
                        {
                            Console.WriteLine($"{Dia}/{Mes}/{Ano} {Hora}:{Minuto}:{Segundo} AM");
                        }
                    }
                }
            }
        }
    }
}
