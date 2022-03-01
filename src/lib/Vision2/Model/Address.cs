using System;
using Vision2.Enum;

namespace Vision2.Model {
    public class Address {
        public int? Id { get; set; }

        public int? IndividualProfileId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public bool IsPrimary { get; set; }

        public AddressType AddressType { get; set; }

        public DateTime? InactiveAsOf { get; set; }

        public string StandardizedAddress { get; set; }

        public string Country { get; set; }
    }
}
