public class ProdutoRepository : IProdutoRepository
{
    private List<Produto> _produtos;

    public ProdutoRepository()
    {
        _produtos = new List<Produto>();
    }

    public Produto GetById(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public List<Produto> GetAll()
    {
        return _produtos;
    }

    public void Add(Produto produto)
    {
        _produtos.Add(produto);
    }

    public void Remove(Produto produto)
    {
        _produtos.Remove(produto);
    }

    public void Update(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        _produtos[index] = produto;
    }
}
