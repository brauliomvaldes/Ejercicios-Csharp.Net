using System;

namespace PrototypeShadow
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal oAnimal = new Animal() {Nombre="Oveja Dolly", Patas=4 };
            Animal oAnimalClonado = oAnimal.Clone() as Animal;
            oAnimalClonado.Patas = 5;

            Console.WriteLine(oAnimal.Nombre+"(original) "+oAnimal.Patas);
            Console.WriteLine(oAnimalClonado.Nombre+"(clonado) "+oAnimalClonado.Patas);
        }
    }
}
