using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPICCentral.Controllers.Widgets;

namespace EPICCentral.Models
{
    public class HomeModel
    {
        public Dictionary<Type, IWidgetController> Widgets { get; set; }
        public IEnumerable<Type> LeftTypes { get; set; }
        public IEnumerable<Type> CenterTypes { get; set; }
        public IEnumerable<Type> RightTypes { get; set; }
    }
}