using System.Collections.Generic;
using AP3.Domain.Entities;

namespace AP3.Domain.Interfaces
{
    public interface IVendaRepository
    {
        Venda GetById(int vendaId);
        IList<Venda> GetAll();
        void Add(Venda venda);
        void Update(Venda venda);
        void Delete(int vendaId);
        decimal GetTotalVendas();
    }
}