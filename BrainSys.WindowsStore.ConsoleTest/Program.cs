using System;

namespace BrainSys.WindowsStore.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string tenantId = "igordamianihotmail.onmicrosoft.com";
            string clientId = "143f28c9-ce7e-4c81-9e82-03b84068ee22";
            string clientSecret = "aj5kTDctTmxoeFcybX0xe0FDXnVyXSFLK3svdTF1Z3U=";
            string appId = "9wzdncrdqjjv";

            WindowsStoreApiConnector connector = new WindowsStoreApiConnector(
                tenantId, clientId, clientSecret);

            AppAcquisitionsRequest request1 = new AppAcquisitionsRequest(appId);
            request1.StartDate = new DateTime(2015, 01, 01);
            request1.OrderBy.Add(OrderBy.Date);
            request1.Top = 10;
            var result1 = connector.GetAppAcquisitionsAsync(request1).Result;

            InAppAcquisitionsRequest request2 = new InAppAcquisitionsRequest(appId, "");
            request2.StartDate = new DateTime(2015, 01, 01);
            //var result2 = connector.GetInAppAcquisitionsAsync(request2).Result;

            AppFailuresRequest request3 = new AppFailuresRequest(appId);
            request3.StartDate = new DateTime(2010, 01, 01);
            var result3 = connector.GetAppFailuresAsync(request3).Result;
        }
    }
}