﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision2.Enum;

namespace Vision2.Model {
    public class VolunteerParticipant {
        public int VolunteerParticipantId { get; set; }

        public int IndividualProfileId { get; set; }

        public int? DesignationId { get; set; }

        public int VolunteerOpportunityId { get; set; }

        public int VolunteerRoleId { get; set; }

        public VolunteerParticipantStatus ParticipantStatus { get; set; }

        public Fundraiser Fundraiser { get; set; }
    }
}