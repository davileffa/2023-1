using System.Collections.Generic;
using AP3.Domain.Entities;

namespace AP3.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Produto GetById(int productId);
        IList<Produto> GetAll();
        void Add(Produto produto);
        void Update(Produto produto);
        void Delete(int productId);
    }
}