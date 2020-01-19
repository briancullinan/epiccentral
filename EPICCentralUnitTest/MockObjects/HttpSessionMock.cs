using System.Collections.Generic;
using System.Web;

namespace EPICCentralUnitTest.MockObjects
{
    public class HttpSessionMock : HttpSessionStateBase
    {
        private Dictionary<string, object> _objects = new Dictionary<string, object>();

        public override object this[string name]
        {
            get { return (_objects.ContainsKey(name)) ? _objects[name] : null; }
            set { _objects[name] = value; }
        }

        public override void Abandon()
        {
            _objects = new Dictionary<string, object>();
        }
    }
}