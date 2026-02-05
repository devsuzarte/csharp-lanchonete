using System;
using System.Collections.Generic;
using System.Text;

namespace Lanchonete.src.Entidades
{
    internal class Item
    {
        public string Codigo { get; }
        public string Nome { get; }
        public decimal Preco { get; }

        public Item(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
    }
}
