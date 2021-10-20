using System;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;

namespace Vision2.Sets {
    public class IndividualSet : BaseSet<Individual> {
        public IndividualSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<SearchIndividual>>> FindAsync(IndividualQO qo) {
            return await SearchAsync<SearchIndividual>("/search/individual", qo);
        }

        public async Task<IVision2RestResponse<Vision2Response<Individual>>> GetAsync(int id) {
            return await GetAsync($"/individual/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<Individual>>> CreateAsync(Individual entity) {
            return await PostAsync(entity, "/individual");
        }
    }
}
