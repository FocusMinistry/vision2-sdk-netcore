﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vision2.Model {
    public class Name {
        public int? Id { get; set; }

        public int? IndividualProfileId { get; set; }

        public bool IsPrimary { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public int? RowStatus { get; set; }
    }
}
