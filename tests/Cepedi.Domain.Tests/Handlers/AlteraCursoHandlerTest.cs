using Cepedi.Domain.Entities;
using Cepedi.Domain.Handlers;
using Cepedi.Shareable.Requests;
using NSubstitute;

namespace Cepedi.Domain.Tests;

public class AlteraCursoHandlerTest
{
    private readonly ICursoRepository _cursoRepository = Substitute.For<ICursoRepository>();
    private readonly AlteraCursoHandler _sut;

    public AlteraCursoHandlerTest()
    {
        _sut = new AlteraCursoHandler(_cursoRepository);
    }

    [Fact]
    public async Task AlterarCursoAsync_QuandoAlterado_DeveRetornarUm()
    {
        // Arrange
        var cursoNovo = new AlteraCursoRequest(
            1,
            "Teste",
            "Descricao",
            DateTime.Now,
            DateTime.Now,
            1
        );
        _cursoRepository.ObtemCursoPorIdAsync(cursoNovo.idCurso).ReturnsForAnyArgs(new CursoEntity());
        _cursoRepository.AlterarCursoAsync(new CursoEntity()).ReturnsForAnyArgs(1);

        // Act
        var result = await _sut.AlterarCursoAsync(cursoNovo);

        // Assert
        Assert.Equal(1, result);
    }
}
