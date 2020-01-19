using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ControllerMenuAttribute : ActionMenuAttribute
    {
        public override IEnumerable<ActionMenuAttribute> GetSubMenu()
        {
            var methods = Controller.GetMethods()
                .Where(x => typeof (ActionResult).IsAssignableFrom(x.ReturnType));

            foreach (var method in methods)
                foreach (var attr in method
                    .GetCustomAttributes(typeof (ActionMenuAttribute), true)
                    .Cast<ActionMenuAttribute>())
                {
                    if (attr.Controller == null)
                        attr.Controller = Controller;
                    if (string.IsNullOrEmpty(attr.Action))
                        attr.Action = method.Name;
                    yield return attr;
                }
        }
    }
}