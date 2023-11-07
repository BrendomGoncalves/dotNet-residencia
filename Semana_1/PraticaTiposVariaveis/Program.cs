#region TiposDados
  int tipoInteiro;
  double tipoDouble;
  decimal tipoDecimal;
  long tipoLong;
  float tipoFloat;

  tipoInteiro = int.MaxValue;
  tipoDouble = double.MaxValue;
  tipoDecimal = decimal.MaxValue;
  tipoLong = long.MaxValue;
  tipoFloat = float.MaxValue;

  Console.WriteLine($"Este valor {tipoInteiro} eh o maior Inteiro possivel.");
  Console.WriteLine($"Este valor {tipoDouble} eh o maior Double possivel.");
  Console.WriteLine($"Este valor {tipoDecimal} eh o maior Decimal possivel.");
  Console.WriteLine($"Este valor {tipoLong} eh o maior Long possivel.");
  Console.WriteLine($"Este valor {tipoFloat} eh o maior Float possivel.");

#endregion