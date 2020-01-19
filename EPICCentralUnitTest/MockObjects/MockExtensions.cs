using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.WebPages;
using EPICCentral;
using EPICCentral.REST.Core;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPICCentralUnitTest.MockObjects
{
    public static class MockExtensions
    {
        private static MockRepository repo = new MockRepository(MockBehavior.Strict)
                                                 {DefaultValue = DefaultValue.Mock, CallBase = true};

        public static MockRepository Repository
        {
            get { return repo; }
        }

        public static Mock<T> Mock<T>(params object[] args)
            where T : class
        {
            return repo.Create<T>(args);
        }

        public static Mock<M> Mock<C, M>(this Mock<C> obj, Expression<Func<C, M>> property, params object[] args)
            where C : class
            where M : class
        {
            return Mock(obj.Object, property, args);
        }

        public static Mock<M> Mock<C, M>(this C obj, Expression<Func<C, M>> property, params object[] args)
            where C : class
            where M : class
        {
            try
            {
                var propVal = property.Compile().Invoke(obj);
                if (propVal is IMocked)
                {
                    return ((IMocked) propVal).Mock as Mock<M>;
                }
                throw new Exception("Property is not mocked, create a new mocked item.");
            }
            catch
            {
                // getting the value doesn't work, create a new one and try to set it
                var mockItem = Mock<M>(args);
                try
                {
                    // try to set the new mocked object
                    if (obj is IMocked)
                    {
                        ((IMocked) obj).Mock.As<C>().SetupGet(property).Returns(mockItem.Object);
                    }
                    else
                    {
                        // try to set the property normally
                        property.GetterToSetter().Invoke(obj, mockItem.Object);
                    }
                }
                catch
                {
                    // setting failed, just return the item
                }
                return mockItem;
            }
        }

        public static Mock<ControllerContext> Mock(this Controller obj,
                                                   Expression<Func<Controller, ControllerContext>> property,
                                                   params object[] args)
        {
            // get the controller context
            var controllerContext = obj.Mock<Controller, ControllerContext>(property, args);

            // setup http context
            var httpContext = controllerContext.Mock(x => x.HttpContext);
            var routeData = new RouteData();
            var requestContext = new RequestContext(httpContext.Object, routeData);

            // setup controller context
            controllerContext.SetupGet(x => x.Controller).Returns(obj);
            controllerContext.SetupGet(x => x.RouteData).Returns(routeData);
            controllerContext.SetupGet(x => x.IsChildAction).Returns(false);
            controllerContext.SetupGet(x => x.HttpContext).Returns(httpContext.Object);

            var request = httpContext.Mock(x => x.Request);
            request.SetupGet(x => x.RequestContext).Returns(requestContext);

            // set up url helper
            var routeCollection = new RouteCollection();
            Global.RegisterRoutes(routeCollection);
            obj.Url = new UrlHelper(requestContext, routeCollection);

            return controllerContext;
        }

        public static Mock<HttpContextBase> Mock(
            this Mock<ControllerContext> obj,
            Expression<Func<ControllerContext, HttpContextBase>> property,
            params object[] args)
        {
            var httpContext = obj.Mock<ControllerContext, HttpContextBase>(property, args);
            httpContext.SetupGet(x => x.Timestamp).Returns(DateTime.UtcNow.ToLocalTime());
            httpContext.SetupGet(x => x.IsCustomErrorEnabled).Returns(false);

            // setup http items
            var items = new Dictionary<object, object>();
            httpContext.SetupGet(x => x.Items).Returns(items);

            // setup user
            var user = (IPrincipal) new RolePrincipal(new GenericIdentity(""));
            httpContext.SetupProperty(x => x.User, user);

            // setup session
            httpContext.SetupGet(x => x.Session).Returns(new HttpSessionMock());

            // setup request
            var request = httpContext.Mock(x => x.Request);
            httpContext.SetupGet(x => x.Request).Returns(request.Object);

            // setup response
            var response = httpContext.Mock(x => x.Response);
            httpContext.SetupGet(c => c.Response).Returns(response.Object);

            // setup server
            var server = httpContext.Mock(x => x.Server);
            httpContext.SetupGet(x => x.Server).Returns(server.Object);
            server.Setup(x => x.Execute(It.IsAny<IHttpHandler>(), It.IsAny<TextWriter>(), It.IsAny<bool>()))
                .Callback<IHttpHandler, TextWriter, bool>(Action);

            return httpContext;
        }

        private static void Action(IHttpHandler httpHandler, TextWriter textWriter, bool arg3)
        {
            var handler = httpHandler as MvcHandler;
            if (handler == null)
            {
                var prop = httpHandler.GetType().GetProperty("InnerHandler",
                                                             BindingFlags.NonPublic | BindingFlags.Instance);
                if (prop != null)
                    handler = prop.GetValue(httpHandler, null) as MvcHandler;
            }
            if (handler != null)
            {
                var factory = ControllerBuilder.Current.GetControllerFactory();
                var controllerName = handler.RequestContext.RouteData.GetRequiredString("controller") + "Controller";
                var controller = factory.CreateController(handler.RequestContext, controllerName) as Controller;
                var controllerContext = controller.Mock(x => x.ControllerContext);
                controllerContext.SetupGet(x => x.HttpContext).Returns(handler.RequestContext.HttpContext);
                controllerContext.SetupGet(x => x.RouteData).Returns(handler.RequestContext.RouteData);
                var previousOutput = controllerContext.Object.HttpContext.Response.Output;
                var response = controllerContext.Mock(x => x.HttpContext.Response);
                response.Setup(x => x.Output).Returns(textWriter);
                var previousHttpContext = HttpContext.Current;
                controller.Invoke(handler.RequestContext.RouteData.GetRequiredString("action"));
                HttpContext.Current = previousHttpContext;
                response.Setup(x => x.Output).Returns(previousOutput);
            }
        }

        public static Mock<HttpRequestBase> Mock(
            this Mock<HttpContextBase> obj,
            Expression<Func<HttpContextBase, HttpRequestBase>> property,
            params object[] args)
        {
            var request = obj.Mock<HttpContextBase, HttpRequestBase>(property, args);

            request.SetupGet(x => x.ContentType).Returns("text/html");
            request.Setup(x => x.ValidateInput()).Callback(() => { });
            request.SetupGet(x => x.ApplicationPath).Returns("/");
            request.SetupGet(x => x.ServerVariables).Returns(new NameValueCollection
                                                                 {
                                                                     {"REMOTE_ADDR", "127.0.0.1"}
                                                                 });
            request.SetupGet(x => x.UserHostAddress).Returns("127.0.0.1");
            request.SetupGet(x => x.Url).Returns(new Uri("http://localhost/"));
            request.SetupGet(x => x.Headers).Returns(new NameValueCollection());
            request.SetupGet(x => x.Files).Returns(new Mock<HttpFileCollectionBase>().Object);
            request.SetupGet(x => x.IsLocal).Returns(true);
            request.SetupGet(x => x.RawUrl).Returns(() =>
                                                        {
                                                            return request.Object.Url.AbsolutePath;
                                                        });
            request.SetupGet(x => x.HttpMethod).Returns("GET");
            request.SetupGet(x => x["X-Requested-With"]).Returns("HttpRequest");
            request.SetupGet(x => x.IsAuthenticated).Returns(() =>
                request.Object.RequestContext.HttpContext.User.Identity.IsAuthenticated);

            var form = new NameValueCollection();
            request.SetupGet(x => x.Form).Returns(form);

            var queryString = new NameValueCollection();
            request.SetupGet(x => x.QueryString).Returns(queryString);

            return request;
        }

        public static Mock<HttpResponseBase> Mock(
            this Mock<HttpContextBase> obj,
            Expression<Func<HttpContextBase, HttpResponseBase>> property,
            params object[] args)
        {
            var response = obj.Mock<HttpContextBase, HttpResponseBase>(property, args);

            // setup response
            response.SetupProperty(x => x.StatusCode, 200);
            var writer = new StringWriter();
            response.SetupGet(x => x.Output).Returns(writer);
            response.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);
            response.Setup(x => x.Redirect(It.IsAny<string>(), It.IsAny<bool>()))
                .Callback<string, bool>((s, b) => response.SetupGet(x => x.RedirectLocation).Returns(s));
            response.SetupProperty(x => x.ContentType);
            response.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(s => response.Object.Output.Write(s));
            response.SetupProperty(x => x.TrySkipIisCustomErrors);

            // setup response cache policy
            var cache = response.Mock(x => x.Cache);
            response.SetupGet(x => x.Cache).Returns(cache.Object);
            cache.Setup(x => x.SetProxyMaxAge(It.IsAny<TimeSpan>()));
            cache.Setup(x => x.AddValidationCallback(It.IsAny<HttpCacheValidateHandler>(), It.IsAny<object>()));
            cache.Setup(x => x.SetCacheability(It.IsAny<HttpCacheability>())).Callback(() => { });
            cache.Setup(x => x.SetNoStore()).Callback(() => { });

            return response;
        }

        public static string Invoke<C, A>(this C controller, Expression<Func<C, A>> action)
            where C : Controller
        {
            if(action.Body.NodeType != ExpressionType.Call)
                throw new ArgumentException("action must be a method.", "action");

            var method = ((MethodCallExpression) action.Body).Method;
            if (method.DeclaringType != controller.GetType())
                throw new ArgumentException("action must be a method on the controller {C}.".Replace("{C}", controller.GetType().Name), "action");

            // try to get the request method from the attributes
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            var attrs = method.GetCustomAttributes(true);
            if(attrs.OfType<HttpGetAttribute>().Any())
                request.Setup(x => x.HttpMethod).Returns("GET");
            if (attrs.OfType<HttpDeleteAttribute>().Any())
                request.Setup(x => x.HttpMethod).Returns("DELETE");
            if (attrs.OfType<HttpPostAttribute>().Any())
                request.Setup(x => x.HttpMethod).Returns("POST");
            if (attrs.OfType<HttpPutAttribute>().Any())
                request.Setup(x => x.HttpMethod).Returns("PUT");

            // check authentication
            if (controller.HttpContext.User.Identity.IsAuthenticated == false)
            {
                UserEntity user;
                if (!attrs.OfType<AllowAttribute>().Any())
                    user =
                        new LinqMetaData().User
                            .FirstOrDefault(
                                x => x.Roles.Any(y => y.Role.Name != "Service Administrator" &&
                                                      y.Role.Name != "Organization Administrator"));
                else
                {
                    var allowUsers =
                        attrs.OfType<AllowAttribute>().Where(x => !(x is DenyAttribute)).SelectMany(
                            x => x.Users != null ? x.Users.Split(',').Select(y => y.Trim()) : new string[] { });
                    var allowRoles =
                        attrs.OfType<AllowAttribute>().Where(x => !(x is DenyAttribute)).SelectMany(
                            x => x.Roles != null ? x.Roles.Split(',').Select(y => y.Trim()) : new string[] { });
                    var denyUsers =
                        attrs.OfType<DenyAttribute>().SelectMany(
                            x => x.Users != null ? x.Users.Split(',').Select(y => y.Trim()) : new string[] { });
                    var denyRoles =
                        attrs.OfType<DenyAttribute>().SelectMany(
                            x => x.Roles != null ? x.Roles.Split(',').Select(y => y.Trim()) : new string[] { });

                    user =
                        new LinqMetaData().User.FirstOrDefault(
                        // make sure username is in allow users and not in deny users
                            x => allowUsers.Contains("*") || (allowUsers.Contains(x.Username) && !denyUsers.Contains(x.Username)) ||
                                // make sure role is in allow roles and not in deny roles
                                    allowRoles.Contains("*") || x.Roles.Any(
                                        role => allowRoles.Contains(role.Role.Name) && !denyRoles.Contains(role.Role.Name)));
                }
                if (user != null)
                    controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            }

            SetupHttpContext(controller, method.Name);

            // convert parameters to route data
            var formValues = new NameValueCollection();
            var current = 0;
            foreach(var parameter in method.GetParameters())
            {
                try
                {
                    var obj =
                        Expression.Lambda(((MethodCallExpression) action.Body).Arguments[current])
                            .Compile().DynamicInvoke();

                    current++;
                    if (obj == null)
                        continue;

                    if (obj.GetType().IsPrimitive || obj is string)
                        controller.RouteData.Values[parameter.Name] = obj.ToString();
                    else
                    {
                        // convert object data to form values
                        foreach (var val in obj.GetType().GetProperties()
                            .Where(x => !x.GetIndexParameters().Any() && x.GetGetMethod() != null &&
                                        x.GetSetMethod() != null))
                        {
                            var propValue = val.GetValue(obj, null);
                            if (propValue == null)
                                continue;

                            formValues.Add(TagBuilder.CreateSanitizedId(val.Name), propValue.ToString());
                        }
                    }
                }
                catch(TargetInvocationException ex)
                {
                    throw ex.InnerException;
                }
            }

            // set up form values
            request.SetupGet(x => x.Form).Returns(() => formValues);

            return controller.Invoke(method.Name);
        }

        internal static void SetupHttpContext(Controller controller, string actionName)
        {
            // setup route data
            controller.ControllerContext.RouteData.Values["action"] = actionName;
            controller.ControllerContext.RouteData.Values["controller"] =
                controller.GetType().Name.EndsWith("Controller")
                    ? controller.GetType().Name.Substring(0, controller.GetType().Name.Length - 10)
                    : controller.GetType().Name;
            // set up current context
            var url =
                new Uri(
                    controller.Url.RouteUrl(null, controller.ControllerContext.RouteData.Values, "http", "localhost"),
                    UriKind.Absolute);
            HttpContext.Current = new HttpContext(
                new HttpRequest(url.AbsolutePath, url.AbsoluteUri, url.Query),
                new HttpResponse(controller.ControllerContext.HttpContext.Response.Output));

            // set up current user
            HttpContext.Current.User = controller.ControllerContext.HttpContext.User;
            Thread.CurrentPrincipal = HttpContext.Current.User;

            // set up mock session
            var sessionContainer = new HttpSessionStateContainer("id",
                                                                 new SessionStateItemCollection(),
                                                                 new HttpStaticObjectsCollection(), 10, true,
                                                                 HttpCookieMode.AutoDetect,
                                                                 SessionStateMode.InProc, false);

            HttpContext.Current.Items["AspSession"] = typeof (HttpSessionState)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, CallingConventions.Standard,
                                new[] {typeof (HttpSessionStateContainer)}, null)
                .Invoke(new object[] {sessionContainer});
            HttpContext.Current.Handler = new MvcHandler(controller.HttpContext.Request.RequestContext);

            Global.VirtualPathProvider = new MockPathProvider();

            Global.SetupRequestState();
        }

        public static string Invoke<C>(this C controller, string actionName)
            where C : Controller
        {
            // call setup http context once
            SetupHttpContext(controller, actionName);

            // set up value providers
            var form = controller.ControllerContext.HttpContext.Request.Form;
            var formDictionary = form.AllKeys.ToDictionary(x => x, x => form[x]);
            controller.ValueProvider = new ValueProviderCollection(
                new IValueProvider[]
                    {
                        new RouteDataValueProvider(controller.ControllerContext),
                        new QueryStringValueProvider(controller.ControllerContext),
                        new FormValueProvider(controller.ControllerContext),
                        new DictionaryValueProvider<string>(formDictionary, CultureInfo.InvariantCulture)
                    });

            // set up virtual path provider
            VirtualPathFactoryManager.RegisterVirtualPathFactory(new MockVirtualPathFactory());
            ControllerBuilder.Current.SetControllerFactory(new MockControllerFactory());

            // finally, invoke action
            var result = controller.ActionInvoker.InvokeAction(controller.ControllerContext, actionName);
            if (result)
                return controller.Response.Output.ToString();
            throw new Exception("Invocation failed.");
        }
    }

    public class MockPathProvider : VirtualPathProvider
    {
        public override bool FileExists(string virtualPath)
        {
            return File.Exists(MockVirtualPathFactory.NormalizePath(virtualPath));
        }

        public override bool DirectoryExists(string virtualDir)
        {
            return Directory.Exists(MockVirtualPathFactory.NormalizePath(virtualDir));
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var virtualMock = MockExtensions.Repository.Create<VirtualFile>(virtualPath);
            virtualMock.Setup(x => x.Open()).Returns(new FileStream(MockVirtualPathFactory.NormalizePath(virtualPath),
                                                                    FileMode.Open, FileAccess.Read, FileShare.Read));
            return virtualMock.Object;
        }
    }
}