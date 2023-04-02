using System;

public class Personagem
{
    public string Nome { get; set; }
    public int Forca { get; set; }
    public int Inteligencia { get; set; }
    public string[] Poderes { get; set; }
    
    public Personagem(string nome, int forca, int inteligencia, string[] poderes)
    {
        Nome = nome;
        Forca = forca;
        Inteligencia = inteligencia;
        Poderes = poderes;
    }
    
    public virtual void Lutar(Personagem oponente)
    {
        Console.WriteLine("{0} está lutando com {1}.", Nome, oponente.Nome);
    }
}

public class Heroi : Personagem
{
    public Heroi(string nome, int forca, int inteligencia, string[] poderes)
        : base(nome, forca, inteligencia, poderes)
    {
    }
    
    public override void Lutar(Personagem oponente)
    {
        if (Forca > oponente.Forca)
        {
            Console.WriteLine("{0} venceu a luta contra {1}!", Nome, oponente.Nome);
        }
        else if (Forca < oponente.Forca)
        {
            Console.WriteLine("{0} perdeu a luta contra {1}!", Nome, oponente.Nome);
        }
        else
        {
            Console.WriteLine("A luta entre {0} e {1} terminou em empate!", Nome, oponente.Nome);
        }
    }
}

public class Vilao : Personagem
{
    public Vilao(string nome, int forca, int inteligencia, string[] poderes)
        : base(nome, forca, inteligencia, poderes)
    {
    }
    
    public override void Lutar(Personagem oponente)
    {
        if (Inteligencia > oponente.Inteligencia)
        {
            Console.WriteLine("{0} venceu a luta contra {1}!", Nome, oponente.Nome);
        }
        else if (Inteligencia < oponente.Inteligencia)
        {
            Console.WriteLine("{0} perdeu a luta contra {1}!", Nome, oponente.Nome);
        }
        else
        {
            Console.WriteLine("A luta entre {0} e {1} terminou em empate!", Nome, oponente.Nome);
        }
    }
}

public class SuperHeroi : Heroi
{
    public SuperHeroi(string nome, int forca, int inteligencia, string[] poderes)
        : base(nome, forca, inteligencia, poderes)
    {
    }
    
    public void SuperPoder()
    {
        Console.WriteLine("{0} está usando seu superpoder!", Nome);
    }
}

public class SuperVilao : Vilao
{
    public SuperVilao(string nome, int forca, int inteligencia, string[] poderes)
        : base(nome, forca, inteligencia, poderes)
    {
    }
    
    public void SuperPoder()
    {
        Console.WriteLine("{0} está usando seu superpoder!", Nome);
    }
}

public class Program
{
    public static void Main()
{
    Heroi homemDeFerro = new Heroi("Homem de Ferro", 50, 90, new string[] { "Voo", "Lasers" });
    Vilao thanos = new Vilao("Thanos", 100, 60, new string[] { "Influência sobre a mente"});

    homemDeFerro.Lutar(thanos);
    thanos.Lutar(homemDeFerro);

    SuperHeroi superman = new SuperHeroi("Superman", 80, 80, new string[] { "Super força", "Super velocidade" });
    SuperVilao lexLuthor = new SuperVilao("Lex Luthor", 20, 100, new string[] { "Inteligência superior", "Dinheiro" });

    superman.SuperPoder();
    lexLuthor.SuperPoder();
}
};

        
        
