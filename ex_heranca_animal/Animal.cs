using System;

abstract class Animal {
    public string Nome { get; set; }

    public abstract void Falar();
}

class Cachorro : Animal {
    public override void Falar() {
        Console.WriteLine("Au au!");
    }
}

class Gato : Animal {
    public override void Falar() {
        Console.WriteLine("Miau!");
    }
}

class Program {
    static void Main(string[] args) {
        Animal cachorro = new Cachorro();
        cachorro.Nome = "Rex";
        cachorro.Falar();

        Animal gato = new Gato();
        gato.Nome = "Mimi";
        gato.Falar();
    }
}
