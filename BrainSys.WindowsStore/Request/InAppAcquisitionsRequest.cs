using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainSys.WindowsStore
{
    public class InAppAcquisitionsRequest : BaseRequest
    {
        public AggregationLevel AggregationLevel { get; set; }
        public string InAppProductId { get; private set; }

        public InAppAcquisitionsRequest(string applicationId, string inAppProductId)
        {
            this.ApplicationId = applicationId;
            this.AggregationLevel = AggregationLevel.Day;
        }
    }
}