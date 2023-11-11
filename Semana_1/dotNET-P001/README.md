<h3> 1. Como você pode verificar se o .NET SDK está corretamente instalado em seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem ser usados para verificar a(s) versão(ões) do .NET SDK instalada(s), como remover e atualizar.</h3>
<p>R: Verificar versão (dotnet --version)<br>verificar versões (dotnet --list-sdks)<br>Remover (utilizar a ferramenta "dotnet tool uninstall")<br>Atualizar (utilizar a ferramenta "dotnet tool update")</p>

<h3>2. Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê exemplos de uso para cada um deles através de exemplos.</h3>
<p>R: sbyte (-128 a 127)<br>byte (0 a 255)<br>short (-32,768 a 32,767)
<br>ushort (0 a 65,535)<br>int (-2,147,483,648 a 2,147,483,647)
<br>uint (0 a 4,294,967,295)<br>long (-9,223,372,036,854,775,808 a 9,223,372,036,854,775,807)
<br>ulong (0 a 18,446,744,073,709,551,615)</p>

<h3>3. Suponha que você tenha uma variável do tipo double e deseja convertê-la em um tipo int. Como você faria essa conversão e o que aconteceria se a parte fracionária da variável double não pudesse ser convertida em um int? Resolva o problema através de um exemplo em C#.</h3>
<p>R: Para converter de double para int, pode usar a função de conversão Convert.ToInt32() ou o operador de cast (int). Porém, ao realizar a conversão a parte fracionária será truncada. Se a parte fracionária da variável double não puder ser representada em um int, o valor será arredondado para o inteiro mais próximo, significa que a parte decimal será simplesmente truncada, não arredondada.</p>

<h3>4. Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.</h3>
<p></p>