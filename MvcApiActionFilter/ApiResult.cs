using System.Web.Mvc;

namespace MvcApi
{
	/// <summary>
	/// An implementation of the <code>ActionResult</code> class which allows one to
	/// use the MVC API Action Filter without defining an unnecessary view.
	/// Simply have the controller action method return a new instance of this class.
	/// Pass the model to the constructor and the API attribute implementation will
	/// pull the model from the result.
	/// </summary>
	public class ApiResult : ViewResultBase
	{
		/// <summary>
		/// Construct a new instance saving the specified input as the model.
		/// The model will be pulled from this result when the attribute implementation
		/// runs.
		/// It will use the model to build the output.
		/// </summary>
		/// <param name="model">model containing the data for creating output</param>
		public ApiResult(object model)
		{
			ViewData.Model = model;
		}

		/// <summary>
		/// Never invoked; throws exception if it is.
		/// Since this <code>ActionResult</code> is never used to actually render a
		/// view, this method is never invoked by the MVC framework.
		/// </summary>
		/// <param name="context">controller's current context</param>
		/// <returns>N/A</returns>
		/// <exception cref="System.NotImplementedException">always thrown</exception>
		protected override ViewEngineResult FindView(ControllerContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}
