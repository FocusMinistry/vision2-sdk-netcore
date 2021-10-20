using Vision2.Attributes;
using Vision2.Enum;


namespace Vision2.QueryObject {
    public class PaymentQO : BaseQO {
        [QO("PackageID")]
        public int? PackageID { get; set; }
    }
}
