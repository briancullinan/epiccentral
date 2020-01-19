using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Compilation;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Util;
using EPICCentral.Providers;
using EPICCentral.Utilities.Treatment;
using log4net;

/// <summary>
/// Acts similar to Role provider, but adds another dimension of access by using the type of an object being accessed and a string descriptor.
/// Extendable using web.config just like Role provider.
/// </summary>
public static class Permissions
{
    private static bool s_Initialized;
    private static Exception s_InitializeException;
    private static PermissionProviderCollection s_Providers;
    private static bool s_InitializedDefaultProvider;
    private static bool s_EnabledSet;
    private static bool s_Enabled;
    private static PermissionProvider s_Provider;
    private static readonly ILog Log = LogManager.GetLogger(typeof (Permissions));
    private static object s_lock = new object();

    public static PermissionProvider Provider
    {
        get
        {
            EnsureEnabled();
            if (s_Provider == null)
            {
                throw new InvalidOperationException("Permission provider not found.");
            }
            return s_Provider;
        }
    }

    public static bool Enabled
    {
        get
        {
            var result =
                (AspNetHostingPermission)
                HttpRuntime.GetNamedPermissionSet().GetPermission(typeof (AspNetHostingPermission));
            if (result == null || result.Level < AspNetHostingPermissionLevel.Low)
                return false;

            if (!s_Initialized && !s_EnabledSet)
            {
                PermissionProviderSection config =
                    (PermissionProviderSection) ConfigurationManager.GetSection("permissions");
                s_Enabled = config.Enabled;
                s_EnabledSet = true;
            }

            return s_Enabled;
        }
        set
        {
            s_Enabled = value;
            s_EnabledSet = true;
        }
    }


    public static PermissionProviderCollection Providers
    {
        get
        {
            EnsureEnabled();
            return s_Providers;
        }
    }

    private static void EnsureEnabled()
    {
        Initialize();
        if (!s_Enabled)
            throw new ProviderException("Permission providers not enabled.");
    }

    private static void Initialize()
    {
        if (!s_Initialized)
        {
            if (s_InitializeException != null)
            {
                throw s_InitializeException;
            }
            if (s_InitializedDefaultProvider)
            {
                return;
            }
        }


        lock (s_lock)
        {
            if (s_Initialized)
            {
                if (s_InitializeException != null)
                {
                    throw s_InitializeException;
                }
                if (s_InitializedDefaultProvider)
                {
                    return;
                }
            }
            try
            {
                if (HostingEnvironment.IsHosted)
                {
                    var namedPermissionSet = HttpRuntime.GetNamedPermissionSet();
                    if (namedPermissionSet != null)
                    {
                        var result = namedPermissionSet.GetPermission(typeof (AspNetHostingPermission));
                        if (result == null || ((AspNetHostingPermission)result).Level < AspNetHostingPermissionLevel.Low)
                            throw new HttpException("Feature not supported at this level.");
                    }
                }

                PermissionProviderSection settings =
                    (PermissionProviderSection) ConfigurationManager.GetSection("permissions");

                if (!s_EnabledSet)
                {
                    s_Enabled = settings.Enabled;
                }

                InitializeSettings(settings);
                InitializeDefaultProvider(settings);
            }
            catch (Exception ex)
            {
                s_InitializeException = ex;
            }
            s_Initialized = true;
        }

        if (s_InitializeException != null)
            throw s_InitializeException;
    }

    private static void InitializeSettings(PermissionProviderSection settings)
    {
        if (!s_Initialized)
        {
            s_Providers = new PermissionProviderCollection();

            if (HostingEnvironment.IsHosted)
            {
                foreach (ProviderSettings ps in settings.Providers)
                {
                    var providerType = BuildManager.GetType(ps.Type, true /*throwOnError*/, true);
                    var implementingType = providerType.GenericExtendsType(typeof (PermissionProvider<>));
                    var providerGeneric =
                        typeof (PermissionProvider<>).MakeGenericType(new[] {implementingType.GetGenericArguments()[0]});

                    s_Providers.Add(ProvidersHelper.InstantiateProvider(ps, providerGeneric));
                }
            }
            else
            {
                foreach (ProviderSettings ps in settings.Providers)
                {
                    Type t = Type.GetType(ps.Type, true, true);
                    var implementingType = t.GenericExtendsType(typeof(PermissionProvider<>));
                    if (implementingType == null)
                        throw new ArgumentException("Provider must implement type PermissionProvider", "provider");

                    var provider = (PermissionProvider)Activator.CreateInstance(t);
                    var pars = ps.Parameters;
                    var cloneParams = new NameValueCollection(pars.Count, StringComparer.Ordinal);
                    foreach (string key in pars)
                        cloneParams[key] = pars[key];

                    provider.Initialize(ps.Name, cloneParams);
                    s_Providers.Add(provider);
                }
            }
        }
    }

    private static void InitializeDefaultProvider(PermissionProviderSection settings)
    {
        if (!s_InitializedDefaultProvider)
        {
            s_Providers.SetReadOnly();

            if (settings.DefaultProvider == null)
            {
                s_InitializeException = new ProviderException("Default permission provider not specified.");
            }
            else
            {
                try
                {
                    s_Provider = s_Providers[settings.DefaultProvider];
                }
                catch
                {
                }
            }

            if (s_Provider == null)
            {
                s_InitializeException = new ConfigurationErrorsException("Default provider not found.",
                                                                         settings.ElementInformation.Properties["defaultProvider"].Source,
                                                                         settings.ElementInformation.Properties["defaultProvider"].LineNumber);
            }

            s_InitializedDefaultProvider = true;
        }
    }

    public static bool UserHasPermission(object entity)
    {
        return UserHasPermission(GetCurrentUserName(), new StackFrame(2, false).GetMethod(), entity);
    }

    public static bool UserHasPermission(MethodBase method, object entity)
    {
        return UserHasPermission(GetCurrentUserName(), method, entity);
    }

    public static bool UserHasPermission(string permissionName, object entity)
    {
        return UserHasPermission(GetCurrentUserName(), permissionName, entity);
    }

    public static bool UserHasPermission(string username, string permissionName, object entity)
    {
        Log.Debug("UserHasPermission Begin.");

        EnsureEnabled();
        try
        {
            // try default provider
            return Provider.UserHasPermission(username, permissionName, entity);
        }
        finally
        {
            Log.Debug("UserHasPermission End.");
        }
    }

    public static bool UserHasPermission(string username, MethodBase method, object entity)
    {
        Log.Debug("UserHasPermission Begin.");

        EnsureEnabled();
        try
        {
            // try default provider
            return Provider.UserHasPermission(username, method, entity);
        }
        finally
        {
            Log.Debug("UserHasPermission End.");
        }
    }

    private static string GetCurrentUserName()
    {
        IPrincipal user = GetCurrentUser();
        if (user == null || user.Identity == null)
            return String.Empty;
        else
            return user.Identity.Name;
    }

    private static IPrincipal GetCurrentUser()
    {
        if (HostingEnvironment.IsHosted)
        {
            HttpContext cur = HttpContext.Current;
            if (cur != null)
                return cur.User;
        }
        return Thread.CurrentPrincipal;
    }
}

namespace EPICCentral.Providers
{
    /// <summary>
    /// Base class that providers extend.
    /// </summary>
    public abstract class PermissionProvider : ProviderBase
    {
        /// <summary>
        /// Tries to find a method that matches entity type and uses the methods access attributes to determine permissions.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="method"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UserHasPermission(string username, MethodBase method, object entity)
        {
            // find a provider based on entity type
            var factory = ControllerBuilder.Current.GetControllerFactory();
            var controller = factory.CreateController(HttpContext.Current.Request.RequestContext, method.DeclaringType.Name);
            var controllerContext = new ControllerContext(HttpContext.Current.Request.RequestContext, controller as ControllerBase);
            var controllerDescriptor = new ReflectedControllerDescriptor(controller.GetType());
            var actionDescriptor = controllerDescriptor.FindAction(controllerContext, method.Name);
            var authContext = new AuthorizationContext(controllerContext, actionDescriptor);

            foreach (IAuthorizationFilter authFilter in FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor).OfType<IAuthorizationFilter>())
            {
                authFilter.OnAuthorization(authContext);

                if (authContext.Result != null)
                    return false;
            }

            foreach (var provider in Permissions.Providers)
            {
                try
                {
                    var matchingMethods = provider.GetType().GetMethods().Where(x =>
                    {
                        var param = x.GetParameters();
                        // TODO: replace this with a more defined search like the one in the method below
                        return x.Name == "UserHasPermission" && x.IsPublic &&
                               x.ReturnType == typeof(bool) &&
                               param.Count() == 2 &&
                               new[] { entity.GetType() }.Concat(entity.GetType().GetBaseTypes()).Any(
                                   y => param[1].ParameterType == y);
                    });
                    return (bool)matchingMethods.First().Invoke(provider, new[] { username, entity });
                }
                finally
                {
                }
            }

            throw new ArgumentException(String.Format("Cannot find a provider that supports input of type {0}.", entity.GetType()), "entity");
        }

        /// <summary>
        /// Tries to find a provider with a permission method that matches the entity type and checks permissions based on the permission name passed in.
        /// </summary>
        /// <param name="username">The user to check permissions for.</param>
        /// <param name="permissionName">The string descriptor of the permission to check.</param>
        /// <param name="entity">The context entity of what the user is trying to access.</param>
        /// <returns></returns>
        public bool UserHasPermission(string username, string permissionName, object entity)
        {
            // find a provider based on entity type
            foreach(var provider in Permissions.Providers)
            {
                try
                {
                    var objectType = provider.GetType().GenericExtendsType(typeof(PermissionProvider<>)).GetGenericArguments()[0];
                    var method = provider.GetType().GetMethod("UserHasPermission",
                                                              BindingFlags.Public | BindingFlags.Instance, null,
                                                              new[] { typeof(string), typeof(string), objectType },
                                                              null);
                    return (bool)method.Invoke(provider, new[] { username, permissionName, entity });
                }
                finally
                {
                }
            }

            throw new ArgumentException(String.Format("Cannot find a provider that supports input of type {0}.", entity.GetType()), "entity");
        }
    }

    public abstract class PermissionProvider<TEntity> : PermissionProvider
    {
        protected PermissionProvider()
        {
        }

        public virtual bool UserHasPermission(string username, string permissionName, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool UserHasPermission(string username, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Set up the providers in the web.config just like Role provider.
    /// </summary>
    public class PermissionProviderSection : ConfigurationSection
    {
        private static ConfigurationPropertyCollection _properties;

        private static readonly ConfigurationProperty _propEnabled =
            new ConfigurationProperty("enabled",
                                      typeof (bool),
                                      true,
                                      ConfigurationPropertyOptions.None);

        private static readonly ConfigurationProperty _propProviders =
            new ConfigurationProperty("providers",
                                      typeof (ProviderSettingsCollection),
                                      null,
                                      ConfigurationPropertyOptions.None);

        private static readonly ConfigurationProperty _propDefaultProvider =
            new ConfigurationProperty("defaultProvider",
                                      typeof (string),
                                      "EpicPermissionProvider",
                                      null,
                                      new StringValidator(1),
                                      ConfigurationPropertyOptions.None);

        static PermissionProviderSection()
        {
            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_propEnabled);
            _properties.Add(_propDefaultProvider);
            _properties.Add(_propProviders);

        }

        public PermissionProviderSection()
        {
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get { return (bool) base[_propEnabled]; }
            set { base[_propEnabled] = value; }
        }


        [ConfigurationProperty("defaultProvider", DefaultValue = "EpicPermissionProvider")]
        [TypeConverter(typeof (WhiteSpaceTrimStringConverter))]
        [StringValidator(MinLength = 1)]
        public string DefaultProvider
        {
            get { return (string) base[_propDefaultProvider]; }
            set { base[_propDefaultProvider] = value; }
        }

        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection) base[_propProviders]; }
        }
    }

    /// <summary>
    /// A simple collection of providers specified in the web.config.
    /// </summary>
    public class PermissionProviderCollection : ProviderCollection
    {

        public override void Add(ProviderBase provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }

            if (provider.GetType().GenericImplementsType(typeof(PermissionProvider<>)) != null)
            {
                throw new ArgumentException("Provider must implement type PermissionProvider", "provider");
            }

            base.Add(provider);
        }

        public new PermissionProvider this[string name]
        {
            get { return (PermissionProvider) base[name]; }
        }

        public void CopyTo(PermissionProvider[] array, int index)
        {
            base.CopyTo(array, index);
        }

    }
}