using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ActiveQLibrary.Form
{
	/// <summary>
	/// Summary description for PageScheduledMail.
	/// </summary>
	public class PageScheduledMail : ActiveQLibrary.Form.PageBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private ActiveQLibrary.CustomControl.ButtonXP _bDelete;
		private System.Windows.Forms.Panel panel1;
		private ActiveQLibrary.CustomControl.PanelGradient panel4;
		private System.Windows.Forms.TextBox _tbAddedDate;
		private System.Windows.Forms.Label label6;
		private ActiveQLibrary.CustomControl.PanelGradient panel2;
		private System.Windows.Forms.TextBox _tbSubject;
		private System.Windows.Forms.Label label5;
		private ActiveQLibrary.CustomControl.PanelGradient panel7;
		private System.Windows.Forms.TextBox _tbBcc;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _tbTo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox _tbCc;
		private System.Windows.Forms.Label label2;
		private ActiveQLibrary.CustomControl.PanelGradient panel3;
		private System.Windows.Forms.TextBox _tbFrom;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox _tbSendingDate;
		private ActiveQLibrary.CustomControl.ListBoxVS lbScheduledQueue;

		public PageScheduledMail(TypePage Type) : base(Type)
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			this.Location = new Point(0,51);

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Properties

		public ListBox ScheduledQueue
		{
			get
			{
				return lbScheduledQueue;
			}
		}

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PageScheduledMail));
			this._bDelete = new ActiveQLibrary.CustomControl.ButtonXP();
			this.lbScheduledQueue = new ActiveQLibrary.CustomControl.ListBoxVS();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new ActiveQLibrary.CustomControl.PanelGradient();
			this._tbSendingDate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this._tbAddedDate = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.panel2 = new ActiveQLibrary.CustomControl.PanelGradient();
			this._tbSubject = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel7 = new ActiveQLibrary.CustomControl.PanelGradient();
			this._tbBcc = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this._tbTo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this._tbCc = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new ActiveQLibrary.CustomControl.PanelGradient();
			this._tbFrom = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// _bDelete
			// 
			this._bDelete._Image = null;
			this._bDelete.DefaultScheme = false;
			this._bDelete.Image = ((System.Drawing.Bitmap)(resources.GetObject("_bDelete.Image")));
			this._bDelete.Location = new System.Drawing.Point(144, 332);
			this._bDelete.Name = "_bDelete";
			this._bDelete.Scheme = ActiveQLibrary.CustomControl.ButtonXP.Schemes.Blue;
			this._bDelete.Size = new System.Drawing.Size(75, 23);
			this._bDelete.SizeImgButton = new System.Drawing.Size(0, 0);
			this._bDelete.TabIndex = 48;
			this._bDelete.Text = "Delete";
			this._bDelete.Click += new System.EventHandler(this._bDelete_Click_1);
			// 
			// lbScheduledQueue
			// 
			this.lbScheduledQueue.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lbScheduledQueue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lbScheduledQueue.HorizontalScrollbar = true;
			this.lbScheduledQueue.Img = ((System.Drawing.Bitmap)(resources.GetObject("lbScheduledQueue.Img")));
			this.lbScheduledQueue.ItemHeight = 14;
			this.lbScheduledQueue.Location = new System.Drawing.Point(8, 8);
			this.lbScheduledQueue.Name = "lbScheduledQueue";
			this.lbScheduledQueue.Size = new System.Drawing.Size(208, 322);
			this.lbScheduledQueue.TabIndex = 49;
			this.lbScheduledQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbScheduledQueue_KeyDown_1);
			this.lbScheduledQueue.SelectedValueChanged += new System.EventHandler(this.lbScheduledQueue_SelectedValueChanged);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.panel4,
																				 this.panel2,
																				 this.panel7,
																				 this.panel3,
																				 this.lbScheduledQueue,
																				 this._bDelete});
			this.panel1.Location = new System.Drawing.Point(6, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(462, 365);
			this.panel1.TabIndex = 50;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.Control;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this._tbSendingDate,
																				 this.label7,
																				 this._tbAddedDate,
																				 this.label6});
			this.panel4.GradientColorTwo = System.Drawing.Color.LightSteelBlue;
			this.panel4.Location = new System.Drawing.Point(224, 265);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(224, 88);
			this.panel4.TabIndex = 69;
			// 
			// _tbSendingDate
			// 
			this._tbSendingDate.BackColor = System.Drawing.Color.White;
			this._tbSendingDate.Location = new System.Drawing.Point(8, 64);
			this._tbSendingDate.Name = "_tbSendingDate";
			this._tbSendingDate.ReadOnly = true;
			this._tbSendingDate.Size = new System.Drawing.Size(208, 20);
			this._tbSendingDate.TabIndex = 3;
			this._tbSendingDate.Text = "";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label7.Location = new System.Drawing.Point(8, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "Sending date :";
			// 
			// _tbAddedDate
			// 
			this._tbAddedDate.BackColor = System.Drawing.Color.White;
			this._tbAddedDate.Location = new System.Drawing.Point(8, 24);
			this._tbAddedDate.Name = "_tbAddedDate";
			this._tbAddedDate.ReadOnly = true;
			this._tbAddedDate.Size = new System.Drawing.Size(208, 20);
			this._tbAddedDate.TabIndex = 1;
			this._tbAddedDate.Text = "";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label6.Location = new System.Drawing.Point(8, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 16);
			this.label6.TabIndex = 0;
			this.label6.Text = "Added date :";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this._tbSubject,
																				 this.label5});
			this.panel2.GradientColorTwo = System.Drawing.Color.LightSteelBlue;
			this.panel2.Location = new System.Drawing.Point(224, 208);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(224, 48);
			this.panel2.TabIndex = 68;
			// 
			// _tbSubject
			// 
			this._tbSubject.BackColor = System.Drawing.Color.White;
			this._tbSubject.Location = new System.Drawing.Point(8, 24);
			this._tbSubject.Name = "_tbSubject";
			this._tbSubject.ReadOnly = true;
			this._tbSubject.Size = new System.Drawing.Size(208, 20);
			this._tbSubject.TabIndex = 1;
			this._tbSubject.Text = "";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label5.Location = new System.Drawing.Point(8, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Subject :";
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.SystemColors.Control;
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this._tbBcc,
																				 this.label1,
																				 this._tbTo,
																				 this.label4,
																				 this._tbCc,
																				 this.label2});
			this.panel7.GradientColorTwo = System.Drawing.Color.LightSteelBlue;
			this.panel7.Location = new System.Drawing.Point(224, 64);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(224, 136);
			this.panel7.TabIndex = 67;
			// 
			// _tbBcc
			// 
			this._tbBcc.BackColor = System.Drawing.Color.White;
			this._tbBcc.Location = new System.Drawing.Point(8, 112);
			this._tbBcc.Name = "_tbBcc";
			this._tbBcc.ReadOnly = true;
			this._tbBcc.Size = new System.Drawing.Size(208, 20);
			this._tbBcc.TabIndex = 3;
			this._tbBcc.Text = "";
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(8, 88);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Bcc : ";
			// 
			// _tbTo
			// 
			this._tbTo.BackColor = System.Drawing.Color.White;
			this._tbTo.Location = new System.Drawing.Point(8, 24);
			this._tbTo.Name = "_tbTo";
			this._tbTo.ReadOnly = true;
			this._tbTo.Size = new System.Drawing.Size(208, 20);
			this._tbTo.TabIndex = 1;
			this._tbTo.Text = "";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "To :";
			// 
			// _tbCc
			// 
			this._tbCc.BackColor = System.Drawing.Color.White;
			this._tbCc.Location = new System.Drawing.Point(8, 66);
			this._tbCc.Name = "_tbCc";
			this._tbCc.ReadOnly = true;
			this._tbCc.Size = new System.Drawing.Size(208, 20);
			this._tbCc.TabIndex = 1;
			this._tbCc.Text = "";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(9, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "Cc : ";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Control;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this._tbFrom,
																				 this.label3});
			this.panel3.GradientColorTwo = System.Drawing.Color.LightSteelBlue;
			this.panel3.Location = new System.Drawing.Point(224, 8);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(224, 48);
			this.panel3.TabIndex = 66;
			// 
			// _tbFrom
			// 
			this._tbFrom.BackColor = System.Drawing.Color.White;
			this._tbFrom.Location = new System.Drawing.Point(8, 24);
			this._tbFrom.Name = "_tbFrom";
			this._tbFrom.ReadOnly = true;
			this._tbFrom.Size = new System.Drawing.Size(208, 20);
			this._tbFrom.TabIndex = 1;
			this._tbFrom.Text = "";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "From :";
			// 
			// PageScheduledMail
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1});
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "PageScheduledMail";
			this.Load += new System.EventHandler(this.PageScheduledMail_Load);
			this.panel1.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void lbScheduledQueue_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (lbScheduledQueue.SelectedIndex >= 0)
				ShowInformation(lbScheduledQueue.SelectedItem.ToString());
		}

		private void DeleteSelectedMail()
		{
			int index = lbScheduledQueue.SelectedIndex;

			if (index != -1)
			{
				string ItemToDelete = lbScheduledQueue.SelectedItem.ToString();
				Global.Log.WriteEvent(LogType.debug,string.Format("[FORM:SCHMAIL] Deleting scheduled mail : '{0}'",ItemToDelete));

				if (Global.DeleteScheduledMail(ItemToDelete) == true)
				{
					if (index > 0)
						lbScheduledQueue.SelectedIndex = index - 1;
					else if (lbScheduledQueue.Items.Count > 0)
						lbScheduledQueue.SelectedIndex = 0;
					else if (lbScheduledQueue.Items.Count == 0)
						ClearInfo();
				}

				else
				{
					MessageBox.Show("Unable to delete this mail because it's in use","Error deleting scheduled mail",MessageBoxButtons.OK,MessageBoxIcon.Error);
					Global.Log.WriteError(string.Format("[FORM:SCHMAIL] Unable to delete scheduled mail : '{0}', it's in use",ItemToDelete));
				}
			}
		}

		private void ShowInformation(string Name)
		{
			SpooledObject obj = ActiveQLibrary.QueueScheduled.GiveSpooledObject(Name);

			if (obj != null)
			{
				if (_bDelete.Enabled == false)
					_bDelete.Enabled = true;
				
				Object message = Activator.CreateInstance(Global.ActiveMailAsm.GetType("ActiveUp.Net.Mail.Message",true));
				message = obj.Object;
				this._tbFrom.Text = message.GetType().GetProperty("From").GetValue(message,null).GetType().GetProperty("Email").GetValue(message.GetType().GetProperty("From").GetValue(message,null),null).ToString();
				this._tbTo.Text = message.GetType().GetProperty("To").GetValue(message,null).GetType().GetProperty("Merged").GetValue(message.GetType().GetProperty("To").GetValue(message,null),null).ToString();
				this._tbCc.Text = message.GetType().GetProperty("Cc").GetValue(message,null).GetType().GetProperty("Merged").GetValue(message.GetType().GetProperty("Cc").GetValue(message,null),null).ToString();
				this._tbBcc .Text = message.GetType().GetProperty("Bcc").GetValue(message,null).GetType().GetProperty("Merged").GetValue(message.GetType().GetProperty("Bcc").GetValue(message,null),null).ToString();
				this._tbSubject.Text = message.GetType().GetProperty("Subject").GetValue(message,null).ToString();
				this._tbAddedDate.Text = obj.AddedDate.ToString();			
				this._tbSendingDate.Text = obj.SendingDate.ToString();
			
			}
		}

		private void ClearInfo()
		{
			_bDelete.Enabled = false;

			this._tbFrom.Text = "";
			this._tbCc.Text = "";
			this._tbBcc .Text = "";
			this._tbSubject.Text = "";
			this._tbAddedDate.Text = "";
			this._tbSendingDate.Text = "";
		}

		private void PageScheduledMail_Load(object sender, System.EventArgs e)
		{
			_bDelete.Enabled = false;
		}

		private void _bDelete_Click_1(object sender, System.EventArgs e)
		{
			DeleteSelectedMail();
		}

		private void lbScheduledQueue_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				DeleteSelectedMail();
			}
		}

	}
}
