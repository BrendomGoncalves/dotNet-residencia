using Cepedi.Domain.Entities;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class ObtemCursoHandlerTest
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly IProfessorRepository _professorRepository = Substitute.For<IProfessorRepository>();
    private readonly ObtemCursoHandler _sut;

    public ObtemCursoHandlerTest()
    {
        _sut = new ObtemCursoHandler(_cursoRepository, _professorRepository);
    }

    [Fact]
    public async Task ObterCursoAsync_QuandoObtido_DeveRetornarCursoEncontrado()
    {
        // Arrange
        var curso = new CursoEntity
        {
            Nome = "Teste",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            ProfessorId = 1
        };
        var professor = new ProfessorEntity(1, "Teste", "Especialidade_Teste");
        _cursoRepository.ObtemCursoPorIdAsync(1).ReturnsForAnyArgs(curso);
        _professorRepository.ObtemProfessorPorIdAsync(1).ReturnsForAnyArgs(professor);

        // Act
        var result = await _sut.ObterCursoAsync(1);

        // Assert
        Assert.Equal("Teste", result.curso);
    }

    [Fact]
    public async Task ObterCursosAsync_QuandoObtido_DeveRetornarUm()
    {
        // Arrange
        var curso = new CursoEntity
        {
            Nome = "Teste",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,
            ProfessorId = 1
        };
        var professor = new ProfessorEntity(1, "Teste", "Especialidade_Teste");
        _cursoRepository.ObtemCursosAsync().ReturnsForAnyArgs(new List<CursoEntity> { curso });
        _professorRepository.ObtemProfessorPorIdAsync(1).ReturnsForAnyArgs(professor);

        // Act
        var result = await _sut.ObterCursosAsync();

        // Assert
        Assert.Equal("Teste", result.First().curso);
    }
}
