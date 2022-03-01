using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Vision2.Attributes;
using Vision2.Enum;

namespace Vision2.QueryObject {
    public class VolunteerParticipantQO : BaseQO {
        [QO("VolunteerOpportunityId")]
        public int? VolunteerOpportunityId { get; set; }

        [QO("Status")]
        public int? Status { get; set; }

        [QO("SearchTerm")]
        public string SearchTerm { get; set; }

        [QO("VolunteerRoleId")]
        public int? VolunteerRoleId { get; set; }

        [QO("FundableId")]
        public int? FundableId { get; set; }

        [QO("IndividualProfileId")]
        public int? IndividualProfileId { get; set; }
    }
}
