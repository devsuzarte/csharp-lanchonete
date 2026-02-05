using Lanchonete.src.Entidades;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lanchonete.src
{
    internal class Sistema
    {
        public List<Item> Cardapio = new List<Item>();
        public List<Item> Pedidos = new List<Item>();
        public Sistema(List<Item> Cardapio)
        { 
            this.Cardapio = Cardapio;
        }

        public async Task Home(string erro = "")
        {
            Console.Clear();
            this.Pedidos.Clear();

            AnsiConsole.MarkupLine("[bold yellow]Bem-vindo à Lanchonete![/]");
            if(erro != "") { AnsiConsole.MarkupLine(erro); }
            
            var lanchesEscolhidos = AnsiConsole.Prompt(
                new MultiSelectionPrompt<Lanche>()
                    .Title("Escolha seus [green]lanches[/]\n[italic](Espaço para selecionar, Enter para confirmar)[/]")
                    .PageSize(10)
                    .NotRequired()
                    .AddChoices(this.Cardapio.OfType<Lanche>().ToList())
                    .UseConverter(lanche => $"{lanche.Codigo} - {lanche.Nome} | R$ {lanche.Preco:F2}")
            );

            this.Pedidos.AddRange(lanchesEscolhidos);

            var bebeidasEscolhidas = AnsiConsole.Prompt(
                new MultiSelectionPrompt<Bebida>()
                    .Title("Escolha suas [blue]bebidas[/]\n[italic](Espaço para selecionar, Enter para confirmar)[/]")
                    .PageSize(10)
                    .NotRequired() 
                    .AddChoices(this.Cardapio.OfType<Bebida>().ToList())
                    .UseConverter(bebida => $"{bebida.Codigo} - {bebida.Nome} | R$ {bebida.Preco:F2}")
            );

            this.Pedidos.AddRange(bebeidasEscolhidas);

            if(Pedidos.Count() == 0)
            {
                await Home("[bold red]Nenhum produto foi selecionado![/]");
                return;
            }

            await Carrinho();
        }

        public async Task Carrinho()
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Deseja selecionar ingredientes extras no pedido?[/]");

            foreach (var lanche in Pedidos.OfType<Lanche>())
            {
                Console.Clear();
                var ingredientesEscolhidos = AnsiConsole.Prompt(
                new MultiSelectionPrompt<Ingrediente>()
                    .Title($"Escolha os [bold green]Ingredientes Extras[/] do [yellow]{lanche.Nome}[/]\n[italic](Espaço para selecionar, Enter para confirmar)[/]")
                    .PageSize(10)
                    .NotRequired()
                    .AddChoices(lanche.IngredientesExtras)
                    .UseConverter(ingrediente => $"{ingrediente.Nome} (R$ {ingrediente.Preco:F2})")
                );

                lanche.AdicionarIngredientes(ingredientesEscolhidos);
            }

            await Confirmar();
        }

        public async Task Confirmar(bool confirmado = false)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[bold yellow]Pedido:[/]");

            decimal precoFinal = 0;
            foreach (var item in this.Pedidos)
            {
                if(item is Lanche lanche)
                {
                    precoFinal += lanche.PegarPrecoTotal();
                    AnsiConsole.MarkupLine($"[gold3]{lanche.Nome}[/] R$ {lanche.Preco:F2} | Preço Total: R$ {lanche.PegarPrecoTotal():F2}");
                    foreach(var ingrediente in lanche.PegarIngedientesSelecionados())
                    {
                        AnsiConsole.MarkupLine($"   - {ingrediente.Nome}: {ingrediente.Preco}");
                    }
                }

                if (item is Bebida bebida)
                {
                    precoFinal += bebida.Preco;
                    AnsiConsole.MarkupLine($"[aqua]{bebida.Nome}[/] | Preço Total: R$ {bebida.Preco:F2}");
                }
            }

            Console.WriteLine("\n");

            AnsiConsole.MarkupLine("============== CONTA ================");
            AnsiConsole.MarkupLine($"Preço Final: {precoFinal:F2}");
            AnsiConsole.MarkupLine("=====================================");

            Console.WriteLine("\n");

            if (confirmado)
            {
                var retornar = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold green]Pedido confirmado com sucesso![/]")
                        .AddChoices(new[] { "Retornar" })
                );

                if(retornar != "")
                {
                    await Home();
                }
            }
            else
            {
                var confirmacao = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold green]Deseja confirmar o pedido?[/]")
                        .AddChoices(new[] { "Aceitar", "Refazer", "Sair" })
                );

                if (confirmacao == "Aceitar")
                {
                    await Confirmar(true);
                }
                else if(confirmacao == "Refazer")
                {
                    await Home();
                }
                else if(confirmacao == "Sair")
                {
                    await EncerrarSistema();
                }
            }
        }

        public async Task EncerrarSistema()
        {
            var contador = "";

            for(int i=3; i > 0; i--)
            {
                Console.Clear();
                contador += $"{i}... ";

                AnsiConsole.MarkupLine("[red]Sistema encerrando em...[/]");
                AnsiConsole.MarkupLine($"{contador}");

                Thread.Sleep(1000);
            }

            Environment.Exit(0);
        }
    }
}
