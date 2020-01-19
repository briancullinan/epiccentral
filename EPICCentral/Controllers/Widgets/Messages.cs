using System;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using EPICCentral.Providers;
using EPICCentralDL.DaoClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Portlets
{
	public partial class Messages : Portlet
	{
		public override string Title
		{
			get
			{
				return "Messages";
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);

            RelationCollection locationToMessage = new RelationCollection
                                                       {
                                                           new EntityRelation(LocationFields.LocationId, DeviceFields.LocationId, RelationType.OneToOne),
                                                           new EntityRelation(DeviceFields.DeviceId, DeviceMessageFields.DeviceId, RelationType.OneToOne),
                                                           new EntityRelation(DeviceMessageFields.MessageId, MessageFields.MessageId, RelationType.OneToOne)
                                                       };

			ResultsetFields fields = new ResultsetFields(7);
			fields.DefineField(MessageFields.MessageId, 0, "MessageId");
			fields.DefineField(MessageFields.Title, 1, "Title");
			fields.DefineField(MessageFields.Body, 2, "Body");
			fields.DefineField(MessageFields.CreateTime, 3, "CreateTime");
			fields.DefineField(MessageFields.StartTime, 4, "StartTime");
			fields.DefineField(MessageFields.EndTime, 5, "EndTime");
			fields.DefineField(LocationFields.Name, 6, "LocationName");

			DataTable dynamicList = new DataTable();
			TypedListDAO dao = new TypedListDAO();

            if (Roles.IsUserInRole("Service Administrator"))
                dao.GetMultiAsDataTable(fields, dynamicList, 0, null, null, locationToMessage, true, null, null, 0, 0);
            else if (Roles.IsUserInRole("Organization Administrator"))
                dao.GetMultiAsDataTable(fields, dynamicList, 0, null,
                                        new PredicateExpression(LocationFields.OrganizationId == Membership.GetUser().GetUserId().OrganizationId),
                                        locationToMessage, true, null, null, 0, 0);
			//else
            //    messages.GetMulti(EcMessageBankFields.CustomerLocationId == user.LocationId);

			if (dynamicList.Rows.Count > 0)
			{
				bool alternate = false;
				foreach (DataRow message in dynamicList.Rows)
				{
					TableRow messageHeader = new TableRow() { CssClass = alternate ? "alternate" : "" };
					messageHeader.Controls.Add(new TableCell() { Text = message["CreateTime"].ToString() });
                    messageHeader.Controls.Add(new TableCell() { Text = message["LocationName"].ToString() });
					MainTable.Controls.Add(messageHeader);

					TableRow messageBody = new TableRow() { CssClass = alternate ? "alternate" : "" };
				    messageBody.Controls.Add(new TableCell()
				                                 {
				                                     ColumnSpan = 2,
				                                     Text =
				                                         "<strong style='float:left; display:inline-block; padding-right:5px;'>" +
				                                         message["Title"] + "</strong>" + message["Body"]
				                                 });
					MainTable.Controls.Add(messageBody);

					alternate = !alternate;
				}
			}
			else
			{
				TableRow empty_list = new TableRow();
				empty_list.Controls.Add(new TableCell() { Text = "No messages to display." });
				MainTable.Controls.Add(empty_list);
			}
		}
	}
}