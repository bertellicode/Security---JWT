using Security.Domain.Core.Interfaces;
using Security.Infra.Data.Context;

namespace Security.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SecurityContext _context;

        public UnitOfWork(SecurityContext context)
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
