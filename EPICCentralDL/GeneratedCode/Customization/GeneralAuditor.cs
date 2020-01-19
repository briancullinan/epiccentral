// C#

using System;
using System.Collections.Generic;
using System.Linq;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Reflection;

namespace EPICCentralDL.Customization
{
	/// <summary>Example Auditor class which is usable on all entities in a project.</summary>
	[DependencyInjectionInfo(typeof(IEntity), "AuditorToUse")]
	[Serializable]
	public class GeneralAuditor : AuditorBase
	{
		private List<AuditEntity> _auditInfoEntities;

		/// <summary>CTor </summary>
		public GeneralAuditor()
		{
			_auditInfoEntities = new List<AuditEntity>();
		}

		public override void AuditEntityFieldSet(IEntityCore entity, int fieldIndex, object originalValue)
		{
			AuditEntity auditInfo = new AuditEntity();
			auditInfo.AuditorToUse = null;
			auditInfo.Table = ((IEntity)entity).Fields[fieldIndex].SourceObjectName;
			auditInfo.Field = ((IEntity)entity).Fields[fieldIndex].Name;
			
			// save old and new data
			if (originalValue != null)
				auditInfo.OldData = originalValue.ToString().Substring(0, Math.Min(originalValue.ToString().Length, AuditFields.OldData.MaxLength));
			if (entity.GetCurrentFieldValue(fieldIndex) != null)
				auditInfo.NewData = entity.GetCurrentFieldValue(fieldIndex).ToString().Substring(0, Math.Min(entity.GetCurrentFieldValue(fieldIndex).ToString().Length, AuditFields.NewData.MaxLength));
			else
				auditInfo.NewData = null;

			// get the primary keys fields
		    var prop = entity.GetType().GetProperty("Fields");
			var fields = ((IEntityFields)prop.GetValue(entity, null)).Where(x => x.IsPrimaryKey);
			string key = "";
            foreach (EntityField field in fields)
			{
				key += (key != "" ? "," : "") + field.CurrentValue;
			}
			auditInfo.Key = key;

			// save currently logged in user
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User != null)
				auditInfo.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name.ToLower();
			else
				auditInfo.CreatedBy = "";
			auditInfo.CreatedDate = DateTime.UtcNow;

			_auditInfoEntities.Add(auditInfo);
		}

		public override void AuditDeleteOfEntity(IEntityCore entity)
		{
			foreach (IEntityField fieldid in ((IEntity)entity).Fields)
			{
				AuditEntity auditInfo = new AuditEntity();
				auditInfo.AuditorToUse = null;
				auditInfo.Table = fieldid.SourceObjectName;
				auditInfo.Field = fieldid.Name;

				// save old and new data
			    var currentValue = entity.GetCurrentFieldValue(fieldid.FieldIndex);
			    auditInfo.OldData = currentValue != null
			                            ? currentValue.ToString().Substring(0,
			                                                                Math.Min(currentValue.ToString().Length,
			                                                                         AuditFields.OldData.MaxLength))
			                            : null;

				// get the primary keys fields
                var prop = entity.GetType().GetProperty("Fields");
                var fields = ((IEntityFields)prop.GetValue(entity, null)).Where(x => x.IsPrimaryKey);
				string key = "";
                foreach (EntityField field in fields)
				{
					key += (key != "" ? "," : "") + field.CurrentValue;
				}
				auditInfo.Key = key;

				// save currently logged in user

				if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User != null)
					auditInfo.CreatedBy = System.Web.HttpContext.Current.User.Identity.Name.ToLower();
				else
					auditInfo.CreatedBy = "";
				auditInfo.CreatedDate = DateTime.UtcNow;

				_auditInfoEntities.Add(auditInfo);
			}
		}

		/// <summary>
		/// Gets the audit entities to save. Audit entities contain the audit information stored 
		/// inside this auditor.
		/// </summary>
		/// <returns>The list of audit entities to save, or null if there are no audit entities to save</returns>
		/// <remarks>Do not remove the audit entities and audit information from this auditor when this method is 
		/// called, as the transaction in which the save takes place can fail and retried which will result in 
		/// another call to this method</remarks>
		public override System.Collections.IList GetAuditEntitiesToSave()
		{
			return _auditInfoEntities;
		}

		/// <summary>
		/// The transaction with which the audit entities requested from GetAuditEntitiesToSave were saved.
		/// Use this method to clear any audit data in this auditor as all audit information is persisted 
		/// successfully.
		/// </summary>
		public override void TransactionCommitted()
		{
			_auditInfoEntities.Clear();
		}
	}

}