namespace Company.Datalayer.Interfaces.Context
{
    public interface ICompanyDbContext
    {
        Task<Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction> BeginTransactionAsync();

    }
}
