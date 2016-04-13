using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppReviewsRequest : BaseRequest
    {
        public AppReviewsRequest(string applicationId)
        {
            this.ApplicationId = applicationId;
        }
    }
}