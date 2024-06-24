using CacheNQueue.Application.Features.OrderMed.Add;
using CacheNQueue.Application.Med.ProductMed.Add;
using CacheNQueue.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheNQueue.Application.Validation
{
    public class Validations : AbstractValidator<ProductAddCommandReques>
    {
        public Validations()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name Boş Geçilemez")
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(15)
                .MinimumLength(3)
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");
            RuleFor(x=>x.Description)
                .NotEmpty()
                .WithMessage("Description Boş Geçilemez")
                .NotNull()
                .WithMessage("Boş geçilemez")
                .MaximumLength(15)
                .MinimumLength(3)
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");
            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("3-15 değer aralığında isimlendirme kullanınız");

        }
    } 
    
}
