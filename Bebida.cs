using System;
using System.Collections.Generic;
using System.Text;

namespace Lanchonete
{
    internal class Bebida : Item
    {
        public Bebida(string codigo, string nome, decimal preco)
            : base(codigo, nome, preco)
        {
        }
    }
}
