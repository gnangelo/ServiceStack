using Microsoft.Extensions.Configuration;
using ServiceStackExample.ServiceModel;
using ServiceStack.OrmLite;
using System.Collections.Generic;

namespace ServiceStackExample.Repositories
{
    public class TodoRepository: AbstractRepository<Todo>
    {
        public TodoRepository(IConfiguration configuration): base(configuration) { }

        public override void Add(Todo item)
        {
            using (var db = DbFactory.Open())
            {
                db.CreateTableIfNotExists<Todo>();

                db.Insert(item);
            }
        }
        public override void Remove(int id)
        {
            using (var db = DbFactory.Open())
            {
                db.Delete<Todo>(p => p.Id == id);
            }
        }
        public override void Update(Todo item)
        {
            using (var db = DbFactory.Open())
            {
                db.Update(item);
            }
        }
        public override Todo FindByID(int id)
        { 
            using (var db = DbFactory.Open())
            {
                return db.SingleById<Todo>(id);
            }
        }
        public override IEnumerable<Todo> FindAll()
        {
            using (var db = DbFactory.Open())
            { 
                if (db.CreateTableIfNotExists<Todo>())
                {
                    return db.Select<Todo>();
                }

                return db.Select<Todo>();
            }
        }
    }
}
