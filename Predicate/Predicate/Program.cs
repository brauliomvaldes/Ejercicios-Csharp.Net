using System;
using System.Collections.Generic;

namespace Predicate
{
    static class Program
    {

        // un predicado Predicate siempre responde True o False
        static void Main(string[] args)
        {
            var numbers = new List<int>
            {
                1,56,2,3,3,45,6
            };

            //var predicate = new Predicate<int>(IsDivider2);
            // otra forma es usar una expresion lambda si es que no
            // se reutilizara o llamara nuevamente la funcion IsDivider2

            var predicate = new Predicate<int>(x => x % 2 == 0);

            // negar el predicado
            Predicate<int> negacionPredicate = x => !predicate(x);

            // método FinAll de List que emplea un predicado para procesar el
            // contenido
            var numerosPares = numbers.FindAll(predicate);

            var numerosImpares = numbers.FindAll(negacionPredicate);

            // mostrar el contenido de la lista numerosPares utilizando
            // una expresion lambda
            numerosPares.ForEach(d => { Console.WriteLine(d); });

            // muestra numeros impares al negar el predicado de los pares
            numerosImpares.ForEach(d => { Console.WriteLine(d); });


            // otro uso de los predicadps con una clase
            // sirven a para hacer metodos que reciban condicion las que son booleanas

            var beers = new List<Beer>()
            {
                new Beer(){Nombre="cerveza1", Alcohol=5},
                new Beer(){Nombre="cerveza2", Alcohol=7},
                new Beer(){Nombre="cerveza3", Alcohol=8},
                new Beer(){Nombre="cerveza4", Alcohol=11},
            };

            CervezaQueMeMarea(beers, x => x.Alcohol >= 8);
            // si se emplea this en el metodo pasa a ser parte de la clase Beer y se puede invocar 
            // asi se cambia la forma de invocar el metodo como parte de la clase Beer
            beers.CervezaQueMeMarea(x => x.Alcohol >= 8);
        }

        // si agregamos This al orimer parametro que recibe el metodo, este se hace parte de la clase Beer,
        // además, la clase Program debe ser static
        // esto se llama "extensiones"
        static void CervezaQueMeMarea(this List<Beer> beers, Predicate<Beer> condicion)
        {
            var evilBeers = beers.FindAll(condicion);
            evilBeers.ForEach(d => Console.WriteLine(d.Nombre));
        }



        // funcion que utiliza el predicado si se vuelve a utiulizar
        //static bool IsDivider2(int x) => x % 2 == 0;

        public class Beer
        {
            public string Nombre { get; set; }
            public int Alcohol { get; set; }

        }


    }
}
