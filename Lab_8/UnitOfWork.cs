using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class UnitOfWork : IDisposable
    {
        public CodeFirst context = new CodeFirst();

        public QuerysToSql querys;

        public QuerysToSql Sql
        {
            get
            {
                if (querys == null)
                    querys = new QuerysToSql(context);
                return querys;
            }

        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
