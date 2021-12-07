using AspValidation.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspValidation.Validator
{
    public class BeerValidator : AbstractValidator<Beer>
    {
        public BeerValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre no pueder vacio");
            RuleFor(x => x.Nombre).MaximumLength(50).WithMessage("Nombre no puede superar los 50 caracteres");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Nombre Marca no pueder vacio");
            RuleFor(x => x.Brand).MaximumLength(50).WithMessage("Nombre Marca no puede superar los 50 caracteres");

        }
    }
}
