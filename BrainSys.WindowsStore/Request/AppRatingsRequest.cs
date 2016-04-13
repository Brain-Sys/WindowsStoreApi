using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class AppRatingsRequest : BaseRequest
    {
        public AggregationLevel AggregationLevel { get; set; }

        public AppRatingsRequest(string applicationId)
        {
            this.ApplicationId = applicationId;
            this.AggregationLevel = AggregationLevel.Day;
        }
    }
}