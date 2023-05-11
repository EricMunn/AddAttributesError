using Funq;
using ServiceStack;
using AddAttributesError.ServiceInterface;
using AddAttributesError.ServiceModel;
using System.Runtime.Serialization;

[assembly: HostingStartup(typeof(AddAttributesError.AppHost))]

namespace AddAttributesError;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("AddAttributesError", typeof(MyServices).Assembly) {}

    public override void Configure(Container container)
    {
        typeof(Hello)
            .GetProperty("Name")
            .AddAttributes(
                new ApiMemberAttribute
                {
                    ParameterType = "path",
                    Name = "MetaName",
                    DataType = "foo",
                    Description = "The name of the person to say hello to.",
                    IsRequired = true,
                },
                new DataMemberAttribute());

        // enable server-side rendering, see: https://sharpscript.net/docs/sharp-pages
        Plugins.Add(new SharpPagesFeature {
            EnableSpaFallback = true
        }); 

        SetConfig(new HostConfig
        {
            AddRedirectParamsToQueryString = true,
        });
    }
}
