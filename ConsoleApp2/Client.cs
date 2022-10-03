using System.Collections.Generic;

namespace ConsoleApp2
{
    public class Client<T>
    {
        private const string ApiAddress = "https://data.korona.gov.sk/api/ag-tests/by-region";

        public readonly TestClient Client;

        public Client(TestClient client) => Client = client;

        public TestClient.Result? GetData(int? offset)
        {
            if (offset != null)
            {
                return Client.Get(ApiAddress); 
            }
            
            return Client.Get($"{ApiAddress}?offset={offset}");
        }
    }

    public class TestClient
    {
        public Result Get(string address)
        {
            return new Result()
            {
                NextOffset = 1231,
                Page = new List<Page>()
                {
                    new Page()
                    {
                        Id = 1231
                    }
                }
            };
        }

        public class Result
        {
            public int NextOffset { get; set; }
            public List<Page> Page { get; set; }
        }

        public class Page
        {
            public int Id { get; set; }
        }
    }
}