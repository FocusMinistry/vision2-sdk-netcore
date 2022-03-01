using System.Collections.Generic;

namespace Vision2.Model {
    public class Vision2ResponseData {
        public string ErrorMessage { get; set; }

        public List<string> ValidationMessages { get; set; }

        public int Status { get; set; }

        public string TrackingKey { get; set; }

        public Vision2ResponseAdditionalInformation AdditionalInfo { get; set; }
    }
}
