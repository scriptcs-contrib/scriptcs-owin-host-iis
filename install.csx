var destPath = Environment.CurrentDirectory;
var srcPath = Environment.CurrentDirectory + "\\..\\";

Directory.CreateDirectory("amd64");
Directory.CreateDirectory("x86");

File.Copy(srcPath + @"packages\Autofac.3.1.5\lib\net40\Autofac.dll", destPath + @"\" + "Autofac.dll", true);
File.Copy(srcPath + @"packages\Autofac.Mef.3.0.2\lib\net40\Autofac.Integration.Mef.dll", destPath + @"\" + "Autofac.Integration.Mef.dll", true);
File.Copy(srcPath + @"packages\Common.Logging.2.1.2\lib\net40\Common.Logging.dll", destPath + @"\" + "Common.Logging.dll", true);
File.Copy(srcPath + @"packages\Common.Logging.Log4Net.2.0.1\lib\net20\Common.Logging.Log4Net.dll", destPath + @"\" + "Common.Logging.Log4Net.dll", true);
File.Copy(srcPath + @"packages\log4net.1.2.10\lib\2.0\log4net.dll", destPath + @"\" + "log4net.dll", true);
File.Copy(srcPath + @"packages\Microsoft.AspNet.Loader.IIS.0.1.5-pre\lib\net45\AspNet.Loader.dll", destPath + @"\" + "AspNet.Loader.dll", true);
File.Copy(srcPath + @"packages\Microsoft.AspNet.Loader.IIS.0.1.5-pre\lib\net45\Microsoft.AspNet.Loader.IIS.dll", destPath + @"\" + "Microsoft.AspNet.Loader.IIS.dll", true);
File.Copy(srcPath + @"packages\Microsoft.AspNet.Loader.IIS.0.1.5-pre\InteropAssemblies\amd64\Microsoft.AspNet.Loader.IIS.Interop.dll", destPath + @"\amd64\" + "Microsoft.AspNet.Loader.IIS.Interop.dll", true);
File.Copy(srcPath + @"packages\Microsoft.AspNet.Loader.IIS.0.1.5-pre\InteropAssemblies\x86\Microsoft.AspNet.Loader.IIS.Interop.dll", destPath + @"\x86\" + "Microsoft.AspNet.Loader.IIS.Interop.dll", true);
File.Copy(srcPath + @"packages\Microsoft.Owin.2.1.0\lib\net45\Microsoft.Owin.dll", destPath + @"\" + "Microsoft.Owin.dll", true);
File.Copy(srcPath + @"packages\Microsoft.Owin.Host.IIS.0.1.5-pre\lib\net45\Microsoft.Owin.Host.IIS.dll", destPath + @"\" + "Microsoft.Owin.Host.IIS.dll", true);
File.Copy(srcPath + @"packages\Microsoft.Owin.Host.IIS.0.1.5-pre\lib\net45\Microsoft.Owin.Host.IIS.Security.dll", destPath + @"\" + "Microsoft.Owin.Host.IIS.Security.dll", true);
File.Copy(srcPath + @"packages\Microsoft.Owin.Hosting.2.1.0\lib\net45\Microsoft.Owin.Hosting.dll", destPath + @"\" + "Microsoft.Owin.Hosting.dll", true);
File.Copy(srcPath + @"packages\Microsoft.Web.Xdt.1.0.0\lib\net40\Microsoft.Web.XmlTransform.dll", destPath + @"\" + "Microsoft.Web.XmlTransform.dll", true);
File.Copy(srcPath + @"packages\Newtonsoft.Json.5.0.8\lib\net45\Newtonsoft.Json.dll", destPath + @"\" + "Newtonsoft.Json.dll", true);
File.Copy(srcPath + @"packages\Nuget.Core.2.7.2\lib\net40-Client\NuGet.Core.dll", destPath + @"\" + "NuGet.Core.dll", true);
File.Copy(srcPath + @"packages\Owin.1.0\lib\net40\Owin.dll", destPath + @"\" + "Owin.dll", true);
File.Copy(srcPath + @"packages\Roslyn.Compilers.Common.1.2.20906.2\lib\net45\Roslyn.Compilers.dll", destPath + @"\" + "Roslyn.Compilers.dll", true);
File.Copy(srcPath + @"packages\Roslyn.Compilers.CSharp.1.2.20906.2\lib\net45\Roslyn.Compilers.CSharp.dll", destPath + @"\" + "Roslyn.Compilers.CSharp.dll", true);
File.Copy(srcPath + @"packages\ScriptCs.Contracts.0.9.0\lib\net45\ScriptCs.Contracts.dll", destPath + @"\" + "ScriptCs.Contracts.dll", true);
File.Copy(srcPath + @"packages\ScriptCs.Core.0.9.0\lib\net45\ScriptCs.Core.dll", destPath + @"\" + "ScriptCs.Core.dll", true);
File.Copy(srcPath + @"packages\ScriptCs.Engine.Roslyn.0.9.0\lib\net45\ScriptCs.Engine.Roslyn.dll", destPath + @"\" + "ScriptCs.Engine.Roslyn.dll", true);
File.Copy(srcPath + @"packages\ScriptCs.Hosting.0.9.0\lib\net45\ScriptCs.Hosting.dll", destPath + @"\" + "ScriptCs.Hosting.dll", true);
File.Copy(srcPath + @"packages\ScriptCs.Owin.Host.IIS.0.1.0-alpha\lib\net451\ScriptCs.Owin.Host.IIS.dll", destPath + @"\" + "ScriptCs.Owin.Host.IIS.dll", true);

Console.WriteLine("Done");