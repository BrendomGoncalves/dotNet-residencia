using Microsoft.AspNetCore.Mvc;

namespace TechMed.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{
    private static readonly string[] Nomes = new[]{
        "Maria", "Pedro", "Ana", "Lucas", "Luciana", "Mariana", "Carla", "Bruna", "Larissa"
    };
    private static readonly string[] Especialidades = new[]{
        "Cardiologista", "Dermatologista", "Oftalmologista", "Ortopedista", "Pediatria", "Psiquiatra", "Urologista"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public MedicoController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMedico")]
    public IEnumerable<Medico> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Medico
        {
            Crm = Random.Shared.Next(1, 10000000).ToString(),
            Nome = Nomes[Random.Shared.Next(Nomes.Length)],
            Especialidade = Especialidades[Random.Shared.Next(Especialidades.Length)],
            Salario = Random.Shared.Next(1000, 10000)
        })
        .ToArray();
    }
    [HttpDelete("{crm}")]
    public IActionResult Delete(string crm)
    {
        // Logic to delete the médico with the specified CRM
        // This should involve removing the médico from the database or in-memory collection
        // For example, if you have a list _medicos, you could do:
        // var medicoToRemove = _medicos.FirstOrDefault(m => m.Crm == crm);
        // if (medicoToRemove != null)
        // {
        //     _medicos.Remove(medicoToRemove);
        //     return Ok();
        // }
        // else
        // {
        //     return NotFound($"Médico with CRM {crm} not found.");
        // }

        // Placeholder for the actual delete operation
        throw new NotImplementedException();
    }
    [HttpPut("{crm}")]
    public IActionResult Update(string crm, Medico medico)
    {
        // lógica para inseri
        return Ok();
    }
    [HttpPost(Name = "UpdateMedico")]
    public IActionResult Create(Medico medico){
        var nome = HttpContext.Request.Query["nome"].ToString();
        var especialidade = HttpContext.Request.Query["especialidade"].ToString();
        var salario = decimal.Parse(HttpContext.Request.Query["salario"]);

        medico.Nome = nome;
        medico.Especialidade = especialidade;
        medico.Salario = (float)salario;

        // Continue with the logic to create a new Medico with the provided details
        return Ok();
    }
}
