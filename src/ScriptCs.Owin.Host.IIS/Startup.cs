using System;
using System.IO;
using Common.Logging;
using Owin;

namespace ScriptCs.Owin.Host.IIS
{
    public class Startup
    {
        public static string ScriptFullPath
        {
            get { return Path.Combine(HackedFileSystem.GetCurrentDirectory(), ScriptName); }
        }

        public static string ScriptName
        {
            get { return "app.csx"; }
        }

        public void Configuration(IAppBuilder app)
        {
            try
            {
                OwinScriptHost.App = app;

                var services =
                    new ScriptServicesBuilder(new ScriptConsole(), LogManager.GetCurrentClassLogger()).
                        Repl(false)
                        .ScriptHostFactory<OwinScriptHostFactory>()
                        .FileSystem<HackedFileSystem>()
                        .ScriptName(ScriptFullPath).Build();

                var packs = services.ScriptPackResolver.GetPacks();
                var assemblyPaths = services.AssemblyResolver.GetAssemblyPaths(services.FileSystem.CurrentDirectory);

                services.Executor.Initialize(assemblyPaths, packs);
                services.Executor.ImportNamespaces("Owin");

                var result = services.Executor.Execute(ScriptFullPath);

                if (result.CompileExceptionInfo != null)
                    throw result.CompileExceptionInfo.SourceException;

                if (result.ExecuteExceptionInfo != null)
                    throw result.ExecuteExceptionInfo.SourceException;
            }
            catch (Exception e)
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync(e.Message);
                    await context.Response.WriteAsync(Environment.NewLine);
                    await context.Response.WriteAsync(e.StackTrace);
                });
            }
        }
    }
}