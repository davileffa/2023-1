class Program
{
    static void Main(string[] args)
    {
        var produtoRepository = new ProdutoRepository();

        while (true)
        {
            Console.WriteLine("1. Listar produtos");
            Console.WriteLine("2. Adicionar produto");
            Console.WriteLine("3. Atualizar produto");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var produtos = produtoRepository.GetAll();
                    foreach (var produto in produtos)
                    {
                        Console.WriteLine($"Id: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}, Quantidade: {produto.Quantidade}");
                    }
                    break;
                case "2":
                    Console.Write("Digite o nome do produto: ");
                    var nome = Console.ReadLine();
                    Console.Write("Digite o preço do produto: ");
                    var preco = decimal.Parse(Console.ReadLine());
                    Console.Write("Digite a quantidade do produto: ");
                    var quantidade = int.Parse(Console.ReadLine());

                    var produtoNovo = new Produto
                    {
                        Nome = nome,
                        Preco = preco,
                        Quantidade = quantidade
                    };

                    produtoRepository.Add(produtoNovo);
                    break;
                case "3":
                    Console.Write("Digite o Id do produto: ");
                    var id = int.Parse(Console.ReadLine());

                    var produtoExistente = produtoRepository.GetById(id);

                    if (produtoExistente == null)
                    {
                        Console.WriteLine("Produto não encontrado.");
                        break;
                    }

                    Console.Write("Digite o novo nome do produto: ");
                    var novoNome = Console.ReadLine();
                    Console.Write("Digite o novo preço do produto: ");
                    var novoPreco = decimal.Parse(Console.ReadLine());
                    Console.Write("Digite a nova quantidade do produto: ");
                    var novaQuantidade = int.Parse(Console.ReadLine());

                    // verificação de nulidade
                    if (produtoExistente != null)
                    {
                        produtoExistente.Nome = novoNome;
                        produtoExistente.Preco = novoPreco;
                        produtoExistente.Quantidade = novaQuantidade;

                        produtoRepository.Update(produtoExistente);
                    }
                    break;
            }
        }
    }
}
