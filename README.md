Helios-based OWIN Bootstrapper for scriptcs
======================

Allows you to run scriptcs (csx) OWIN applications on IIS using Helios.
This is an alpha version.

## Convention

By convention your app entry point should be `app.csx` and it should be located at the root of your website, in the `script` folder:

	|-- bin
	|-- script
		|-- app.csx (your app)
		|-- packages.config
		|-- packages
			|-- (packages from nuget)
	|-- web.config

To run locally just clone the repo, restore packages and start. Remember to put some csx script in the `/script/` folder. The source has a Web API sample in there for you already.

## Writing an OWIN app in a CSX

You write an application the same way as you would write any other `scriptcs` script - all the syntax is supported (`#r`, `#load`, `Require<T>()` and so on).

The bootstrapper itself is an OWIN `Startup` class so it will start automatically and load your csx application. 
It also exposes (injects into your script) an `IAppBuilder` object you should use to interact with the OWIN environment.

For example:

        App.Run((ctx) =>
        {
	    	ctx.Response.WriteAsync("hello");
            return Task.FromResult(0);
        });

Of coure you are able to interact with script packs too:

		using ScriptCs.Adder;

		var adder = Require<Adder>();
        App.Run((ctx) =>
        {
	    ctx.Response.WriteAsync(string.Format("The sum of 5 and 6 is {0}", adder.Add(5,6)));
            return Task.FromResult(0);
        });
 
You can also build complex applications using any OWIN-friendly framework such as Nancy or Web API.

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

You can now access your app at:

	GET localhost:{port}/hello
	GET localhost:{port}/add/5,6

in other words - everything is 100% scripted, you never build any DLLs.

## Azure Websites

The whole thing runs on Azure Websites. Just deploy your script + packages.config + packages to the /script folder and the bootstrapper and all its DLLs to /bin.

A demo can be accessed here: [http://scriptcshelios.azurewebsites.net/hello](http://scriptcshelios.azurewebsites.net/hello)

## Next steps

 - create deployment script that will take care of pulling the bootstrapper
 - incorporate automatic package installation (so that you only have to deploy csx + packages.config)
 - lots of other things :-) 