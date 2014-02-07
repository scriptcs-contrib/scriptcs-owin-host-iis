using System.Web.Http;
using ScriptCs.Adder;

static Adder adder {get; set;}
adder = Require<Adder>();

public class TestController : ApiController
{
	[HttpGet]
	[Route("hello")]
	public MessageDto HelloWorld()
	{
		return new MessageDto { 
			Text = "Hello from OWIN, Web API, scriptcs and Helios on Azure Web Sites!!!" 
		};
	}

	[HttpGet]
	[Route("add/{a:int},{b:int}")]
	public MessageDto Add(int a, int b)
	{
		return new MessageDto { 
			Text = "Hello from the Adder script pack. Your result is " + adder.Add(a, b).ToString()
		};
	}
}

public class MessageDto 
{
	public string Text {get; set;}
}

public class ControllerResolver : System.Web.Http.Dispatcher.DefaultHttpControllerTypeResolver
{
    public override ICollection<Type> GetControllerTypes(System.Web.Http.Dispatcher.IAssembliesResolver assembliesResolver)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());
        return types.Where(x => typeof(System.Web.Http.Controllers.IHttpController).IsAssignableFrom(x)).ToList();
    }

}

var config = new HttpConfiguration();
config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
config.Services.Replace(typeof(System.Web.Http.Dispatcher.IHttpControllerTypeResolver), new ControllerResolver());
config.MapHttpAttributeRoutes();

App.UseWebApi(config);