using System.Collections.Generic;
using AP3.Domain.Entities;

namespace AP3.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetById(int clientId);
        IList<Cliente> GetAll();
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int clientId);
    }
}