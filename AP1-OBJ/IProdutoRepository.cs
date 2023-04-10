public interface IProdutoRepository
{
    Produto GetById(int id);
    List<Produto> GetAll();
    void Add(Produto produto);
    void Remove(Produto produto);
    void Update(Produto produto);
}
