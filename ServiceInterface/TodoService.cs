using Microsoft.Extensions.Configuration;
using ServiceStack;
using ServiceStackExample.Repositories;
using ServiceStackExample.ServiceModel;

namespace ServiceStackExample.ServiceInterface {
    public class TodoService: Service
    {
        private readonly TodoRepository todoRepository;

        public TodoService(IConfiguration configuration){
            todoRepository = new TodoRepository(configuration);
        }

        public object Get(Todo todo)
        {

            if(todo.Id != default(int))
                return todoRepository.FindByID(todo.Id);

            return todoRepository.FindAll();
        }

        public Todo Post(Todo todo){
            todoRepository.Add(todo);

            return todo;
        }

        public Todo Put(Todo todo){
            todoRepository.Update(todo);

            return todo;
        }

        public Todo Delete(Todo todo){
            todoRepository.Remove(todo.Id);

            return todo;
        }
    }
}