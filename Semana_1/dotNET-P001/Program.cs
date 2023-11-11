// 4. Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.

int x = 10, y = 3;

Console.WriteLine("Adicao: " + (x + y));
Console.WriteLine("Subtracao: " + (x - y));
Console.WriteLine("Multiplicacao: " + (x * y));
Console.WriteLine("Divisao: " + (x / y));

// 5. Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar se a é maior que b e exiba o resultado.

int a = 5, b = 8;

Console.WriteLine("a é maior que b?\nresposta: " + (a > b));

// 6. Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva código para verificar se as duas strings são iguais e exibir o resultado.

string str1 = "Hello", str2 = "World";

if(str1 == str2) Console.WriteLine("As duas strings são iguais");
else Console.WriteLine("As duas strings são diferentes");

// 7. Suponha que você tenha duas variáveis booleanas, bool condicao1 = true e bool condicao2 = false. Escreva código para verificar se ambas as condições são verdadeiras e
// exiba o resultado.

bool condicao1 = true, condicao2 = false;

if(condicao1 && condicao2) Console.WriteLine("Ambas as condicoes sao verdadeiras");

//8. Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.

int num1 = 7, num2 = 3, num3 = 10;

if(num1 > num2) Console.WriteLine("Num1 é maior que Num2");
if(num3 == (num1 + num2)) Console.WriteLine("Num3 é igual a soma de Num1 e Num2");