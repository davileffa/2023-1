using System;

namespace AP3.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
    }
}