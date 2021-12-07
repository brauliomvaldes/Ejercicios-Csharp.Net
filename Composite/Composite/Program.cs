using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Ingrediente oIngrediente1 = new Ingrediente("Harina",800,400,"gramos");
            Ingrediente oIngrediente2 = new Ingrediente("Huevo", 140, 5, "unidad");
            Ingrediente oIngrediente3 = new Ingrediente("Leche", 1000, 1, "litro");

            PastelComposite oPastel = new PastelComposite("Pastel de leche");
            oPastel.Add(oIngrediente1);
            oPastel.Add(oIngrediente2);
            oPastel.Add(oIngrediente3);

            Console.WriteLine("El Producto:"+oPastel.Nombre+", tiene un costo de $"+oPastel.Costo);

            Ingrediente oIngrediente4 = new Ingrediente("Chocolate", 1500, 1, "litro");

            PastelComposite oPastelChocolateYLeche = new PastelComposite("Pastel compuesto");
            oPastelChocolateYLeche.Add(oPastel);
            oPastelChocolateYLeche.Add(oIngrediente4);

            Console.WriteLine("El Producto:" + oPastelChocolateYLeche.Nombre + ", tiene un costo de $" + oPastelChocolateYLeche.Costo);


        }
    }
}
