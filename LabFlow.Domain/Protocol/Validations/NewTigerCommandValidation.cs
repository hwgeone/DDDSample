using LabFlow.Domain.Protocol.Commands;

namespace LabFlow.Domain.Protocol.Validations
{
    public class NewTigerCommandValidation : TigerValidation<NewTigerCommand>
    {
        public NewTigerCommandValidation()
        {
            ValidateName();
        }
    }
}
