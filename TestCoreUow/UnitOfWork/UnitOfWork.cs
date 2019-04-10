using System;
using TestCoreUow.Contracts;
using TestCoreUow.Entities;
using TestCoreUow.Repository;

namespace TestCoreUow.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BPD01_Grant_ManagementContext _context;

        private IGenericRepository<Grants> _grantRepository;
        private IGenericRepository<Comments> _commentRepository;
        private IGenericRepository<Extensions> _extensionrepository;
        private IGenericRepository<Reports> _reportRepository;
        private IGenericRepository<AuditLog> _auditRepository;

        public UnitOfWork(BPD01_Grant_ManagementContext context)
        {
            _context = context;
        }

        public IGenericRepository<Grants> GrantRepository
        {
            get { return _grantRepository ?? (_grantRepository = new GenericRepository<Grants>(_context)); }
        }

        public IGenericRepository<Comments> CommentRepository
        {
            get { return _commentRepository ?? (_commentRepository = new GenericRepository<Comments>(_context)); }
        }

        public IGenericRepository<AuditLog> AuditRepository
        {
            get { return _auditRepository ?? (_auditRepository = new GenericRepository<AuditLog>(_context)); }
        }

        public IGenericRepository<Reports> ReportRepository
        {
            get { return _reportRepository ?? (_reportRepository = new GenericRepository<Reports>(_context)); }
        }

        public IGenericRepository<Extensions> ExtensionRepository
        {
            get { return _extensionrepository ?? (_extensionrepository = new GenericRepository<Extensions>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
