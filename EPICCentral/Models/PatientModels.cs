using System;
using System.Collections.Generic;
using System.Linq;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Models
{
    public class Treatment
    {
        public TreatmentPage Page { get; set; }

        public long TreatmentId { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public DateTime VisitDate { get; set; }

        public LicenseMode License { get; set; }

        public PatientPrescanQuestionEntity PatientPrescanQuestion { get; set; }

        public int OrganSystem;

        public IEnumerable<SeverityEntity> Severities;

        public IEnumerable<OrganSystemEntity> OrganSystems;

        public IQueryable<AnalysisResultEntity> Raw;

        public IQueryable<RawReportFull> Debug;

        public IQueryable<NBAnalysisResultEntity> NBScores;

        public Treatment()
        {
            Page = TreatmentPage.Summary;
        }
    }

    public class FilteredUnfiltered
    {
        public OrganComponent OrganComponent { get; set; }
        public string FingerSector { get; set; }

        public int FilteredLRRank { get; set; }
        public int FilteredLRScaledScore { get; set; }
        public int FilteredEPICRank { get; set; }
        public int FilteredEPICScaledScore { get; set; }

        public decimal FilteredEPICBaseScore { get; set; }
        public decimal FilteredEPICBonusScore { get; set; }
        public decimal FilteredEPICScore { get; set; }

        public int UnfilteredLRRank { get; set; }
        public int UnfilteredLRScaledScore { get; set; }
        public int UnfilteredEPICRank { get; set; }
        public int UnfilteredEPICScaledScore { get; set; }

        public decimal UnfilteredEPICBaseScore { get; set; }
        public decimal UnfilteredEPICBonusScore { get; set; }
        public decimal UnfilteredEPICScore { get; set; }
    }

    public class RawReportFull
    {
        public string Organ { get; set; }
        public OrganSystemOrganEntity OrganSystemOrgan { get; set; }
        public string LComp { get; set; }
        public string RComp { get; set; }
        public int OrganId { get; set; }
        public string FingerSector { get; set; }

        public string LFilteredLRRank { get; set; }
        public string RFilteredLRRank { get; set; }
        public string LFilteredLRScaledScore { get; set; }
        public string RFilteredLRScaledScore { get; set; }
        public string LFilteredEPICRank { get; set; }
        public string RFilteredEPICRank { get; set; }
        public string LFilteredEPICScaledScore { get; set; }
        public string RFilteredEPICScaledScore { get; set; }
        public string PhysicalLeft { get; set; }
        public string PhysicalRight { get; set; }
        public string LFilteredEPICBaseScore { get; set; }
        public string RFilteredEPICBaseScore { get; set; }
        public string LFilteredEPICBonusScore { get; set; }
        public string RFilteredEPICBonusScore { get; set; }
        public string LFilteredEPICScore { get; set; }
        public string RFilteredEPICScore { get; set; }

        public string LUnfilteredLRRank { get; set; }
        public string RUnfilteredLRRank { get; set; }
        public string LUnfilteredLRScaledScore { get; set; }
        public string RUnfilteredLRScaledScore { get; set; }
        public string LUnfilteredEPICRank { get; set; }
        public string RUnfilteredEPICRank { get; set; }
        public string LUnfilteredEPICScaledScore { get; set; }
        public string RUnfilteredEPICScaledScore { get; set; }
        public string MentalLeft { get; set; }
        public string MentalRight { get; set; }
        public string LUnfilteredEPICBaseScore { get; set; }
        public string RUnfilteredEPICBaseScore { get; set; }
        public string LUnfilteredEPICBonusScore { get; set; }
        public string RUnfilteredEPICBonusScore { get; set; }
        public string LUnfilteredEPICScore { get; set; }
        public string RUnfilteredEPICScore { get; set; }

    }

    public enum TreatmentPage
    {
        Summary,
        System,
        Definitions,
        Raw,
        RawReport,
        Images,
    }
}
