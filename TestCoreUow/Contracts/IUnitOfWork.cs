using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreUow.Entities;

namespace TestCoreUow.Contracts
{
    public interface IUnitOfWork
    {
        IGenericRepository<Grants> GrantRepository { get; }
        IGenericRepository<Reports> ReportRepository { get; }
        IGenericRepository<Extensions> ExtensionRepository { get; }
        IGenericRepository<Comments> CommentRepository { get; }
        IGenericRepository<AuditLog> AuditRepository { get; }
        void Save();
    }
}
