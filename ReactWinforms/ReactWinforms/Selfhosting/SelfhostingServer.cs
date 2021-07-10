using System;
using System.Net;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Newtonsoft.Json.Serialization;

namespace ReactWinforms.Selfhosting
{
  public class SelfhostingServer
  {
    public static HttpSelfHostServer Server { get; private set; }

    public static void Run()
    {
      // netsh http add urlacl url=http://+:58000/ user=USERNAME listen=yes
      var uriBuilder = new UriBuilder($"http://{Dns.GetHostName()}") { Port = 58000 };
      var config = new HttpSelfHostConfiguration(uriBuilder.Uri);
      Configure(config);
      Server = new HttpSelfHostServer(config);
      Server.OpenAsync().Wait();
    }

    public static void ShutDown()
    {
      Server.CloseAsync().Wait();
    }

    private static void Configure(HttpSelfHostConfiguration config)
    {
      config.MaxConcurrentRequests = 1;

      var jsonFormatter = config.Formatters.JsonFormatter;
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

      config.Formatters.JsonFormatter.SupportedMediaTypes
        .Add(new MediaTypeHeaderValue("text/html"));

      config.MapHttpAttributeRoutes();
    }
  }
}
