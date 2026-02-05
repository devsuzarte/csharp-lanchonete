using System;
using System.Collections.Generic;
using System.Text;

namespace Lanchonete.src.Entidades
{
    internal class Ingrediente
    {
        public string Nome { get; }
        public decimal Preco { get; }

        public Ingrediente(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
        
    }
}
