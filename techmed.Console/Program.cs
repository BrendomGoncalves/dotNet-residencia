using techmed.Domain.Entities;
using techmed.Persistence.Context;

namespace techmed.Console;

public class Program
{
    public static void Main()
    {
        var context = new TechMedContext();

        System.Console.WriteLine($"Lendo todos os médicos no banco de dados");
        foreach (var med in context.Medicos.OrderBy(m => m.Nome))
        {
            System.Console.WriteLine($"Id: {med.MedicoId} - Nome: {med.Nome} - CRM: {med.CRM}");
        }

        System.Console.WriteLine($"Lendo todos os pacientes no banco de dados");
        foreach (var pac in context.Pacientes.OrderBy(m => m.Nome))
        {
            System.Console.WriteLine($"Id: {pac.PacienteId} - Nome: {pac.Nome} - CRM: {pac.CPF}");
        }

        System.Console.WriteLine($"Criar um médico no banco de dados");
        var medico = new Medico
        {
            Nome = "Dr. Dexter",
            CPF = "123.456.789-00",
            CRM = "123456",
            Especialidade = "Clínico Geral",
            Salario = 10000
        };
        context.Medicos.Add(medico);

        System.Console.WriteLine($"Criar um paciente no banco de dados");
        var paciente = new Paciente
        {
            Nome = "Valber",
            CPF = "101.202.303-00",
            Endereco = "Rua A, 0",
            Telefone = "1234-5678"
        };
        context.Pacientes.Add(paciente);

        context.SaveChanges();

        System.Console.WriteLine($"Atualizando o nome de um paciente no banco de dados");
        var doente = context.Pacientes.Where(p => p.CPF == "101.202.303-00").FirstOrDefault();
        doente.Nome = "João";
        context.Pacientes.Update(doente);

        context.SaveChanges();

        System.Console.WriteLine($"Removendo o primeiro médico no banco de dados");
        var primeiroMedico = context.Medicos.FirstOrDefault();
        context.Medicos.Remove(primeiroMedico);

        context.SaveChanges();

        System.Console.WriteLine($"Finalizando o programa");
    }
}
