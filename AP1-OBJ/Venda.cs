public class Venda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public Cliente Cliente { get; set; }
    public List<Produto> Produtos { get; set; }
}
