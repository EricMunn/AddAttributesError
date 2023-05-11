using System;
using ServiceStack;
using AddAttributesError.ServiceModel;

namespace AddAttributesError.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}
