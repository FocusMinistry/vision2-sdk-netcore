using System;
using System.Threading.Tasks;
using Vision2.Model;
using Vision2.QueryObject;

namespace Vision2.Sets {
    public class PaymentSet : BaseSet<Payment> {
        public PaymentSet(Vision2Token token, string apiUrl, Action<IVision2RestResponse> loggingAction) : base(token, apiUrl, loggingAction) {

        }

        public async Task<IVision2RestResponse<Vision2Response<Payment>>> GetAsync(int id) {
            return await GetAsync($"/payment/{id}");
        }

        public async Task<IVision2RestResponse<Vision2Response<PaymentAdjustment>>> MakePaymentAdjustmentsAsync(PaymentAdjustment adjustments) {
            return await PostAsync(adjustments, "/payment/adjust");
        }

        public async Task<IVision2RestResponse<Vision2PagedResponse<Payment>>> FindAsync(PaymentQO qo) {
            return await SearchAsync<Payment>("/search/appliedpaymentdetails", qo);
        }
    }
}
