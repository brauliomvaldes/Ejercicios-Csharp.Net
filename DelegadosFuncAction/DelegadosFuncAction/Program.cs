using System;

namespace DelegadosFuncAction
{
    class Program
    {
        // delegado es un tipo de almacena la firma que tendra la funcion
        // que quiera utilizar el delegado
        // como debe ser, qué parámetros recibe y si es que regresa un dato
        // esta no devuelve nada pero recibe un string
        // public delegate void Mostrar(string cadena);
        // public delegate string Mostrar(string cadena);

        // para evitar el caso de tener que volver a definir mas delegados
        // con distintos retornos y parametros
        // existe FUNC Y ACTION
        // Func ahorra tener que crear muchos delegados
        // Action funciona igual que Func pero no devuelve nada, es void, todos sus parametros son de entrada

        static void Main(string[] args)
        {
            // Func recibe hasta 16 parámetros
            Func<string, string> mostrar = Show;
            Action<string, int> mostrador = ShowMe;
            // Mostrar mostrar = Show;
            HacerAlgo(mostrar);
            HacerAlgoAction(mostrador);
        }

        // este metodo recibe una función tipo delegado que cumple con la firma o
        // contrato definido por el delegado
        //static public void HacerAlgo(Mostrar funcionalFinal)
        static public void HacerAlgo(Func<string, string> funcionFinal)
        {
            Console.WriteLine("Hago algo");
            // funcionalFinal("se envio desde otra funcion (HacerAlgo)"); 
            Console.WriteLine(funcionFinal("se envio desde otra funcion (HacerAlgo)"));
        }

        static public void HacerAlgoAction(Action<string, int> funcionFinal)
        {
            Console.WriteLine("Hago algo desde un Action");
            // funcionalFinal("se envio desde otra funcion (HacerAlgo)"); 
            funcionFinal("se envio desde otra funcion (HacerAlgo Action)",2);
        }


        static public void HacerAlgo(Action<string, string> funcionFinal)
        {
            Console.WriteLine("Hago algo");
            // funcionalFinal("se envio desde otra funcion (HacerAlgo)"); 
            funcionFinal("se envio desde otra funcion (HacerAlgo) "," el otro texto");
        }


        //static public void Show(string cadena)
        static public void ShowMe(string cadena, int numero)
        {
            Console.WriteLine(cadena+" "+numero);
        }

        static public string Show(string cadena)
        {
            return cadena.ToUpper();
        }

    }
}
