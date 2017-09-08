namespace WebAPIBoilerPlate.DataModel.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Get/Set Property for order repository.
        /// </summary>
        GenericRepository<Order> OrderRepository { get; }

        /// <summary>
        /// Save method.
        /// </summary>
        void Save();

        /// <summary>
        /// Dispose method
        /// </summary>
        void Dispose();
    }
}