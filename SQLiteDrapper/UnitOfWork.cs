using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAModel.Core;
using DAModel.Core.Repositories;
using SQLiteDapper.Repositories;

namespace SQLiteDapper
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Profiles = new ProfileRepository();
        }
        public UnitOfWork(string connectionString)
        {
            Profiles = new ProfileRepository(connectionString);
        }
        

        public  IProfileRepository Profiles
        { get; private set; }

        public int Complete()
        {
            throw new NotImplementedException();
        }
        //public static string GetConnectionString(string id = "sqliteDapper")
        //{
        //    return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        //}
    }
}
