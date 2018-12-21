using LabFlow.Domain.Interfaces;
using LabFlow.Infra.Data.Context;

namespace LabFlow.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LabFlowContext _context;

        public UnitOfWork(LabFlowContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
