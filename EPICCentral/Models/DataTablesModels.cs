using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Resources;
using System.Web.Script.Serialization;
using EPICCentralDL.EntityClasses;
using ViewRes;
using Exception = System.Exception;

namespace EPICCentral.Models
{
    public interface IDataTableColumn
    {
        bool CanSort { get; set; }
        string ColumnName { get; set; }
        string Header { get; set; }
        string Style { get; set; }
        bool Visible { get; set; }
        string Toggle { get; set; }
    }

    [DataContract]
    public class DataTableColumn<TEntity> : IDataTableColumn
    {
        /// <summary>
        /// Initializes the column with the default values.  Should match the defaults set in the Add() functions for the column collection.
        /// </summary>
        public DataTableColumn()
        {
            CanSort = true;
            Visible = true;
            CanSearch = true;
        }

        /// <summary>
        /// Indicates if the column is sortable.
        /// </summary>
        [DataMember(Name = "bSortable")]
        public bool CanSort { get; set; }

        /// <summary>
        /// Indicates if the column is searchable.
        /// </summary>
        public bool CanSearch { get; set; }

        /// <summary>
        /// The name of column.  This is usually set to the Property name in TEntity
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// A function to evaluate on every TEntity in the collection to be displayed to the user.
        /// </summary>
        public Expression<Func<TEntity, object>> Format { get; set; }

        /// <summary>
        /// The header of the column.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// The CSS style class to be set on every element in the column.
        /// </summary>
        [DataMember(Name = "sClass")]
        public string Style { get; set; }

        /// <summary>
        /// Indicates if the column is visible to the user.  The column may still be searched even when this is set to false.
        /// </summary>
        [DataMember(Name = "bVisible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Used as a toggle switch when checked the search field will be populated with this value.
        /// </summary>
        public string Toggle { get; set; }
    }

    /// <summary>
    /// A collection of DataTableColumn
    /// </summary>
    public class ColumnCollection<TEntity> : List<DataTableColumn<TEntity>>
    {
        public ColumnCollection()
        {
        }

        public ColumnCollection(IEnumerable<DataTableColumn<TEntity>> columns)
            : base(columns)
		{
		}

        public void Add<TValue>(Expression<Func<TEntity, TValue>> expression, string header = null, Expression<Func<TEntity, object>> format = null, bool canSort = true, string style = null, bool visible = true, string toggle = null, bool canSearch = true)
        {
            var item = ExpressionHelper.GetExpressionText(expression);
            Add(item, header, format, canSort, style, visible, toggle, canSearch);
        }

        public void Add(string item, string header = null, Expression<Func<TEntity, object>> format = null, bool canSort = true, string style = null, bool visible = true, string toggle = null, bool canSearch = true)
        {
            Add(new DataTableColumn<TEntity> { ColumnName = item, Format = format, Header = header, CanSort = canSort, Style = style, Visible = visible, Toggle = toggle, CanSearch = canSearch});
        }
    }

    public interface IDataTablesInitializationModel
    {
        string ID { get; set; }
        string Url { get; set; }
        DataTablesDialogModelCollection Dialogs { get; set; }
        DataTablesDirectActionModelCollection DirectActions { get; set; }
        DataTablesAddModel Add { get; set; }
        int? DefaultCount { get; set; }
        List<DataTablesRequestModel.Sort> DefaultSorts { get; set; }
        IDictionary<string, object> TableAttributes { get; set; }

        int GetColumnIndex(string columnName);
        MvcHtmlString GetColumnsJson();
        MvcHtmlString GetSortsJson();
        MvcHtmlString GetLanguageJson();

        bool ColumnIsValid(IDataTableColumn column);
        IEnumerable<IDataTableColumn> GetColumns();
    }

    /// <summary>
    /// Contains all the information needed to Render and continue display result for a DataTable
    /// </summary>
    public class DataTablesInitializationModel<TEntity> : IDataTablesInitializationModel
    {
        public string ID { get; set; }
        public ColumnCollection<TEntity> Columns { get; set; }
        public string Url { get; set; }
		public DataTablesDialogModelCollection Dialogs { get; set; }
		public DataTablesDirectActionModelCollection DirectActions { get; set; }
		public DataTablesAddModel Add { get; set; }
        public IQueryable<TEntity> Source { get; set; }
        public int? DefaultCount { get; set; }
        public List<DataTablesRequestModel.Sort> DefaultSorts { get; set; }
        public IDictionary<string, object> TableAttributes { get; set; }

        public IEnumerable<DataTableColumn<TEntity>> GetValidColumns()
        {
            var objectType = Source.GetType().GetGenericArguments()[0];
            var parameter = Expression.Parameter(objectType, "m");

            var validColumns = QueryableExtensions.GetMemberExpressions(Columns, parameter);
            return validColumns.Select(x => x.Key);
        }

        public int GetColumnIndex(string columnName)
        {
            return Columns.FindAll(n => n.Visible).FindIndex(n => n.ColumnName == columnName);
        }

        public MvcHtmlString GetColumnsJson()
        {
            var validColumns = GetValidColumns();
            var serializer = new DataContractJsonSerializer(typeof(List<DataTableColumn<TEntity>>));

            foreach (var column in Columns)
            {
                if (!validColumns.Contains(column))
                {
                    column.CanSort = false;
                }
            }

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, Columns);
                return MvcHtmlString.Create(Encoding.Default.GetString(ms.ToArray()));
            }
        }

        public IEnumerable<IDataTableColumn> GetColumns()
        {
            var validColumns = GetValidColumns();

            foreach (var column in Columns)
            {
                if (!validColumns.Contains(column))
                {
                    column.CanSort = false;
                }
            }
            return Columns;
        }

        public MvcHtmlString GetSortsJson()
        {
            if (DefaultSorts == null)
                return MvcHtmlString.Create("null");

            var output = DefaultSorts.Select(x => new List<object> {x.iSortCol, x.sSortDir});
            var serializer = new JavaScriptSerializer();
            var sb = new StringBuilder();
            serializer.Serialize(output, sb);
            return MvcHtmlString.Create(sb.ToString());
        }

        public MvcHtmlString GetLanguageJson()
        {
            var output = new
                             {
                                 sEmptyTable = Shared.DataTablesPartial_NoData,
                                 sInfo = Shared.DataTablesPartial_Showing,
                                 sInfoEmpty = Shared.DataTablesPartial_ShowingEmpty,
                                 sInfoFiltered = Shared.DataTablesPartial_Filtered,
                                 sInfoPostFix = "",
                                 sInfoThousands = ',',
                                 sLengthMenu = Shared.DataTablesPartial_ShowEntries,
                                 sLoadingRecords = Shared.DataTablesPartial_Loading,
                                 sProcessing = Shared.DataTablesPartial_Processing,
                                 sSearch = Shared.DataTablesPartial_Search,
                                 sZeroRecords = Shared.DataTablesPartial_NoMatching,
                                 oPaginate = new
                                                 {
                                                     sFirst = Shared.DataTablesPartial_First,
                                                     sLast = Shared.DataTablesPartial_Last,
                                                     sNext = Shared.DataTablesPartial_Next,
                                                     sPrevious = Shared.DataTablesPartial_Previous
                                                 },
                                 oAria = new
                                             {
                                                 sSortAscending = Shared.DataTablesPartial_ARIAAsc,
                                                 sSortDescending = Shared.DataTablesPartial_ARIADesc
                                             }
                             };

            var serializer = new JavaScriptSerializer();
            var sb = new StringBuilder();
            serializer.Serialize(output, sb);
            return MvcHtmlString.Create(sb.ToString());
        }

        public bool ColumnIsValid(IDataTableColumn column)
        {
            var _validColumns = GetValidColumns();
            if (_validColumns.Contains(column))
                return true;
            return false;
        }
    }

	/// <summary>
	/// The set of properties for defining the look and behavior of functions that
	/// use a pop-up modal dialog.
	/// The dialog is populated by invoking a controller action that returns a
	/// partial view.
	/// </summary>
	public class DataTablesDialogModel
	{
		/// <summary>
		/// The name of the column to which the modal dialog is assigned.
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// The title of the modal dialog.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Width of the modal dialog.
		/// If not specified, it will be automatically calculated.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Height of the modal dialog.
		/// If not specified, it will be automatically calculated.
		/// </summary>
		public int Height { get; set; }

		/// <summary>
		/// Whether or not the dialog supports editing.
		/// If edit is supported, "save" and "cancel" buttons are provided.
		/// If edit is not supported, only a "close" button is provided.
		/// </summary>
		public bool Edit { get; set; }

        /// <summary>
        /// The text used to display on the save button
        /// </summary>
        public string SaveText { get; set; }

	}

	/// <summary>
	/// A collection of modal dialog definitions.
	/// The definition of a table requires these be defined in a collection.
	/// </summary>
	public class DataTablesDialogModelCollection : List<DataTablesDialogModel>
	{
        public void Add(string columnName, string title, int width, int height, bool edit, string saveText = "")
        {
            Add(new DataTablesDialogModel{ColumnName = columnName, Edit = edit, Height = height, Title = title, Width = width, SaveText = saveText});
        }
	}

	/// <summary>
	/// The set of properties for defining the behavior of a "direct action" function.
	/// A direct action is one that makes an immediate AJAX invocation.
	/// </summary>
	public class DataTablesDirectActionModel
	{
		/// <summary>
		/// The name of the column to which the direct action is assigned.
		/// </summary>
		public string ColumnName { get; set; }

		/// <summary>
		/// The name of a Javascript function to invoke on successful invocation of
		/// the AJAX method.
		/// This function has the same signature as the "success" function defined by
		/// the JQuery $.ajax function.
		/// </summary>
		public string SuccessFunc { get; set; }

		/// <summary>
		/// The name of a Javascript function to invoke when an error occurs invoking
		/// the AJAX method.
		/// This function has the same signature as the "error" function defined by
		/// the JQuery $.ajax function.
		/// </summary>
		public string ErrorFunc { get; set; }
	}

	/// <summary>
	/// A collection of "direct action" definitions.
	/// The definition of a table requires these be defined in a collection.
	/// </summary>
	public class DataTablesDirectActionModelCollection : List<DataTablesDirectActionModel>
	{
	}

	/// <summary>
	/// The set of properties for defining the look and behavior of the "add" button
	/// which allows new entities to be added.
	/// </summary>
	public class DataTablesAddModel
	{
		/// <summary>
		/// The action to take when the button is clicked.
		/// Typically, this will be defined as an @Html.ActionLink.
		/// This action must return a partial view that will populate a modal dialog.
		/// </summary>
        public Func<IDataTablesInitializationModel, MvcHtmlString> Action { get; set; }

		/// <summary>
		/// The title for the modal dialog that displays the view for adding.
		/// If not specified, the <code>Text</code> property is used and the title
		/// of the dialog will be the same as button label.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Width of the modal dialog.
		/// If not specified, it will be automatically calculated.
		/// </summary>
		public int Width { get; set; }

		/// <summary>
		/// Height of the modal dialog.
		/// If not specified, it will be automatically calculated.
		/// </summary>
		public int Height { get; set; }

        /// <summary>
        /// The text to display on the save button.
        /// </summary>
        public string SaveText { get; set; }
	}

	public class DataTablesRequestModel
	{
		public string epicTableId { get; set; }		// this is EPIC custom to support multiple tables per page
		public int iDisplayStart { get; set; }
		public int iDisplayLength { get; set; }
		public int iColumns { get; set; }
		public int iSortingCols { get; set; }
		public string sSearch { get; set; }
		public bool bRegex { get; set; }
		public int? sEcho { get; set; }
		public List<ColumnFilter> ColumnFilters;
		public List<Sort> Sorts;

		public class ColumnFilter
		{
			public bool bSearchable { get; set; }
			public string sSearch { get; set; }
			public bool bRegex { get; set; }
			public bool bSortable { get; set; }
			public string mDataProp { get; set; }
		}

		public class Sort
		{
			public int iSortCol;
			public string sSortDir;
		}
	}

	public class DataTablesResponseModel
	{
		private readonly List<RowData> rows;

		public DataTablesResponseModel()
		{
			rows = new List<RowData>();
		}

		public int sEcho { get; set; }
		public int iTotalRecords { get; set; }
		public int iTotalDisplayRecords { get; set; }
		public RowData[] aaData { get { return rows.ToArray(); } }

		public class RowData : Dictionary<string, string>
		{
			private int next = 0;

			public RowData()
			{
				SetRowId(string.Empty);
				SetRowClass(string.Empty);
			}

			public void SetRowId(string id)
			{
				this["DT_RowId"] = id;
			}

			public void SetRowClass(string clas)
			{
				this["DT_RowClass"] = clas;
			}

			public void PushColumn(string value)
			{
				this[next.ToString(CultureInfo.InvariantCulture)] = value;
				next++;
			}
		}

		public RowData NewRow()
		{
			RowData row = new RowData();
			rows.Add(row);
			return row;
		}
	}

	public class DataTablesRequestModelBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			DataTablesRequestModel model = ModelBinders.Binders.GetBinder(typeof(DataTablesRequestModel)).BindModel(controllerContext, bindingContext) as DataTablesRequestModel;

			if (model == null || !model.sEcho.HasValue)
				return null;

			IValueProvider valueProvider = bindingContext.ValueProvider;
			model.ColumnFilters = new List<DataTablesRequestModel.ColumnFilter>();
			model.Sorts = new List<DataTablesRequestModel.Sort>();

			for (int i = 0; i < model.iColumns && valueProvider.ContainsPrefix(string.Format("bSearchable_{0}", i)); i++)
			{
				DataTablesRequestModel.ColumnFilter column = new DataTablesRequestModel.ColumnFilter
				{
					bSearchable = GetValue<bool>(valueProvider, "bSearchable_", i),
					sSearch = GetValue<string>(valueProvider, "sSearch_", i),
					bRegex = GetValue<bool>(valueProvider, "bRegex_", i),
					bSortable = GetValue<bool>(valueProvider, "bSortable_", i),
					mDataProp = GetValue<string>(valueProvider, "mDataProp_", i)
				};
				model.ColumnFilters.Add(column);
			}

			for (int i = 0; i < model.iSortingCols && valueProvider.ContainsPrefix(string.Format("iSortCol_{0}", i)); i++)
			{
				DataTablesRequestModel.Sort sort = new DataTablesRequestModel.Sort
				{
					iSortCol = GetValue<int>(valueProvider, "iSortCol_", i),
					sSortDir = GetValue<string>(valueProvider, "sSortDir_", i)
				};
				model.Sorts.Add(sort);
			}

			return model;
		}

		private static TType GetValue<TType>(IValueProvider provider, string keyBase, int index)
		{
			string key = keyBase + index;

			if (!provider.ContainsPrefix(key))
				return default(TType);

			try
			{
				return (TType)Convert.ChangeType(provider.GetValue(key).AttemptedValue, typeof(TType));
			}
			catch (Exception)
			{
				return default(TType);
			}
		}
	}
}
