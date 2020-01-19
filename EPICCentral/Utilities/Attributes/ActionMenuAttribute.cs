using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Security;
using EPICCentral.Models;
using EPICCentral.Utilities.Virtual;

namespace EPICCentral.Utilities.Attributes
{
    /// <summary>
    /// Primary Menu functionality.
    /// This works by looping through controllers and looking at all the attributes, then caching the menu in the process and filtering out which menus are accessible by the current user.
    /// </summary>
    [AttributeUsageAttribute(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    [Serializable]
    public class ActionMenuAttribute : Attribute, IEqualityComparer<ActionMenuAttribute>
    {
        private static bool _menusSet;
        private static IEnumerable<ActionMenuAttribute> _menus;
        public static IEnumerable<ActionMenuAttribute> Menus
        {
            get
            {
                if(!_menusSet)
                {
                    var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(Controller).IsAssignableFrom(x));

                    _menus = types.SelectMany(
                        controller =>
                        {
                            var attrs = controller.GetCustomAttributes(typeof(ControllerMenuAttribute), false)
                                .Cast<ControllerMenuAttribute>();

                            if (!attrs.Any())
                                attrs = new[] { new ControllerMenuAttribute() };

                            return attrs.SelectMany(
                                controllerMenu =>
                                {
                                    if (controllerMenu.Controller == null)
                                        controllerMenu.Controller = controller;
                                    return controllerMenu.SubMenu;
                                });
                        });
                    _menusSet = true;
                }
                return _menus;
            }
        } 

        private Type _resourceType = typeof (ControllerRes.Menu);

        public virtual int Rank { get; set; }

        public Type ResourceType
        {
            get { return _resourceType; }
            set { _resourceType = value; }
        }

        private string _resourceName;
        private bool _resourceNameSet;
        public string ResourceName
        {
            get
            {
                if (!_resourceNameSet)
                    ResourceName = ControllerName + Action;
                return _resourceName;

            }
            set
            {
                _resourceNameSet = true;
                _resourceName = value;
            }
        }

        private Func<string> _selector;
        private bool _selectorSet;
        public virtual Func<string> ResourceSelector
        {
            get
            {
                if (!_selectorSet)
                {
                    _selector = () =>
                                    {
                                        var prop = _resourceType.GetProperty(ResourceName);
                                        if (prop == null)
                                            throw new InvalidOperationException(
                                                String.Format("Resource type does not have property {0}.",
                                                              ControllerName + Action));
                                        return (string) prop.GetValue(null, null);
                                    };
                }
                return _selector;
            }
            set
            {
                _selectorSet = true;
                _selector = value;
            }
        }

        private string _text;
        private bool _textSet;
        public virtual string Text
        {
            get
            {
                if (!_textSet)
                    Text = ResourceSelector();
                return _text;
            }
            set
            {
                _textSet = true;
                _text = value;
            }
        }

        public MvcHtmlString ToHtmlString()
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            return MvcHtmlString.Create(String.Format("<a href=\"{0}\">{1}</a>", Controller != null 
                ? urlHelper.Action(Action, ControllerName)
                : urlHelper.Content(Path), Text));
        }

        private Type _controller;
        private bool _controllerSet;
        public Type Controller
        {
            get
            {
                if (_controllerSet)
                    return _controller;
                if(_pathSet && (Path.StartsWith("~") || Path.StartsWith("/")))
                {
                    var httpContext = new VirtualHttpContext(Path);
                    var routeData = RouteTable.Routes.GetRouteData(httpContext);
                    if (routeData != null)
                    {
                        if (routeData.Values.ContainsKey("controller"))
                        {
                            var controllerName = routeData.Values["controller"].ToString();
                            var types = Assembly.GetExecutingAssembly().GetTypes();
                            var controller =
                                types.FirstOrDefault(
                                    x => x.Name.StartsWith(controllerName, StringComparison.OrdinalIgnoreCase) &&
                                         typeof (Controller).IsAssignableFrom(x));
                            if(controller != null)
                            {
                                Controller = controller;
                                return _controller;
                            }
                        }
                    }
                }
                return null;
            }
            internal set
            {
                _controllerSet = true;
                _controller = value;
            }
        }

        public string ControllerName
        {
            get
            {
                return Controller.Name.EndsWith("Controller")
                         ? Controller.Name.Substring(0, Controller.Name.Length - 10)
                         : Controller.Name;
            }
        }

        private string _action;
        private bool _actionSet;

        public string Action
        {
            get
            {
                if (_actionSet)
                    return _action;
                if(_pathSet)
                {
                    var httpContext = new VirtualHttpContext(Path);
                    var routeData = RouteTable.Routes.GetRouteData(httpContext);
                    if (routeData != null)
                    {
                        if (routeData.Values.ContainsKey("action"))
                        {
                            Action = routeData.Values["action"].ToString();
                            return _action;
                        }
                    }
                }
                return null;
            }
            internal set
            {
                _actionSet = true;
                _action = value;
            }
        }

        private string _selectAction;
        private bool _selectActionSet;
        public string SelectAction
        {
            get
            {
                if (_selectActionSet)
                    return _selectAction;
                return Action;
            }
            set
            {
                _selectActionSet = true;
                _selectAction = value;
            }
        }

        private Type _selectController;
        private bool _selectControllerSet;
        public Type SelectController
        {
            get
            {
                if (_selectControllerSet)
                    return _selectController;
                return Controller;
            }
            set
            {
                _selectControllerSet = true;
                _selectController = value;
            }
        }

        private bool _pathSet;
        private string _path;
        public string Path
        {
            get
            {
                if (_pathSet)
                    return _path;
                var routeData = new RouteData();
                routeData.Values.Add("controller",
                                     Controller.Name.EndsWith("Controller")
                                         ? Controller.Name.Substring(0, Controller.Name.Length - 10)
                                         : Controller.Name);
                routeData.Values.Add("action", Action);
                var path = RouteTable.Routes.GetVirtualPath(HttpContext.Current.Request.RequestContext, routeData.Values);
                return path != null ? path.VirtualPath : null;
            }
            set
            {
                _pathSet = true;
                _path = value;
            }
        }

        private IEnumerable<ActionMenuAttribute> _subMenu = new List<ActionMenuAttribute>();
        private bool _subMenuSet;
        public virtual IEnumerable<ActionMenuAttribute> SubMenu
        {
            get
            {
                if(!_subMenuSet)
                    SubMenu = GetSubMenu();
                return _subMenu;
            }
            set
            {
                _subMenuSet = true;
                _subMenu = value;
            }
        }

        public virtual IEnumerable<ActionMenuAttribute> GetSubMenu()
        {
            return new List<ActionMenuAttribute>();
        }

        private bool _selected;
        private bool _selectedSet;
        public virtual bool Selected
        {
            get
            {
                if (!_selectedSet)
                {
                    if (_selectActionSet || _selectControllerSet)
                        Selected = false;
                    else
                    {
                        var selected = GetSelected();

                        // if selected by another menu
                        selected |= Menus.Any(x => x != this && (
                                              (x.Controller == null && x.Path == Path) || 
                                              (x.Controller != null && x.SelectController == Controller && x.SelectAction == Action)
                                              ) && x.SelectSelected);

                        Selected = selected;
                    }
                }
                return _selected;
            }
            protected set
            {
                _selectedSet = true;
                _selected = value;
            }
        }

        private bool _selectSelected;
        private bool _selectSelectedSet;
        public virtual bool SelectSelected
        {
            get
            {
                if (!_selectSelectedSet)
                {
                    if (_selectActionSet || _selectControllerSet)
                    {
                        // if this menu selects another
                        SelectSelected = GetSelected();
                    }
                    else
                        SelectSelected = false;
                }
                return _selectSelected;
            }
            protected set
            {
                _selectSelectedSet = true;
                _selectSelected = value;
            }
        }

        protected virtual bool GetSelected()
        {
            try
            {
                var action = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString();
                var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();

                if (Controller != null)
                {
                    bool selected = ControllerName.Equals(controller, StringComparison.OrdinalIgnoreCase) &&
                                    Action.Equals(action, StringComparison.OrdinalIgnoreCase);

                    selected |= SubMenu.Any(x => x.Selected);

                    return selected;
                }
            }
            catch {}
            return false;
        }

        private bool _visible;
        private bool _visibleSet;
        public virtual bool Visible
        {
            get
            {
                if (!_visibleSet)
                    Visible = true;
                return _visible;
            }
            set
            {
                _visibleSet = true;
                _visible = value;
            }
        }

        private bool _authorized;
        private bool _authorizedSet;
        public virtual bool IsAuthorized
        {
            get
            {
                if(!_authorizedSet)
                    IsAuthorized = GetIsAuthorized();
                return _authorized;
            }
            protected set
            {
                _authorizedSet = true;
                _authorized = value;
            }
        }

        public virtual bool GetIsAuthorized()
        {
            IController controller = null;
            RouteData routeData = null;
            VirtualHttpContext httpContext = null;
            var factory = ControllerBuilder.Current.GetControllerFactory();

            if (_pathSet)
            {
                if (Path.StartsWith("~"))
                {
                    var path = VirtualPathUtility.ToAppRelative(Path);
                    if (Global.VirtualPathProvider.FileExists(path) ||
                        Global.VirtualPathProvider.DirectoryExists(path))
                    {
                        // check hosting permissions
                        if (UrlAuthorizationModule.CheckUrlAccessForPrincipal(path, HttpContext.Current.User, "GET"))
                        {
                            return true;
                        }
                    }

                    // get route date from path
                    httpContext = new VirtualHttpContext(Path);
                    routeData = RouteTable.Routes.GetRouteData(httpContext);
                    if (routeData != null && routeData.Values.ContainsKey("controller"))
                        controller = factory.CreateController(new RequestContext(httpContext, routeData), routeData.Values["controller"].ToString());
                }
                else
                {
                    return true;
                }
            }
            else
            {
                routeData = new RouteData();
                routeData.Values.Add("controller", ControllerName);
                routeData.Values.Add("action", Action);
                httpContext = new VirtualHttpContext(new UrlHelper(HttpContext.Current.Request.RequestContext).RouteUrl(routeData.Values));
                controller = factory.CreateController(new RequestContext(httpContext, routeData), ControllerName);
            }

            // check mvc based authentication defined in attributes
            if (controller != null)
            {
                // check access based on standard authorization
                if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(httpContext.Request.AppRelativeCurrentExecutionFilePath, HttpContext.Current.User, "GET"))
                    return false;

                // check controller access
                var controllerContext = new ControllerContext(httpContext, routeData, controller as ControllerBase);
                var controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
                var actionDescriptor = controllerDescriptor.FindAction(controllerContext,
                                                                       controllerContext.RouteData.Values["action"].
                                                                           ToString());

                // check method access
                if (VirtualHttpContext.ActionIsAuthorized(controllerContext, actionDescriptor))
                    return true;
            }
            return false;
        }

        public bool Equals(ActionMenuAttribute x, ActionMenuAttribute y)
        {
            if (x.Path == y.Path)
                return true;
            return false;
        }

        public int GetHashCode(ActionMenuAttribute obj)
        {
            return EqualityComparer<ActionMenuAttribute>.Default.GetHashCode(obj);
        }
    }
}