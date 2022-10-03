using System;
using System.Collections.Generic;
using ConsoleApp2.Model;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ClientFactory();
            ClientFactory.LoadDataFromApiToDatabase();

            try
            {
                SaveOffset(factory);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public class ClientFactory
        {
            public static List<Object> Clients { get; set; } = new();

            private static void CreateClients()
            {
                var hospitalClient = new Client<Hospital>(new TestClient());
                hospitalClient.Client.Get("http://gov.korona/hospitals");
                
                Clients.Add(hospitalClient);
            }
            
            public static void LoadDataFromApiToDatabase()
            {
                CreateClients();
                foreach (var client in clients)
                {
                    (Client<Hospital>)client.GetData();
                }
            }
        }

        public static int SaveOffsetRec(int offset, Client client)
        {
           
            if(offset != null)
            {

                var result = client.GetData(offset);
                
                // database save
            }

        }
        private static void SaveOffset(ClientFactory result)
        {
            foreach (var item in result)
            {
                // serialize to Json -> Java Object   var obj = serializeFromJson(item)
                // save to database (obj)
            }
        }
    }
}