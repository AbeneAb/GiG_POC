using FluentValidation;
using Odds.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Odds.Application.Features.Selection.Command
{
    public class CreateSelectionCommandValidator : AbstractValidator<CreateSelectionCommand>
    {
        private readonly IMarketRepository _marketRepository;
        private readonly ISelectionRepository _selectionRepository;
        public CreateSelectionCommandValidator(IMarketRepository marketRepository,ISelectionRepository selectionRepository)
        {
            _marketRepository = marketRepository;
            _selectionRepository = selectionRepository;
            RuleFor(p => p.MarketGuid).NotEmpty().
                MustAsync(async (entity, value, c) => await CheckMarketId(entity)).WithMessage("{UserName} is required.");

            RuleFor(p => p.Label).NotNull().WithMessage("{Participant Label } is required").
                MaximumLength(200).WithMessage("{Label} must not exceed 200 characters.");


            RuleFor(p => p.Index).GreaterThan(0).WithMessage("{Index} is required.");
            RuleFor(p => p.Status).GreaterThan(0).WithMessage("{Status} is required").
                LessThan(5).WithMessage("{Status} is between 1 and 5");
            RuleFor(p => p.Odds).NotEmpty().WithMessage("{Odds} is required.").
                GreaterThan(0).WithMessage("{Odds} should be greater than zero.").MustAsync(async(entity,odds,c) => await IsOddUnique(entity)).WithMessage("Duplicate Odd for market");
        }

        private async Task<bool> IsOddUnique(CreateSelectionCommand marketId)
        {
            var selection = await _selectionRepository.GetSelectionByMarketAndId(marketId.MarketGuid, marketId.Odds);
            if(selection == null || selection.Count() ==0) 
            {
                return true;
            }
            return false;

        }

    

        private async Task<bool> CheckMarketId(CreateSelectionCommand createSelectionCommand) 
        {
            var data = await _marketRepository.GetByIdAsync(createSelectionCommand.MarketGuid);
            if (data == null)
                return false;
            return true;
        }

    }
}
