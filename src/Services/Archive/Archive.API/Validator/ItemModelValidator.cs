using System;
using System.Threading;
using System.Threading.Tasks;
using Archive.API.ViewModel.Item;
using FluentValidation;
using FluentValidation.Results;

namespace Archive.API.Validator
{
    public class ItemModelValidator : AbstractValidator<ItemModel>
    {
        public ItemModelValidator()
        {
            // Id
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Id).MaximumLength(20);
            RuleFor(x => x.Id).Matches("^\\d*$");
            
            // Barcode
            RuleFor(x => x.Barcode).NotNull();
            RuleFor(x => x.Barcode).MaximumLength(20);
            RuleFor(x => x.Barcode).Matches("^/d*$");

            // // Name
            // RuleFor(x => x.Name).NotNull();
            // RuleFor(x => x.Name).MaximumLength(20);

            // // ShortName
            // RuleFor(x => x.ShortName).NotNull();
            // RuleFor(x => x.ShortName).MaximumLength(20);

            // // Category3
            // RuleFor(x => x.Category3.Id).NotNull();
            
            // // Brand
            // RuleFor(x => x.Brand.Id).NotNull();

            // // Department
            // RuleFor(x => x.Department.Id).NotNull();

            // // Supplier
            // RuleFor(x => x.Supplier.Id).NotNull();

            // // UnitName
            // RuleFor(x => x.UnitName).NotNull();
            // RuleFor(x => x.UnitName).MaximumLength(2);

            // // Status
            // RuleFor(x => x.Status).Must(x => x == 0 || x == 9);

            // // TransportMode
            // RuleFor(x => x.TransportMode).IsInEnum();

            // // Barcodes
            // RuleForEach(x => x.Barcodes).SetValidator(new ItemBarcodeValidator());

            // Packages

        }
    }
}