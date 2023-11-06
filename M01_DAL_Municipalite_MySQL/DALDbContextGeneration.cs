using M01_DAL_Municipalite_MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace M01_DAL_Municipalite_SQL
{
    public class DALDbContextGeneration
    {
        private static DbContextOptions<MunicipaliteContextSQL> _dbContextOptions;
        private static PooledDbContextFactory<MunicipaliteContextSQL> _polledDbContextFactory;
        static DALDbContextGeneration()
        {
            IConfigurationRoot configuration =
                new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();


            _dbContextOptions = new DbContextOptionsBuilder<MunicipaliteContextSQL>()
                .UseSqlServer(configuration.GetConnectionString("LocationConnection"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                .EnableSensitiveDataLogging()
                .Options;
            _polledDbContextFactory = new PooledDbContextFactory<MunicipaliteContextSQL>(_dbContextOptions);
        }
        public static MunicipaliteContextSQL ObtenirApplicationDBContext()
        {
            return _polledDbContextFactory.CreateDbContext();
        }
    }
}
