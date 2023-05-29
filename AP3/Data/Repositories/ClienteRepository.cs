using System.Collections.Generic;
using System.Linq;
using AP3.Domain.Entities;
using AP3.Domain.Interfaces;


namespace AP3.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public Cliente GetById(int clientId)
        {
            return _context.Clientes.FirstOrDefault(c => c.Id == clientId);
        }

        public IList<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int clientId)
        {
            var cliente = _context.Clientes.Find(clientId);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
