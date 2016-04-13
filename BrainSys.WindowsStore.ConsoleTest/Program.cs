using System;

namespace BrainSys.WindowsStore.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsStoreApiConnector connector = new WindowsStoreApiConnector(
                "igordamianihotmail.onmicrosoft.com",
                "143f28c9-ce7e-4c81-9e82-03b84068ee22",
                "dnQpN31hTH1JWjpALVNdYkhUVClsd0tLNFRuLndvZ1c=");

            AppAcquisitionsRequest request1 = new AppAcquisitionsRequest("9WZDNCRDQJJV");
            request1.StartDate = new DateTime(2015, 01, 01);
            request1.OrderBy.Add(OrderBy.Date);
            request1.Top = 10;
            var result1 = connector.GetAppAcquisitionsAsync(request1).Result;

            InAppAcquisitionsRequest request2 = new InAppAcquisitionsRequest("9WZDNCRDQJJV", "");
            request2.StartDate = new DateTime(2015, 01, 01);
            //var result2 = connector.GetInAppAcquisitionsAsync(request2).Result;

            AppFailuresRequest request3 = new AppFailuresRequest("9WZDNCRDQJJV");
            request3.StartDate = new DateTime(2010, 01, 01);
            var result3 = connector.GetAppFailuresAsync(request3).Result;
        }
    }
}