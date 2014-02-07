using Owin;
using ScriptCs.Contracts;

namespace ScriptCs.Owin.Host.IIS
{
    public class OwinScriptHost : ScriptHost
    {
        public OwinScriptHost(IScriptPackManager scriptPackManager, ScriptEnvironment environment) : base(scriptPackManager, environment)
        {
        }

        public static IAppBuilder App { get; internal set; }
    }
}