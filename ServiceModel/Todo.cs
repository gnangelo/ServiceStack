using ServiceStack;
using ServiceStack.DataAnnotations;

namespace ServiceStackExample.ServiceModel {

    [Route("/todo")]
    [Route("/todo/{Id}")]
    public class Todo: IReturn<TodoResponse>
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
    }
}