using System;
using System.Collections.Generic;
using System.Text;

namespace Lanchonete
{
    internal class Lanche : Item
    {
        public List<Ingrediente> IngredientesExtras {  get; }
        private List<Ingrediente> _ingredientesSelecionados = new List<Ingrediente>();

        public Lanche(string codigo, string nome, decimal preco, List<Ingrediente> ingredientesExtras)
            : base(codigo, nome, preco)
        {
            IngredientesExtras = ingredientesExtras;
        }

        public decimal PegarPrecoTotal()
        {
            var precoIngredientes = 0m;
            foreach (var ingrediente in _ingredientesSelecionados)
            {
                precoIngredientes += ingrediente.Preco;
            }

            return Preco + precoIngredientes;
        }

        public void AdicionarIngredientes(List<Ingrediente> ingredientes)
        {
            foreach ( var ingrediente in ingredientes )
            {
                if(_ingredientesSelecionados.Contains(ingrediente))
                {
                    return;
                }
            }

            _ingredientesSelecionados.AddRange(ingredientes);
        }

        public List<Ingrediente> PegarIngedientesSelecionados()
        {
            return _ingredientesSelecionados;
        }
    }
}
