using ScriptCs.Contracts;

namespace ScriptCs.Owin.Host.IIS
{
    public class OwinScriptHostFactory : IScriptHostFactory
    {
        public IScriptHost CreateScriptHost(IScriptPackManager scriptPackManager, string[] scriptArgs)
        {
            return new OwinScriptHost(scriptPackManager, new ScriptEnvironment(scriptArgs));
        }
    }
}