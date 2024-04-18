using System.Transactions;


using Microsoft.EntityFrameworkCore.Storage;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Exceptions;
using WebApi.Domain.Enums;
using WebApi.Infrastructure.Persistence.Repositories;


namespace WebApi.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
        private bool _disposed;
        //
        private readonly CustomerSupportDatabaseContext _context;

        // repositories

        public ICustomerRepository CustomerRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ISalesRepository teleSalesRepository { get; }
     
        //
        public UnitOfWork(CustomerSupportDatabaseContext dbContext)
        {
            _context = dbContext;

           CustomerRepository = new CustomerRepositoty(_context);
           ProductRepository = new ProductRepository(_context);
          teleSalesRepository = new SaleRepository(_context);
        }

        // save changes
        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync(CancellationToken token) => await _context.SaveChangesAsync(token);

        // transaction
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        // commit
        public void Commit()
        {
            if (_transaction == null)
            {
                throw new UserFriendlyException(ErrorCode.Internal, "No transaction to commit");
            }
            try
            {
                _context.SaveChanges();
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task CommitAsync(CancellationToken token)
        {
            if (_transaction == null)
            {
                throw new UserFriendlyException(ErrorCode.Internal, "No transaction to commit");
            }

            try
            {
                await _context.SaveChangesAsync(token);
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        // rollback
        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new UserFriendlyException(ErrorCode.Internal, "No transaction to commit");
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null)
            {
                throw new UserFriendlyException(ErrorCode.Internal, "No transaction to commit");
            }

            await _transaction.RollbackAsync();
            _transaction.Dispose();
            _transaction = null;
        }

        // dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // execute transaction
        public async Task ExecuteTransactionAsync(Action action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new UserFriendlyException(ErrorCode.Internal, "Can't execute transaction: " + ex);
            }
        }

        public async Task ExecuteTransactionAsync(Func<Task> action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new UserFriendlyException(ErrorCode.Internal, "Can't execute transaction: " + ex);
            }
        }
    }
}
