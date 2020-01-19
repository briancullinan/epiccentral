///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using EPICCentralDL;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: DeviceMessage. </summary>
	public partial class DeviceMessageRelations
	{
		/// <summary>CTor</summary>
		public DeviceMessageRelations()
		{
		}

		/// <summary>Gets all relations of the DeviceMessageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DeviceEntityUsingDeviceId);
			toReturn.Add(this.MessageEntityUsingMessageId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between DeviceMessageEntity and DeviceEntity over the m:1 relation they have, using the relation between the fields:
		/// DeviceMessage.DeviceId - Device.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Device", false);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, DeviceMessageFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceMessageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between DeviceMessageEntity and MessageEntity over the m:1 relation they have, using the relation between the fields:
		/// DeviceMessage.MessageId - Message.MessageId
		/// </summary>
		public virtual IEntityRelation MessageEntityUsingMessageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Message", false);
				relation.AddEntityFieldPair(MessageFields.MessageId, DeviceMessageFields.MessageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MessageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceMessageEntity", true);
				return relation;
			}
		}
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticDeviceMessageRelations
	{
		internal static readonly IEntityRelation DeviceEntityUsingDeviceIdStatic = new DeviceMessageRelations().DeviceEntityUsingDeviceId;
		internal static readonly IEntityRelation MessageEntityUsingMessageIdStatic = new DeviceMessageRelations().MessageEntityUsingMessageId;

		/// <summary>CTor</summary>
		static StaticDeviceMessageRelations()
		{
		}
	}
}
