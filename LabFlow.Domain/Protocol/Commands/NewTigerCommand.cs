using LabFlow.Domain.Protocol.Validations;

namespace LabFlow.Domain.Protocol.Commands
{
    public class NewTigerCommand: TigerCommand
    {
        public NewTigerCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new NewTigerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
