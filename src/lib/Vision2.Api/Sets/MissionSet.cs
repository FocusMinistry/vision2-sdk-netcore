using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;

namespace Vision2.Sets {
    public class MissionSet : BaseSet<Mission> {
        public MissionSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2Response<Mission>>> CreateAsync(Mission entity) {
            return await PostAsync(entity, "/missiontrip");
        }

        public async Task<IVision2RestResponse<Vision2Response<Mission>>> GetAsync(int id) {
            return await GetAsync($"/missiontrip/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<Mission>>> UpdateAsync(Mission entity, int id) {
            return await PostAsync(entity, $"/missiontrip/{id}");
        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<SearchMission>>> FindAsync(MissionQO qo) {
            return await SearchAsync<SearchMission>("/search/missiontrip", qo);
        }

        public async Task<IVision2RestResponse<List<VolunteerOpportunity>>> FindVolunteerOpportunitiesAsync(int fundableId) {
            return await FindAsync<VolunteerOpportunity>("/volunteeropportunity/getbydesignationid/" + fundableId);
        }
    }
}
