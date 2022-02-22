﻿using System;
using System.Collections.Generic;
using Vision2.Enum;

namespace Vision2.Model {
    public class SearchMission {
        public SearchMission() {
            ExternalKeys = new List<ExternalKey>();
        }

        public int ControllingOrganizationId { get; set; }

        public int OrganizationId { get; set; }

        public int? FundableId { get; set; }

        public int? FundableReferenceType { get; set; }

        public int? MobilePhotoId { get; set; }

        public int? WebPhotoId { get; set; }

        public int? CarouselPhotoId { get; set; }

        public int? GivingLinkId { get; set; }

        public int? ConnectLinkId { get; set; }

        public int OrganizationType { get; set; }
        
        public ProjectStatusType Status { get; set; }

        public bool IsControlling { get; set; }

        public bool NotOrganization { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string MobileDescription { get; set; }

        public string Tags { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public bool IsActive { get; set; }

        public object SortKey { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsArchived { get; set; }

        public string AccountSegment { get; set; }

        public string DesignationCode { get; set; }

        public bool IsApproved { get; set; }

        public bool IsHiddenFromDonorSearch { get; set; }

        public decimal? GivingGoal { get; set; }

        public bool IncludePledgesInGoalProgress { get; set; }

        public string IRSSubsection { get; set; }

        public bool IsAgency { get; set; }

        public int? AgencyVision2OrganizationId { get; set; }

        public object IRSClassifications { get; set; }

        public object IRSEntityId { get; set; }

        public string NTEECode { get; set; }

        public List<ExternalKey> ExternalKeys { get; set; }

        public int Id { get; set; }

        public int MinimumNumberOfParticipants { get; set; }

        public int MaximumNumberOfParticipants { get; set; }

        public int OrganizationFundId { get; set; }

        public decimal TargetPerPartcipant { get; set; }
    }
}
