using Amazon;
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;
using Amazon.Runtime;

namespace CloudOps.AlexaForBusiness
{
    public class SearchUsersOperation : Operation
    {
        public override string Name => "SearchUsers";

        public override string Description => "Searches users and lists the ones that meet a set of filter and sort criteria.";
 
        public override string RequestURI => "/";

        public override string Method => "POST";

        public override string ServiceName => "AlexaForBusiness";

        public override string ServiceID => "Alexa For Business";

        public override void Invoke(AWSCredentials creds, RegionEndpoint region, int maxItems)
        {
            AmazonAlexaForBusinessConfig config = new AmazonAlexaForBusinessConfig();
            config.RegionEndpoint = region;
            ConfigureClient(config);            
            AmazonAlexaForBusinessClient client = new AmazonAlexaForBusinessClient(creds, config);
            
            SearchUsersResponse resp = new SearchUsersResponse();
            do
            {
                SearchUsersRequest req = new SearchUsersRequest
                {
                    NextToken = resp.NextToken
                    ,
                    MaxResults = maxItems
                                        
                };

                resp = client.SearchUsers(req);
                CheckError(resp.HttpStatusCode, "200");                
                
                foreach (var obj in resp.Users)
                {
                    AddObject(obj);
                }
                
            }
            while (!string.IsNullOrEmpty(resp.NextToken));
        }
    }
}