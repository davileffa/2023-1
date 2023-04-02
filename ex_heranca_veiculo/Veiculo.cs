using System;

public class Veiculo
{
    public string Modelo { get; set; }
    
    public virtual void Acelerar()
    {
        Console.WriteLine("Acelerando veículo!");
    }
}

public class Carro : Veiculo
{
    public override void Acelerar()
    {
        Console.WriteLine("Acelerando carro!");
    }
}

public class Moto : Veiculo
{
    public override void Acelerar()
    {
        Console.WriteLine("Acelerando moto!");
    }
}

public class Program
{
    public static void Main()
    {
        Veiculo veiculo = new Veiculo();
        veiculo.Modelo = "Veículo genérico";
        veiculo.Acelerar();
        
        Carro carro = new Carro();
        carro.Modelo = "Fusca";
        carro.Acelerar();
        
        Moto moto = new Moto();
        moto.Modelo = "Harley-Davidson";
        moto.Acelerar();
    }
}
