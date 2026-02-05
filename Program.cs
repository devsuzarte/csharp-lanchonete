using Lanchonete;

List<Item> Cardapio = new List<Item>
{
    // LANCHES
    new Lanche("L1", "Pastel de Forno (Frango)", 4m, new List<Ingrediente>
    {
        new Ingrediente("Catupiry", 1.5m),
        new Ingrediente("Frango", 2.5m),
        new Ingrediente("Ketchup", 0.5m),
        new Ingrediente("Maionese", 0.5m),
        new Ingrediente("Mostarda", 0.5m),
    }),

    new Lanche("L2", "Hambúrguer Clássico", 10m, new List<Ingrediente>
    {
        new Ingrediente("Carne", 4m),
        new Ingrediente("Queijo", 2m),
        new Ingrediente("Alface", 0.5m),
        new Ingrediente("Tomate", 0.5m),
        new Ingrediente("Molho Especial", 1m)
    }),

    new Lanche("L3", "X-Salada", 12m, new List<Ingrediente>
    {
        new Ingrediente("Carne", 4m),
        new Ingrediente("Queijo", 2m),
        new Ingrediente("Alface", 0.5m),
        new Ingrediente("Tomate", 0.5m),
        new Ingrediente("Maionese", 0.5m)
    }),

    new Lanche("L4", "X-Bacon", 14m, new List<Ingrediente>
    {
        new Ingrediente("Carne", 4m),
        new Ingrediente("Queijo", 2m),
        new Ingrediente("Bacon", 2m),
        new Ingrediente("Alface", 0.5m),
        new Ingrediente("Molho Especial", 1m)
    }),

    new Lanche("L5", "Frango Empanado", 11m, new List<Ingrediente>
    {
        new Ingrediente("Frango", 4m),
        new Ingrediente("Queijo", 1.5m),
        new Ingrediente("Molho Picante", 0.5m),
        new Ingrediente("Alface", 0.5m)
    }),

    // BEBIDAS
    new Bebida("B1", "Refrigerante Cola", 5m),
    new Bebida("B2", "Suco de Laranja", 6m),
    new Bebida("B3", "Água Mineral", 3m),
    new Bebida("B4", "Chá Gelado", 4m),
    new Bebida("B5", "Refrigerante Guaraná", 5m)
};
Sistema Sys = new Sistema(Cardapio);

while(true)
{
    await Sys.Home();
}