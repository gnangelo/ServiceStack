using ServiceStack;
using ServiceStackExample.ServiceModel;

namespace ServiceStackExample.ServiceInterface {
    public class CategoryService: Service
    {
        public object Any(Category  request){
            return new CategoryResponse { Result = $"Categoria: {request.Name}" };
        }
    }
}