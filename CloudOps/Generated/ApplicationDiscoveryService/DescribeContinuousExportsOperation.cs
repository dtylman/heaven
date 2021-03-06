using Amazon;
using Amazon.ApplicationDiscoveryService;
using Amazon.ApplicationDiscoveryService.Model;
using Amazon.Runtime;

namespace CloudOps.ApplicationDiscoveryService
{
    public class DescribeContinuousExportsOperation : Operation
    {
        public override string Name => "DescribeContinuousExports";

        public override string Description => "Lists exports as specified by ID. All continuous exports associated with your user account can be listed if you call DescribeContinuousExports as is without passing any parameters.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "ApplicationDiscoveryService";

        public override string ServiceID => "Application Discovery Service";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonApplicationDiscoveryServiceConfig config = new AmazonApplicationDiscoveryServiceConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonApplicationDiscoveryServiceClient client = new AmazonApplicationDiscoveryServiceClient(creds, config);
            
            DescribeContinuousExportsResponse resp = new DescribeContinuousExportsResponse();
            do
            {
                DescribeContinuousExportsRequest req = new DescribeContinuousExportsRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.DescribeContinuousExports(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Descriptions)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}