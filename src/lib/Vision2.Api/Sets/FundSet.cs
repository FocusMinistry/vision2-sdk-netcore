using System;
using Vision2.Model;
using Vision2.QueryObject;
using System.Threading.Tasks;

namespace Vision2.Sets {
    public class FundSet : BaseSet<Fund> {
        public FundSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<Fund>>> FindAsync(FundQO qo) {
            return await SearchAsync<Fund>("/search/fund", qo);
        }

        public async Task<IVision2RestResponse<Vision2Response<Fund>>> GetAsync(int id) {
            return await GetAsync($"/fund/{id}");
        }
    }
}
