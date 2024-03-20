using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class CriaCursoHandlerTests
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly CriaCursoHandler _sut;

    public CriaCursoHandlerTests()
    {
        _sut = new CriaCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task CriarCursoAsync_QuandoCriado_DeveRetornarUm()
    {
        // Arrange
        var curso = new CriaCursoRequest(
            "Teste",
            "Descricao",
            DateTime.Now,
            DateTime.Now,
            1
        );

        _cursoRepository.CriaNovoCursoAsync(new ()).ReturnsForAnyArgs(1);

        // Act
        var result = await _sut.CriarCursoAsync(curso);

        // Assert
        Assert.Equal(1, result);
    }
}
