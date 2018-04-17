using System.Threading.Tasks;

namespace AspCoreApp.Data
{
    /// <summary>
    /// Unit of work pattern is a single access point to persistence service - most often a database.
    /// It enables features like transactions and rollbacks.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save changes in persistence service.
        /// It should be called after each transaction.
        /// </summary>
        Task SaveChanges();
    }
}
