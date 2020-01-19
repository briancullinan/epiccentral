using System.Web;

namespace EPICCentral.Utilities.Virtual
{
    internal class MockRequest : HttpRequestBase
    {
        private readonly string _url;
        public MockRequest(string url)
        {
            _url = url;
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return _url.StartsWith("~") ? VirtualPathUtility.ToAppRelative(_url) : _url;
            }
        }

        public override string PathInfo
        {
            get { return ""; }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }
    }
}