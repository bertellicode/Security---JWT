namespace Security.Domain.Core.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}
