using FluentValidation;
using LabFlow.Domain.Protocol.Commands;
using System;

namespace LabFlow.Domain.Protocol.Validations
{
    public abstract class TigerValidation<T> : AbstractValidator<T> where T : TigerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
