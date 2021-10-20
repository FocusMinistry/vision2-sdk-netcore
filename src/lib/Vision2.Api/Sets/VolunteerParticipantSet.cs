using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2;
using System.Collections.Generic;
using Vision2.QueryObject;

namespace Vision2.Sets {
    public class VolunteerParticipantSet : BaseSet<VolunteerParticipant> {
        public VolunteerParticipantSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<SearchVolunteerParticipant>>> FindAsync(VolunteerParticipantQO qo) {
            return await SearchAsync<SearchVolunteerParticipant>("/search/volunteerparticipant", qo);
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerParticipant>>> GetAsync(int id) {
            return await GetAsync($"/volunteerparticipant/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<VolunteerParticipant>>> CreateAsync(VolunteerParticipant entity) {
            return await PostAsync(entity, "/volunteerparticipant");
        }
    }
}
