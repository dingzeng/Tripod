using System;
using System.Threading;
using System.Threading.Tasks;
using Archive.API.Model;
using Archive.API.ViewModel.Item;
using FluentValidation;
using FluentValidation.Results;

namespace Archive.API.Validator
{
    public class ItemBarcodeValidator : AbstractValidator<ItemBarcode>
    {
        public ItemBarcodeValidator()
        {   
            // Barcode
            RuleFor(x => x.Barcode).NotNull();
            RuleFor(x => x.Barcode).MaximumLength(20);
            RuleFor(x => x.Barcode).Matches("^\\d*$");

            // Memo
            RuleFor(x => x.Memo).MaximumLength(100);
        }
    }
}