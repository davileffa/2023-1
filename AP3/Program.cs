using AP3.Domain.Entities;
using AP3.Domain.Interfaces;
using AP3.Data;
using AP3.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AP3
{
    
    public class Program 
    {
        private static IProdutoRepository _produtoRepository;
    private static IClienteRepository _clienteRepository;
    private static IVendaRepository _vendaRepository;
    private static DataContext _context;

    public static void Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite("Data Source=AP3.db")
            .Options;

         _context = new DataContext(options);
        {
            _produtoRepository = new ProdutoRepository(_context);
            _clienteRepository = new ClienteRepository(_context);
            _vendaRepository = new VendaRepository(_context);

        // Resto do seu código...
    }
            // Menu principal
            int opcao;
            do
            {
                Console.WriteLine("===== SISTEMA DE VENDAS =====");
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Listar produtos");
                Console.WriteLine("3 - Cadastrar cliente");
                Console.WriteLine("4 - Listar clientes");
                Console.WriteLine("5 - Realizar venda");
                Console.WriteLine("6 - Total de vendas");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=============================");
                Console.Write("Escolha uma opção: ");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        CadastrarCliente();
                        break;
                    case 4:
                        ListarClientes();
                        break;
                    case 5:
                        RealizarVenda();
                        break;
                    case 6:
                        TotalVendas();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 0);
        }

       private static void CadastrarProduto()
    {
        using (var context = new DataContext())
        {
            var produtoRepository = new ProdutoRepository(context);

            Console.WriteLine("===== CADASTRAR PRODUTO =====");
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Preço do produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());

              Produto produto = new Produto { Nome = nome, Preco = preco };
            _produtoRepository.Add(produto); 

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
    }

        private static void ListarProdutos()
{
    Console.WriteLine("===== LISTAR PRODUTOS =====");
    var produtos = _produtoRepository.GetAll();

    foreach (var produto in produtos)
    {
        Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: {produto.Preco}");
    }

    Console.WriteLine("=============================");
    Console.WriteLine("Opções:");
    Console.WriteLine("1 - Deletar produto");
    Console.WriteLine("2 - Editar produto");
    Console.WriteLine("0 - Voltar ao menu principal");
    Console.Write("Escolha uma opção: ");
    int opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.Write("Digite o ID do produto a ser deletado: ");
            int produtoId = Convert.ToInt32(Console.ReadLine());
            _produtoRepository.Delete(produtoId);
            Console.WriteLine("Produto deletado com sucesso!");
            break;
        case 2:
            Console.Write("Digite o ID do produto a ser editado: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var produto = _produtoRepository.GetById(id);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                break;
            }
            Console.WriteLine($"Editando produto ID: {produto.Id}");

            Console.Write("Novo nome: ");
            string novoNome = Console.ReadLine();
            Console.Write("Novo preço: ");
            decimal novoPreco = Convert.ToDecimal(Console.ReadLine());

            produto.Nome = novoNome;
            produto.Preco = novoPreco;

            _produtoRepository.Update(produto);
            Console.WriteLine("Produto atualizado com sucesso!");
            break;
        case 0:
            Console.WriteLine("Voltando ao menu principal...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

        private static void CadastrarCliente()
    {
    Console.WriteLine("===== CADASTRAR CLIENTE =====");
    Console.Write("ID do cliente: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("E-mail do cliente: ");
    string email = Console.ReadLine();

    Cliente cliente = new Cliente { Id = id, Nome = nome, Email = email };
    _clienteRepository.Add(cliente);

    Console.WriteLine("Cliente cadastrado com sucesso!");
    }

        private static void ListarClientes()
{
    Console.WriteLine("===== LISTAR CLIENTES =====");
    var clientes = _clienteRepository.GetAll();

    foreach (var cliente in clientes)
    {
        Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | E-mail: {cliente.Email}");
    }

    Console.WriteLine("=============================");
    Console.WriteLine("Opções:");
    Console.WriteLine("1 - Deletar cliente");
    Console.WriteLine("2 - Editar cliente");
    Console.WriteLine("0 - Voltar ao menu principal");
    Console.Write("Escolha uma opção: ");
    int opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            Console.Write("Digite o ID do cliente a ser deletado: ");
            int clienteId = Convert.ToInt32(Console.ReadLine());
            _clienteRepository.Delete(clienteId);
            Console.WriteLine("Cliente deletado com sucesso!");
            break;
        case 2:
            Console.Write("Digite o ID do cliente a ser editado: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                break;
            }
            Console.WriteLine($"Editando cliente ID: {cliente.Id}");

            Console.Write("Novo nome: ");
            string novoNome = Console.ReadLine();
            Console.Write("Novo e-mail: ");
            string novoEmail = Console.ReadLine();

            cliente.Nome = novoNome;
            cliente.Email = novoEmail;

            _clienteRepository.Update(cliente);
            Console.WriteLine("Cliente atualizado com sucesso!");
            break;
        case 0:
            Console.WriteLine("Voltando ao menu principal...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

        private static void RealizarVenda()
        {
            Console.WriteLine("===== REALIZAR VENDA =====");
            ListarClientes();
            Console.Write("Digite o ID do cliente: ");
            int clienteId = Convert.ToInt32(Console.ReadLine());

            var cliente = _clienteRepository.GetById(clienteId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            ListarProdutos();
            Console.Write("Digite o ID do produto: ");
            int produtoId = Convert.ToInt32(Console.ReadLine());

            var produto = _produtoRepository.GetById(produtoId);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado!");
                return;
            }

            Console.Write("Quantidade: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            Venda venda = new Venda { Cliente = cliente, Produto = produto, Quantidade = quantidade };
            _vendaRepository.Add(venda);

            Console.WriteLine("Venda realizada com sucesso!");
        }

        private static void TotalVendas()
        {
            Console.WriteLine("===== TOTAL DE VENDAS =====");
            decimal total = _vendaRepository.GetTotalVendas();
            Console.WriteLine($"O total de vendas é: R$ {total}");
        }
    }
}
