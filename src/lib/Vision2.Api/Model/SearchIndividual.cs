﻿using System;
using System.Collections.Generic;
using Vision2.Enum;

namespace Vision2.Model {
    public class SearchIndividual {
        public SearchIndividual() {
            Names = new List<Name>();
            EmailAddresses = new List<Email>();
            Addresses = new List<Address>();
            PhoneNumbers = new List<Phone>();
        }

        public int? Id { get; set; }

        public GenderType? GenderType { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? DeceasedAsOf { get; set; }

        public bool IsStaff { get; set; }

        public int? SiteId { get; set; }

        public bool IsSuspect { get; set; }

        public List<Name> Names { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Phone> PhoneNumbers { get; set; }

        public List<Email> EmailAddresses { get; set; }
    }
}
