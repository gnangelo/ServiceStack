using ServiceStack;

namespace ServiceStackExample.ServiceModel {
    public class CategoryResponse
    {
        public string Result { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}