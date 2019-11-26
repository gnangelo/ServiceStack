using ServiceStack;

namespace ServiceStackExample.ServiceModel {
    public class TodoResponse
    {
        public object Result { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}