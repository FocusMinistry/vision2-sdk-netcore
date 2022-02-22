﻿using Vision2.Attributes;
using Vision2.Enum;

namespace Vision2.QueryObject {
    public class IndividualQO : BaseQO {
        [QO("OrganizationID")]
        public int? OrganizationID { get; set; }

        [QO("UseComplex")]
        public bool UseComplex { get; set; }

        [QO("FirstName")]
        public string FirstName { get; set; }

        [QO("LastName")]

        public string LastName { get; set; }

        [QO("Address1")]
        public string Address1 { get; set; }

        [QO("Address2")]
        public string Address2 { get; set; }

        [QO("City")]
        public string City { get; set; }

        [QO("Region")]
        public string Region { get; set; }

        [QO("PostalCode")]
        public string PostalCode { get; set; }

        [QO("EmailAddress")]
        public string EmailAddress { get; set; }

        [QO("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [QO("QueryString")]
        public string QueryString { get; set; }
    }
}
