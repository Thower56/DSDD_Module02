using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_Municipalite_MySQL
{
    public class MunicipaliteContextSQL : DbContext
    {
        private IDbContextTransaction? m_transaction;
        public DbSet<MunicipaliteDTO>? MUNICIPALITES {get; set;}

        public MunicipaliteContextSQL(DbContextOptions<MunicipaliteContextSQL> options) : base(options)
        {

        }

        public void BeginTransaction() 
        {
            if (this.m_transaction is not null)
            {
                throw new InvalidOperationException("Une transaction est deja debutee");
            }
        }
        public void Commit()
        {
            if (this.m_transaction is null)
            {
                throw new InvalidOperationException("Une transaction doit être débutée");
            }
            this.m_transaction.Commit();
            this.m_transaction?.Dispose();
            this.m_transaction = null;
        }

        public void Rollback()
        {
            if (this.m_transaction is null)
            {
                throw new InvalidOperationException("Une transaction doit être débutée");
            }
            this.m_transaction.Rollback();
            this.m_transaction?.Dispose();
            this.m_transaction = null;
        }

        public override void Dispose()
        {
            this.m_transaction?.Dispose();
            this.m_transaction = null;
            base.Dispose();
        }
    }
}
