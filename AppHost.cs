using Funq;
using ServiceStack;

namespace ServiceStackExample
{
   public class AppHost: AppHostBase {
       public AppHost(): base("Treinaweb web Services", typeof(ServiceInterface.TodoService).Assembly){}

        public override void Configure(Container container)
        { 
        }
    }
}