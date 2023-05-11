using ServiceStack;

namespace AddAttributesError.ServiceModel
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string? Name { get; set; }
    }

    public class HelloResponse
    {
        [ApiMember(Description ="What you said to the person", Name = "MyResponse")]
        public string? Result { get; set; }
    }
}
