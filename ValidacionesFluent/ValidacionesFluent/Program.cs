using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidacionesFluent
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Beer> listaCervezas = new List<Beer>();
            Beer beer1 = new Beer() {Name="Tremens", Alcohol=8.5m, Brand="Delirium" };
            listaCervezas.Add(beer1);
            Beer beer2 = new Beer() { Name = "Tremens", Alcohol = 8.5m, Brand = "Corona" };
            //agregamos la cerveza creada a la lista
            listaCervezas.Add(beer2);
            
            //realizar la validación

            var validador = new BeerValidador(listaCervezas);
            ValidationResult result = validador.Validate(beer2);
            if (!result.IsValid)
            {
                foreach (var err in result.Errors)
                {
                    Console.WriteLine($"Error en {err.PropertyName} error: {err.ErrorMessage}");
                }
            }
            else
            {
                Console.WriteLine("Aprobo prueba de validación");
            }
        }
    }

    public class BeerValidador : AbstractValidator<Beer>
    {
        // clase que contiene reglas de validación

        List<Beer> _beer = new List<Beer>();

        public BeerValidador(List<Beer> beers)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).WithMessage("Nombre muy largo");
            RuleFor(x => x.Name).NotEmpty().Must(ExisteBeer).WithMessage("La cerveza ya existe");
            RuleFor(x => x.Alcohol).NotNull().LessThan(10).GreaterThan(0).WithMessage("Grado no valido");
            RuleFor(x => x.Brand).NotNull().MaximumLength(30).NotEqual("Corona").WithMessage("Marca no aceptada");

            _beer = beers;
        }

        // metodo para validar exista la cerveza creada en la lista de cervezas
        // devuelve false cuando no existe la cerveza y true cuando existe
        // la idea en no volver a agregar la misma cerveza
        public bool ExisteBeer(string Nombre) => _beer.Any(x=>x.Name==Nombre) ? false:true; 

    }

    public class Beer
    {
        public string Name { get; set; }
        public decimal Alcohol { get; set; }
        public string Brand { get; set; }

    }

}
