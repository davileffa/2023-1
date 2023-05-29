using System.Collections.Generic;
using System.Linq;
using AP3.Domain.Entities;
using AP3.Domain.Interfaces;
using AP3.Data;

namespace AP3.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DataContext _context;

        public VendaRepository(DataContext context)
        {
            _context = context;
        }

        public Venda GetById(int vendaId)
        {
            return _context.Vendas.FirstOrDefault(v => v.Id == vendaId);
        }

        public IList<Venda> GetAll()
        {
            return _context.Vendas.ToList();
        }

        public void Add(Venda venda)
        {
            _context.Vendas.Add(venda);
            _context.SaveChanges();
        }

        public void Update(Venda venda)
        {
            _context.Vendas.Update(venda);
            _context.SaveChanges();
        }

        public void Delete(int vendaId)
        {
            var venda = _context.Vendas.Find(vendaId);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                _context.SaveChanges();
            }
        }

        public decimal GetTotalVendas()
        {
             var vendas = _context.Vendas.ToList();
            double total = vendas.Sum(v => Convert.ToDouble(v.Total));
            return Convert.ToDecimal(total);
        }
    }
}
