using System;

namespace GUIDProyect
{
    // GUID: Identificador Unico Global, de tamaño 16 bytes
    class Program
    {
        static void Main(string[] args)
        {
            Guid Id = Guid.NewGuid();

            using(var context = new pruebaContext())
            {
                var sale = new Sale();
                sale.Date = DateTime.Now;
                sale.SaleId = Id;

                var saleConcept = new SaleConcept();
                saleConcept.Amount = 100;
                saleConcept.Description = "Terranova 750 cc";
                saleConcept.Saleid = Id;

                context.Sales.Add(sale);
                context.SaleConcepts.Add(saleConcept);

                context.SaveChanges();

            }
        }
    }
}
