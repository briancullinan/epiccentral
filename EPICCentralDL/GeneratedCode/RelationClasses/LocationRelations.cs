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
	/// <summary>Implements the relations factory for the entity: Location. </summary>
	public partial class LocationRelations
	{
		/// <summary>CTor</summary>
		public LocationRelations()
		{
		}

		/// <summary>Gets all relations of the LocationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ActiveOrganizationEntityUsingLocationId);
			toReturn.Add(this.DeviceEntityUsingLocationId);
			toReturn.Add(this.PatientEntityUsingLocationId);
			toReturn.Add(this.PurchaseHistoryEntityUsingLocationId);
			toReturn.Add(this.UserAssignedLocationEntityUsingLocationId);
			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LocationEntity and ActiveOrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// Location.LocationId - ActiveOrganization.LocationId
		/// </summary>
		public virtual IEntityRelation ActiveOrganizationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ActiveOrganizations" , true);
				relation.AddEntityFieldPair(LocationFields.LocationId, ActiveOrganizationFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActiveOrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LocationEntity and DeviceEntity over the 1:n relation they have, using the relation between the fields:
		/// Location.LocationId - Device.LocationId
		/// </summary>
		public virtual IEntityRelation DeviceEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Devices" , true);
				relation.AddEntityFieldPair(LocationFields.LocationId, DeviceFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LocationEntity and PatientEntity over the 1:n relation they have, using the relation between the fields:
		/// Location.LocationId - Patient.LocationId
		/// </summary>
		public virtual IEntityRelation PatientEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Patients" , true);
				relation.AddEntityFieldPair(LocationFields.LocationId, PatientFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PatientEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LocationEntity and PurchaseHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Location.LocationId - PurchaseHistory.LocationId
		/// </summary>
		public virtual IEntityRelation PurchaseHistoryEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PurchaseHistories" , true);
				relation.AddEntityFieldPair(LocationFields.LocationId, PurchaseHistoryFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LocationEntity and UserAssignedLocationEntity over the 1:n relation they have, using the relation between the fields:
		/// Location.LocationId - UserAssignedLocation.LocationId
		/// </summary>
		public virtual IEntityRelation UserAssignedLocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserAssignedLocations" , true);
				relation.AddEntityFieldPair(LocationFields.LocationId, UserAssignedLocationFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAssignedLocationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LocationEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// Location.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, LocationFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", true);
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
	internal static class StaticLocationRelations
	{
		internal static readonly IEntityRelation ActiveOrganizationEntityUsingLocationIdStatic = new LocationRelations().ActiveOrganizationEntityUsingLocationId;
		internal static readonly IEntityRelation DeviceEntityUsingLocationIdStatic = new LocationRelations().DeviceEntityUsingLocationId;
		internal static readonly IEntityRelation PatientEntityUsingLocationIdStatic = new LocationRelations().PatientEntityUsingLocationId;
		internal static readonly IEntityRelation PurchaseHistoryEntityUsingLocationIdStatic = new LocationRelations().PurchaseHistoryEntityUsingLocationId;
		internal static readonly IEntityRelation UserAssignedLocationEntityUsingLocationIdStatic = new LocationRelations().UserAssignedLocationEntityUsingLocationId;
		internal static readonly IEntityRelation OrganizationEntityUsingOrganizationIdStatic = new LocationRelations().OrganizationEntityUsingOrganizationId;

		/// <summary>CTor</summary>
		static StaticLocationRelations()
		{
		}
	}
}
