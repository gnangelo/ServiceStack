using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ServiceStack.OrmLite;

namespace ServiceStackExample.Repositories
{
    public abstract class AbstractRepository<T>
    {
        private string _connectionString;
        private OrmLiteConnectionFactory _dbFactory;
        protected OrmLiteConnectionFactory DbFactory => _dbFactory;
        public AbstractRepository(IConfiguration configuration){
            _connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");

            _dbFactory = new OrmLiteConnectionFactory(_connectionString, SqliteDialect.Provider);
        }
        public abstract void Add(T item);
        public abstract void Remove(int id);
        public abstract void Update(T item);
        public abstract T FindByID(int id);
        public abstract IEnumerable<T> FindAll();
    }
}
