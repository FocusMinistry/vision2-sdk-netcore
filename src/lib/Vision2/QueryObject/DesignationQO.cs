using Vision2.Attributes;

namespace Vision2.QueryObject {
    public class DesignationQO : BaseQO {
        [QO("QueryTerm")]
        public string QueryTerm { get; set; }
    }
}
