using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;


namespace Vision2.Sets {
    public class VolunteerRoleSet : BaseSet<VolunteerRole> {
        public VolunteerRoleSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<List<VolunteerRole>>> FindAllAsync() {
            return await FindAsync("/volunteerrole/");
        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<VolunteerRole>>> FindAsync(VolunteerRoleQO qo) {
            return await SearchAsync<VolunteerRole>("/search/volunteerrole", qo);
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerRole>>> GetAsync(int id) {
            return await GetAsync($"/volunteerrole/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerRole>>> CreateAsync(VolunteerRole entity) {
            return await PostAsync(entity, "/volunteerrole");
        }
    }
}
