using System;

namespace PrototypeDeep
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal oAnimal = new Animal() {Nombre="Oveja Dolly", Patas = 4 };
            oAnimal.Rasgos = new Detalle();
            oAnimal.Rasgos.Color = "blanca";
            oAnimal.Rasgos.Raza = "Oveja";

            Animal oAnimalClonado = oAnimal.Clone() as Animal;
            oAnimalClonado.Rasgos.Color = "negro";

            Console.WriteLine(oAnimal.Nombre + " " + oAnimal.Rasgos.Color);
            Console.WriteLine(oAnimalClonado.Nombre+" "+oAnimalClonado.Rasgos.Color);
        }
    }
}
