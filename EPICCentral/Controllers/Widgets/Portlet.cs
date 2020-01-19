using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EPICCentral.Portlets
{
	public class Portlet : ViewPage
	{
		protected Table MainTable;

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

			Controls.Add(MainTable = new Table());
			var header_row = new TableRow();
			header_row.Controls.Add(new TableHeaderCell() { Text = Title, ColumnSpan = 2 });
			MainTable.Controls.Add(header_row);

		}
	}
}