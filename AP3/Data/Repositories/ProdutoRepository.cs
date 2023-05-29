using System.Collections.Generic;
using System.Linq;
using AP3.Domain.Entities;
using AP3.Domain.Interfaces;
using AP3.Data;

namespace AP3.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _context;

        public ProdutoRepository(DataContext context)
        {
            _context = context;
        }

        public Produto GetById(int productId)
        {
            return _context.Produtos.FirstOrDefault(p => p.Id == productId);
        }

        public IList<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public void Add(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(int productId)
        {
            var produto = _context.Produtos.Find(productId);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}