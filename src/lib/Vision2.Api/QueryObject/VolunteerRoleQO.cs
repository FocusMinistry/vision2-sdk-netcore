using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Vision2.Attributes;

namespace Vision2.QueryObject {
    public class VolunteerRoleQO : BaseQO {
        [QO("SearchTerm")]
        public string SearchTerm { get; set; }
    }
}
