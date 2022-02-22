using System;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;

namespace Vision2.Sets {
    public class DesignationSet : BaseSet<Designation> {
        private const string _searchUrl = "/search/desingation";
        private const string _getUrl = "/designation/{0}";

        public DesignationSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<Designation>>> Find(DesignationQO qo) {
            return await SearchAsync<Designation>("/search/designation", qo);
        }
    }
}
