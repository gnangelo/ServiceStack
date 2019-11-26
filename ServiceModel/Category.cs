using ServiceStack;

namespace ServiceStackExample.ServiceModel {

    [Route("/categories")]
    [Route("/categories/{Name}")]
    public class Category: IReturn<CategoryResponse>
    {
        public string Name { get; set;}
    }
}