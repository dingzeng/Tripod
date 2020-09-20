using System;
using System.Threading;
using System.Threading.Tasks;
using Archive.API.Model;
using Archive.API.ViewModel.Item;
using FluentValidation;
using FluentValidation.Results;

namespace Archive.API.Validator
{
    public class ItemPackageValidator : AbstractValidator<ItemPackage>
    {
        public ItemPackageValidator()
        {   
            // Barcode
            RuleFor(x => x.Barcode).NotNull();
            RuleFor(x => x.Barcode).MaximumLength(20);
            RuleFor(x => x.Barcode).Matches("^\\d*$");

            // UnitName
            RuleFor(x => x.UnitName).NotNull();
            RuleFor(x => x.UnitName).MaximumLength(2);

            // FactorQty
            RuleFor(x => x.FactorQty).GreaterThan(0);

            // Memo
            RuleFor(x => x.Memo).MaximumLength(100);
        }
    }
}