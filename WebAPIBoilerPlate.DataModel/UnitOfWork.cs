#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using WebAPIBoilerPlate.DataModel.Interfaces;

#endregion Using Namespaces...

namespace WebAPIBoilerPlate.DataModel
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public sealed class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly WebAPIDBEntities _context;
        private GenericRepository<Order> _orderRepository;

        #endregion Private member variables...

        public UnitOfWork()
        {
            _context = new WebAPIDBEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for order repository.
        /// </summary>
        public GenericRepository<Order> OrderRepository => _orderRepository ?? (_orderRepository = new GenericRepository<Order>(_context));

        #endregion Public Repository Creation properties...

        #region Public member methods...

        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();

                foreach (var entityValidationResult in e.EntityValidationErrors)
                {
                    outputLines.Add($"{DateTime.Now}: Entity of type \"{entityValidationResult.Entry.Entity.GetType().Name}\" in state \"{entityValidationResult.Entry.State}\" has the following validation errors:");
                    outputLines.AddRange(entityValidationResult.ValidationErrors.Select(validationError => $"- Property: \"{validationError.PropertyName}\", Error: \"{validationError.ErrorMessage}\""));
                }

                File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw;
            }
        }

        #endregion Public member methods...

        #region Implementing IDisposable...

        #region private dispose variable declaration...

        private bool _disposed;

        #endregion private dispose variable declaration...

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Implementing IDisposable...
    }
}