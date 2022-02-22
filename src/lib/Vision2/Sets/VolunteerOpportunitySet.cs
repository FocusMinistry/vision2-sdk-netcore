using System;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;
using System.Collections.Generic;

namespace Vision2.Sets {
    public class VolunteerOpportunitySet : BaseSet<VolunteerOpportunity> {
        public VolunteerOpportunitySet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<List<VolunteerOpportunity>>> FindAllAsync() {
            return await FindAsync("/volunteeropportunity/");
        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<VolunteerOpportunity>>> FindAsync(VolunteerOpportunityQO qo) {
            return await SearchAsync<VolunteerOpportunity>("/search/volunteeropportunity", qo);
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerOpportunity>>> GetAsync(int id) {
            return await GetAsync($"/volunteeropportunity/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerOpportunity>>> CreateAsync(VolunteerOpportunity entity) {
            return await PostAsync(entity, "/volunteeropportunity");
        }
    }
}
