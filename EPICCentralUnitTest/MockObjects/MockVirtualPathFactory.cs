using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Razor;
using System.Web.Razor;
using System.Web.Razor.Generator;
using System.Web.WebPages;
using EPICCentral;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Language;
using Moq.Protected;
using Binder = Microsoft.CSharp.RuntimeBinder.Binder;

namespace EPICCentralUnitTest.MockObjects
{
    public class MockVirtualPathFactory : IVirtualPathFactory
    {
        private static Dictionary<string, Type> _rendered = new Dictionary<string, Type>();

        private static Dictionary<AssemblyName, Assembly> _assemblies;

        public static Dictionary<AssemblyName, Assembly> Assemblies
        {
            get
            {
                if (_assemblies == null)
                {
                    var current = Assembly.GetExecutingAssembly();
                    _assemblies = new[]
                                      {
                                          current.GetName(),
                                          typeof (Binder).Assembly.GetName()
                                      }
                        .Concat(
                            current.GetReferencedAssemblies()
                                .Concat(Assembly.GetAssembly(typeof (Global)).GetReferencedAssemblies())
                        )
                        .DistinctBy(x => x.Name)
                        .Except(AppDomain.CurrentDomain.GetAssemblies().Select(x => x.GetName()))
                        .Select(name => new KeyValuePair<AssemblyName, Assembly>(name, AppDomain.CurrentDomain.Load(name)))
                        .ToDictionary(pair => pair.Key, pair => pair.Value);
                }
                return _assemblies;
            }
        }

        public static CompilerParameters GetCompilerParameters()
        {
            var parameters = new CompilerParameters
            {
                GenerateInMemory = false,
                TempFiles = new TempFileCollection(Environment.GetEnvironmentVariable("TEMP"), true),
                GenerateExecutable = false,
                IncludeDebugInformation = true
            };
            foreach (var assembly in Assemblies)
                try
                {
                    parameters.ReferencedAssemblies.Add(assembly.Value.Location);
                }
                catch
                {

                }

            return parameters;
        }

        public static bool ViewPathContains(string innerPath)
        {
            var currentPath = innerPath;
            while (currentPath != null &&
                   !Path.GetFullPath(currentPath).Trim('\\').Equals(Path.GetPathRoot(currentPath),
                                                                   StringComparison.InvariantCultureIgnoreCase))
            {
                if (Path.GetFullPath(currentPath).Trim('\\').Equals(BaseDirectory.Trim('\\'),
                                                                    StringComparison.InvariantCultureIgnoreCase))
                    return true;
                currentPath = Path.GetDirectoryName(currentPath);
            }
            return false;
        }

        public bool Exists(string virtualPath)
        {
            return InternalExists(virtualPath);
        }

        internal static bool InternalExists(string virtualPath)
        {
            return File.Exists(NormalizePath(virtualPath));
        }

        internal static string NormalizePath(string virtualPath)
        {
            return virtualPath.Replace("~/", BaseDirectory + "\\EPICCentral\\");
        }

        public static string baseDirectory;

        public static string BaseDirectory
        {
            get
            {
                if (baseDirectory == null)
                {
                    baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    baseDirectory = baseDirectory.Remove(baseDirectory.IndexOf("EPICCentralUnitTest"));
                }
                return baseDirectory;
            }
        }

        public object CreateInstance(string virtualPath)
        {
            return InternalCreateInstance(NormalizePath(virtualPath));
        }

        internal static string GetTypeName(string path)
        {
            // get a couple directory names
            var dir1 = Path.GetDirectoryName(path);
            var dir2 = Path.GetDirectoryName(dir1);
            var dir3 = Path.GetDirectoryName(dir2);
            return Path.GetFileName(dir3) + "_" + Path.GetFileName(dir2) + "_" + Path.GetFileName(dir1) + "_" + Path.GetFileNameWithoutExtension(path);
        }

        internal static object InternalCreateInstance(string path)
        {
            var typeName = GetTypeName(path);

            if (_rendered.ContainsKey(typeName))
            {
                var templateType = _rendered[typeName];
                return CreateTemplateMock(templateType);
            }

            // get parameters here because this will load the assemblies
            var parameters = GetCompilerParameters();

            // open the path for reading
            using (var file = File.OpenRead(path))
            {
                var reader = (TextReader)new StreamReader(file);
                var baseClass = typeName
                                    .IndexOf("_ViewStart", StringComparison.InvariantCultureIgnoreCase) > -1
                                    ? typeof (ViewStartPage).FullName
                                    : typeof (WebViewPage).FullName;

                var language = new Mock<CSharpRazorCodeLanguage>();
                language.Setup(x => x.CreateCodeParser()).Returns(new MvcCSharpRazorCodeParser());
                language.Setup(
                    x =>
                    x.CreateCodeGenerator(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                                          It.IsAny<RazorEngineHost>()))
                    .Returns<string, string, string, RazorEngineHost>(
                        (s, s1, arg3, arg4) => new MvcCSharpRazorCodeGenerator(s,
                                                                               s1,
                                                                               arg3,
                                                                               arg4));

                var host = new RazorEngineHost(language.Object)
                {
                    DefaultBaseClass = baseClass,
                    DefaultNamespace = "EPICCentral.Views",
                    DefaultClassName = typeName,
                    GeneratedClassContext = new GeneratedClassContext(
                        "Execute",
                        "Write",
                        "WriteLiteral",
                        "WriteTo",
                        "WriteLiteralTo",
                        typeof(HelperResult).FullName,
                        "DefineSection")
                };

                // this should match web.config <namespaces>
                host.NamespaceImports.Add("System");
                host.NamespaceImports.Add("System.Collections.Generic");
                host.NamespaceImports.Add("System.IO");
                host.NamespaceImports.Add("System.Linq");
                host.NamespaceImports.Add("System.Web.Mvc");
                host.NamespaceImports.Add("System.Web.Mvc.Ajax");
                host.NamespaceImports.Add("System.Web.Mvc.Html");
                host.NamespaceImports.Add("System.Net");
                host.NamespaceImports.Add("System.Web");
                host.NamespaceImports.Add("System.Web.Helpers");
                host.NamespaceImports.Add("System.Web.Routing");
                host.NamespaceImports.Add("System.Web.Security");
                host.NamespaceImports.Add("System.Web.UI");
                host.NamespaceImports.Add("EPICCentralUnitTest");

                var engine = new RazorTemplateEngine(host);
                var result = engine.GenerateCode(reader);

                var provider = new CSharpCodeProvider();
                var codeWriter = new StringWriter();
                provider.GenerateCodeFromCompileUnit(result.GeneratedCode, codeWriter,
                                                     new CodeGeneratorOptions());
                var code = codeWriter.ToString();
                var compiledResults = provider.CompileAssemblyFromDom(parameters, result.GeneratedCode);
                if (compiledResults.Errors.Count > 0)
                {
                    Assert.Fail(compiledResults.Errors[0].ErrorText);
                    return null;
                }
                else
                {
                    var templateType = compiledResults.CompiledAssembly.GetType(host.DefaultNamespace + '.' + host.DefaultClassName);
                    _rendered[typeName] = templateType;
                    return CreateTemplateMock(templateType);
                }
            }
        }

        internal static object CreateTemplateMock(Type templateType)
        {
            try
            {
                var createMethod = MockExtensions.Repository.GetType().GetMethod("Create",
                                                                                 BindingFlags.FlattenHierarchy |
                                                                                 BindingFlags.Instance |
                                                                                 BindingFlags.Public, null,
                                                                                 new Type[] { typeof(MockBehavior) },
                                                                                 null);
                var mockTemplate = createMethod.MakeGenericMethod(templateType).Invoke(MockExtensions.Repository,
                                                                                       new object[] { MockBehavior.Default });
                // setup the Normalize override because VirtualPath.Normalize() doesn't do anything right
                var setupNormalizeCall = mockTemplate.GetType().GetMethods().First(
                    x => x.Name == "Setup" && x.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(typeof(string));

                // set up Normalize()
                var unGenericMethod = (Expression<Func<WebPageExecutingBase, string>>)
                                      (@base => @base.NormalizePath(It.IsAny<string>()));
                var normalizeParam = Expression.Parameter(templateType);
                var normalizeExpression = Expression.Lambda(Expression.Call(normalizeParam, templateType.GetMethod("NormalizePath"), ItExpr.IsAny<string>()), normalizeParam);
                var setupNormalize = (ICallback) setupNormalizeCall.Invoke(
                    mockTemplate,
                    new object[]
                        {
                            normalizeExpression
                        });

                // set up return value for the normalize call
                var returnsCallNormalize = setupNormalize.GetType().GetMethods().First(
                    x => x.Name == "Returns" && x.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(new[] { typeof(string) });
                returnsCallNormalize.Invoke(setupNormalize,
                                         new[]
                                             {
                                                 (Func<string, string>)
                                                 (NormalizePath)
                                             });


                // get protected methods for mocking
                var mockProtected = typeof(ProtectedExtension).GetMethod("Protected").MakeGenericMethod(templateType);
                var protectedMock = mockProtected.Invoke(null, new[] { mockTemplate });

                // find the setup function for protected methods for setting up 1 return type
                var protectedSetupCall = protectedMock.GetType().GetMethods().First(
                    x => x.Name == "Setup" && x.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(typeof(Func<object>));
                var protectedSetupExistsCall = protectedMock.GetType().GetMethods().First(
                    x => x.Name == "Setup" && x.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(typeof(bool));

                // setup GetObjectFactory
                var protectedSetup = (ICallback)protectedSetupCall.Invoke(protectedMock,
                                                                           new object[]
                                                                               {
                                                                                   "GetObjectFactory",
                                                                                   new object[] {ItExpr.IsAny<string>()}
                                                                               });

                // setup FileExists
                var protectedSetupExists = (ICallback)protectedSetupExistsCall.Invoke(protectedMock,
                                                                           new object[]
                                                                               {
                                                                                   "FileExists",
                                                                                   new object[] {ItExpr.IsAny<string>(), ItExpr.IsAny<bool>()}
                                                                               });

                // set up return value for GetObjectFactory
                var returnsCall = protectedSetup.GetType().GetMethods().First(
                    x => x.Name == "Returns" && x.GetGenericArguments().Count() == 1)
                    .MakeGenericMethod(new[] { typeof(string) });
                returnsCall.Invoke(protectedSetup,
                                   new[]
                                       {
                                           (Func<string, Func<object>>)
                                           (s => () => new MockVirtualPathFactory().CreateInstance(s))
                                       });

                // set up return value for FileExists
                var returnsCallExists = protectedSetupExists.GetType().GetMethods().First(
                    x => x.Name == "Returns" && x.GetGenericArguments().Count() == 2)
                    .MakeGenericMethod(new[] { typeof(string), typeof(bool) });
                returnsCallExists.Invoke(protectedSetupExists,
                                         new[]
                                             {
                                                 (Func<string, bool, bool>)
                                                 ((s, b) => InternalExists(s))
                                             });

                var template = ((Mock)mockTemplate).Object;
                return template;
            }
            catch
            {
                return Activator.CreateInstance(templateType);
            }
        }
    }
}